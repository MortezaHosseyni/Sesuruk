using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Sesuruk.Forms;

namespace Sesuruk
{
    public partial class FormMain : XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void btn_SettingsForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            var settingsForm = new FormSettings();
            settingsForm.ShowDialog();
        }

        private void btn_About_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Sesuruk\nV1.0.0", "About App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
