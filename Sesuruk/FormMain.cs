using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

            _soundManager.Delete(Guid.Parse(id.ToString()));

            LoadSounds();
        }
        #endregion
    }
}
