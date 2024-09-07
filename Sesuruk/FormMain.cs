using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
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

        private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _previousInputDevice.SetAsDefaultAsync();
            await _previousInputDevice.SetAsDefaultCommunicationsAsync();
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
        private WaveOutEvent _speakerOutputDevice;
        private IWaveProvider _audioFileVirtualCable;
        private IWaveProvider _audioFileSpeaker;
        private bool _isPlaying;

        private bool _playFromSpeakerAlso;

        private CoreAudioDevice _previousInputDevice;

        public async Task PlaySound()
        {
            var audioFilePath = _currentSound;

            if (!File.Exists(audioFilePath))
            {
                MessageBox.Show("Audio file is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StopSound();

            SetInputDeviceToCableOutput();

            if (audioFilePath.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    _audioFileVirtualCable = new VorbisWaveReader(audioFilePath);
                    _audioFileSpeaker = new VorbisWaveReader(audioFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Ogg file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                _audioFileVirtualCable = new AudioFileReader(audioFilePath);
                _audioFileSpeaker = new AudioFileReader(audioFilePath);
            }

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

            _outputDevice.Init(_audioFileVirtualCable);

            if (_playFromSpeakerAlso)
            {
                _speakerOutputDevice = new WaveOutEvent();
                _speakerOutputDevice.DeviceNumber = -1;

                try
                {
                    _speakerOutputDevice.Init(_audioFileSpeaker);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error initializing speaker output: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _outputDevice.PlaybackStopped += OnPlaybackStopped;

            _outputDevice.Play();

            if (_playFromSpeakerAlso)
            {
                _speakerOutputDevice.Play();
            }

            _isPlaying = true;

            var totalDuration = (_audioFileVirtualCable as AudioFileReader)?.TotalTime ?? TimeSpan.Zero;
            pgb_SoundProgress.Properties.Maximum = (int)totalDuration.TotalSeconds;
            pgb_SoundProgress.EditValue = 0;

            btn_PlayPause.ImageOptions.SvgImage = Properties.Resources.pause;

            ctx_CurrentSoundName.Text = _currentSound.Split('\\').Last();

            while (_outputDevice?.PlaybackState == PlaybackState.Playing && _isPlaying)
            {
                var currentPosition = (_audioFileVirtualCable as AudioFileReader)?.CurrentTime ?? TimeSpan.Zero;

                pgb_SoundProgress.EditValue = (int)currentPosition.TotalSeconds;

                var remainingTime = totalDuration - currentPosition;
                ctx_SoundDuration.Invoke((MethodInvoker)(() =>
                        ctx_SoundDuration.Text = remainingTime.ToString(@"mm\:ss")
                ));

                await Task.Delay(500);
            }

            StopSound();
        }

        public void StopSound()
        {
            RevertToPreviousInputDevice();

            if (_outputDevice != null)
            {
                _outputDevice.Stop();
                _outputDevice.Dispose();
                _outputDevice = null;
            }

            if (_speakerOutputDevice != null)
            {
                _speakerOutputDevice.Stop();
                _speakerOutputDevice.Dispose();
                _speakerOutputDevice = null;
            }

            if (_audioFileVirtualCable != null)
            {
                (_audioFileVirtualCable as IDisposable)?.Dispose();
                _audioFileVirtualCable = null;
            }

            if (_audioFileSpeaker != null)
            {
                (_audioFileSpeaker as IDisposable)?.Dispose();
                _audioFileSpeaker = null;
            }

            _isPlaying = false;

            pgb_SoundProgress.EditValue = 0;
            ctx_SoundDuration.Text = "00:00";
            btn_PlayPause.ImageOptions.SvgImage = Properties.Resources.next;
        }

        private async void SetInputDeviceToCableOutput()
        {
            var controller = new CoreAudioController();

            _previousInputDevice = controller.DefaultCaptureDevice;

            var devices = await controller.GetDevicesAsync(DeviceType.Capture);
            var cableOutputDevice = devices.FirstOrDefault(d => d.FullName.Contains("CABLE Output"));

            if (cableOutputDevice != null)
            {
                await cableOutputDevice.SetAsDefaultAsync();
                await cableOutputDevice.SetAsDefaultCommunicationsAsync();
            }
            else
            {
                MessageBox.Show("CABLE Output device not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RevertToPreviousInputDevice()
        {
            if (_previousInputDevice == null) return;

            await _previousInputDevice.SetAsDefaultAsync();
            await _previousInputDevice.SetAsDefaultCommunicationsAsync();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            _isPlaying = false;
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

        private void btn_PlayFromSpeaker_Click(object sender, EventArgs e)
        {
            if (!_playFromSpeakerAlso)
            {
                _playFromSpeakerAlso = true;
                btn_PlayFromSpeaker.ImageOptions.SvgImage = Properties.Resources.Headphone2;
            }
            else
            {
                _playFromSpeakerAlso = false;
                btn_PlayFromSpeaker.ImageOptions.SvgImage = Properties.Resources.Headphone;
            }
        }
        #endregion
    }
}
