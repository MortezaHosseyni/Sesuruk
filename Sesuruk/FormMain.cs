using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using NAudio.Vorbis;
using NAudio.Wave;
using Sesuruk.Forms;
using Sesuruk.Functions;

namespace Sesuruk
{
    public partial class FormMain : XtraForm
    {
        private readonly Sound _soundManager;
        private readonly Settings _settings;

        private readonly BindingList<Sound> _soundList = new BindingList<Sound>();

        private string _currentSound = string.Empty;

        public FormMain(Sound soundManager, Settings settings)
        {
            InitializeComponent();

            _soundManager = soundManager;
            _settings = settings;

            ctx_AudioStatus.Text = "Device Id: " + settings.GetVirtualCableDeviceIndex();

            jds_SoundSource.FillAsync();
            dgv_SoundsList.DataSource = _soundList;

            if (!(dgv_SoundsList.MainView is GridView view)) return;
            view.Columns[0].Visible = false;
            view.CustomDrawRowIndicator += dgv_SoundsList_CustomDrawRowIndicator;
        }

        #region Loading
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadSounds();
        }

        private void LoadSounds()
        {
            _soundList.Clear();

            var sounds = _soundManager.Load();
            foreach (var sound in sounds)
            {
                _soundList.Add(sound);
            }
        }

        private void dgv_SoundsList_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!(dgv_SoundsList.MainView is GridView view)) return;
            if (!e.Info.IsRowIndicator || e.RowHandle < 0) return;

            e.Info.DisplayText = (e.RowHandle + 1).ToString();

            if (view.IndicatorWidth < 40)
                view.IndicatorWidth = 40;
        }
        #endregion

        #region Help
        private void btn_SettingsForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            var settingsForm = new FormSettings();
            settingsForm.ShowDialog();
        }

        private void btn_About_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Sesuruk\nV1.0.0", "About App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Add Sound
        private void btn_AddSound_Click(object sender, EventArgs e)
        {
            AddSound();
            LoadSounds();
        }
        private void btn_AddSoundTop_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddSound();
            LoadSounds();
        }

        private void AddSound()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Sound Files (*.mp3;*.wav;*.flac;*.ogg)|*.mp3;*.wav;*.flac;*.ogg";
                openFileDialog.Title = "Select a Sound File";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                var fileName = Path.GetFileName(openFileDialog.FileName);
                var fileLocation = openFileDialog.FileName;

                var soundAdded = _soundManager.Add(fileName, fileLocation);

                MessageBox.Show(soundAdded.Item2, soundAdded.Item1 ? "Success" : "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Delete Sound
        private void btn_DeleteSound_Click(object sender, EventArgs e)
        {
            if (!(dgv_SoundsList.MainView is GridView view)) return;

            var id = view.GetFocusedRowCellValue("Id");

            if (id == null) return;

            var result = MessageBox.Show("Are you sure you want to delete this sound?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            _soundManager.Delete(Guid.Parse(id.ToString()));
            LoadSounds();
        }
        #endregion

        #region Play & Load Sounds
        private WaveOutEvent _outputDevice;
        private WaveStream _audioFile;
        private bool _isPlaying;

        public async Task PlaySound()
        {
            var audioFilePath = _currentSound;

            if (!File.Exists(audioFilePath))
            {
                MessageBox.Show("Audio file is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StopSound();

            if (audioFilePath.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase))
                _audioFile = new VorbisWaveReader(audioFilePath);
            else
                _audioFile = new AudioFileReader(audioFilePath);

            _outputDevice = new WaveOutEvent();

            try
            {
                var virtualCableDeviceId = _settings.GetVirtualCableDeviceIndex();
                _outputDevice.DeviceNumber = virtualCableDeviceId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _outputDevice.Init(_audioFile);

            _outputDevice.PlaybackStopped += OnPlaybackStopped;

            _isPlaying = true;

            var totalDuration = _audioFile.TotalTime;
            pgb_SoundProgress.Properties.Maximum = (int)totalDuration.TotalSeconds;
            pgb_SoundProgress.EditValue = 0;

            _outputDevice.Play();

            btn_PlayPause.ImageOptions.SvgImage = Properties.Resources.pause;

            ctx_CurrentSoundName.Text = _currentSound.Split('\\').Last();

            while (_outputDevice?.PlaybackState == PlaybackState.Playing && _isPlaying)
            {
                var currentPosition = _audioFile.CurrentTime;

                pgb_SoundProgress.EditValue = (int)currentPosition.TotalSeconds;

                var remainingTime = totalDuration - currentPosition;
                ctx_SoundDuration.Invoke((MethodInvoker)(() =>
                        ctx_SoundDuration.Text = remainingTime.ToString(@"mm\:ss")
                ));

                await Task.Delay(500);
            }

            StopSound();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            _isPlaying = false;
        }

        public void StopSound()
        {
            if (_outputDevice == null) return;

            _outputDevice.Stop();
            _outputDevice.Dispose();
            _outputDevice = null;

            _audioFile?.Dispose();
            _audioFile = null;

            _isPlaying = false;

            pgb_SoundProgress.EditValue = 0;
            ctx_SoundDuration.Text = "00:00";
            btn_PlayPause.ImageOptions.SvgImage = Properties.Resources.next;
        }

        private async void btn_PlayPause_Click(object sender, EventArgs e)
        {
            if (_isPlaying)
                StopSound();
            else
                await PlaySound();
        }

        private void dgv_SoundsList_Click(object sender, EventArgs e)
        {
            if (!(dgv_SoundsList.MainView is GridView view)) return;

            var location = view.GetFocusedRowCellValue("Location").ToString();

            StopSound();
            _currentSound = location;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (!(dgv_SoundsList.MainView is GridView view)) return;

            var currentRowHandle = view.FocusedRowHandle;

            if (currentRowHandle + 1 < view.RowCount)
            {
                view.FocusedRowHandle = currentRowHandle + 1;
                view.MakeRowVisible(currentRowHandle + 1);

                var nextRowLocation = view.GetRowCellValue(currentRowHandle + 1, "Location").ToString();

                StopSound();
                _currentSound = nextRowLocation;
            }
            else
            {
                MessageBox.Show("There is no next sound.", "No Sound", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (!(dgv_SoundsList.MainView is GridView view)) return;

            var currentRowHandle = view.FocusedRowHandle;

            if (currentRowHandle - 1 < view.RowCount)
            {
                view.FocusedRowHandle = currentRowHandle - 1;
                view.MakeRowVisible(currentRowHandle - 1);

                var nextRowLocation = view.GetRowCellValue(currentRowHandle - 1, "Location").ToString();

                StopSound();
                _currentSound = nextRowLocation;
            }
            else
            {
                MessageBox.Show("There is no previous sound.", "No Sound", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
