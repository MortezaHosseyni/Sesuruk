using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Sesuruk.Forms;
using Sesuruk.Functions;

namespace Sesuruk
{
    public partial class FormMain : XtraForm
    {
        private readonly Sound _soundManager;

        private readonly BindingList<Sound> _soundList = new BindingList<Sound>();

        public FormMain(Sound soundManager)
        {
            InitializeComponent();

            _soundManager = soundManager;

            jds_SoundSource.FillAsync();
            dgv_SoundsList.DataSource = _soundList;
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
        #endregion

        private void btn_SettingsForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            var settingsForm = new FormSettings();
            settingsForm.ShowDialog();
        }

        private void btn_About_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Sesuruk\nV1.0.0", "About App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
    }
}
