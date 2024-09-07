namespace Sesuruk.Forms
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.lbl_OutputDevice = new DevExpress.XtraEditors.LabelControl();
            this.ddb_OutputDevice = new DevExpress.XtraEditors.DropDownButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chk_PlayWhenSelected = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Backup = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Restore = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chk_PlayWhenSelected.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_OutputDevice
            // 
            this.lbl_OutputDevice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbl_OutputDevice.Appearance.Options.UseFont = true;
            this.lbl_OutputDevice.Enabled = false;
            this.lbl_OutputDevice.Location = new System.Drawing.Point(12, 12);
            this.lbl_OutputDevice.Name = "lbl_OutputDevice";
            this.lbl_OutputDevice.Size = new System.Drawing.Size(106, 19);
            this.lbl_OutputDevice.TabIndex = 0;
            this.lbl_OutputDevice.Text = "Output Device:";
            // 
            // ddb_OutputDevice
            // 
            this.ddb_OutputDevice.Enabled = false;
            this.ddb_OutputDevice.Location = new System.Drawing.Point(124, 12);
            this.ddb_OutputDevice.Name = "ddb_OutputDevice";
            this.ddb_OutputDevice.Size = new System.Drawing.Size(226, 23);
            this.ddb_OutputDevice.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(0, 19);
            this.labelControl2.TabIndex = 2;
            // 
            // chk_PlayWhenSelected
            // 
            this.chk_PlayWhenSelected.Enabled = false;
            this.chk_PlayWhenSelected.Location = new System.Drawing.Point(12, 63);
            this.chk_PlayWhenSelected.Name = "chk_PlayWhenSelected";
            this.chk_PlayWhenSelected.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chk_PlayWhenSelected.Properties.Appearance.Options.UseFont = true;
            this.chk_PlayWhenSelected.Properties.Caption = "Play when sound selected";
            this.chk_PlayWhenSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_PlayWhenSelected.Size = new System.Drawing.Size(204, 23);
            this.chk_PlayWhenSelected.TabIndex = 3;
            // 
            // btn_Backup
            // 
            this.btn_Backup.Enabled = false;
            this.btn_Backup.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Backup.ImageOptions.SvgImage")));
            this.btn_Backup.Location = new System.Drawing.Point(95, 329);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(157, 41);
            this.btn_Backup.TabIndex = 4;
            this.btn_Backup.Text = "Backup";
            // 
            // btn_Restore
            // 
            this.btn_Restore.Enabled = false;
            this.btn_Restore.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Restore.ImageOptions.SvgImage")));
            this.btn_Restore.Location = new System.Drawing.Point(95, 376);
            this.btn_Restore.Name = "btn_Restore";
            this.btn_Restore.Size = new System.Drawing.Size(157, 41);
            this.btn_Restore.TabIndex = 5;
            this.btn_Restore.Text = "Restore";
            // 
            // FormSettings
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 450);
            this.Controls.Add(this.btn_Restore);
            this.Controls.Add(this.btn_Backup);
            this.Controls.Add(this.chk_PlayWhenSelected);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ddb_OutputDevice);
            this.Controls.Add(this.lbl_OutputDevice);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.IconOptions.Image = global::Sesuruk.Properties.Resources.Sesuruk;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(364, 482);
            this.MinimumSize = new System.Drawing.Size(364, 482);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.chk_PlayWhenSelected.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_OutputDevice;
        private DevExpress.XtraEditors.DropDownButton ddb_OutputDevice;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chk_PlayWhenSelected;
        private DevExpress.XtraEditors.SimpleButton btn_Backup;
        private DevExpress.XtraEditors.SimpleButton btn_Restore;
    }
}