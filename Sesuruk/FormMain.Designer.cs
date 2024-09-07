namespace Sesuruk
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.brm_TopBar = new DevExpress.XtraBars.BarManager(this.components);
            this.bar_TopMenu = new DevExpress.XtraBars.Bar();
            this.btn_Sound = new DevExpress.XtraBars.BarButtonItem();
            this.mnu_Sound = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btn_AddSoundTop = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SettingsForm = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Help = new DevExpress.XtraBars.BarButtonItem();
            this.mnu_Help = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btn_About = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pgb_SoundProgress = new DevExpress.XtraEditors.ProgressBarControl();
            this.pnl_SoundPlay = new DevExpress.XtraEditors.PanelControl();
            this.ctx_AudioStatus = new DevExpress.XtraEditors.LabelControl();
            this.ctx_CurrentSoundName = new DevExpress.XtraEditors.LabelControl();
            this.ctx_SoundDuration = new DevExpress.XtraEditors.LabelControl();
            this.btn_Previous = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Next = new DevExpress.XtraEditors.SimpleButton();
            this.btn_PlayPause = new DevExpress.XtraEditors.SimpleButton();
            this.pnl_OpButtons = new DevExpress.XtraEditors.PanelControl();
            this.btn_PlayFromSpeaker = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DeleteSound = new DevExpress.XtraEditors.SimpleButton();
            this.btn_AddSound = new DevExpress.XtraEditors.SimpleButton();
            this.dgv_SoundsList = new DevExpress.XtraGrid.GridControl();
            this.grv_Main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.jds_SoundSource = new DevExpress.DataAccess.Json.JsonDataSource(this.components);
            this.pnl_SoundsList = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.brm_TopBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnu_Sound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnu_Help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgb_SoundProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_SoundPlay)).BeginInit();
            this.pnl_SoundPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_OpButtons)).BeginInit();
            this.pnl_OpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SoundsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_SoundsList)).BeginInit();
            this.pnl_SoundsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // brm_TopBar
            // 
            this.brm_TopBar.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar_TopMenu});
            this.brm_TopBar.DockControls.Add(this.barDockControlTop);
            this.brm_TopBar.DockControls.Add(this.barDockControlBottom);
            this.brm_TopBar.DockControls.Add(this.barDockControlLeft);
            this.brm_TopBar.DockControls.Add(this.barDockControlRight);
            this.brm_TopBar.Form = this;
            this.brm_TopBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Sound,
            this.btn_Help,
            this.btn_AddSoundTop,
            this.btn_SettingsForm,
            this.btn_About});
            this.brm_TopBar.MainMenu = this.bar_TopMenu;
            this.brm_TopBar.MaxItemId = 5;
            // 
            // bar_TopMenu
            // 
            this.bar_TopMenu.BarName = "Main menu";
            this.bar_TopMenu.DockCol = 0;
            this.bar_TopMenu.DockRow = 0;
            this.bar_TopMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar_TopMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Sound),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Help)});
            this.bar_TopMenu.OptionsBar.AllowQuickCustomization = false;
            this.bar_TopMenu.OptionsBar.DrawBorder = false;
            this.bar_TopMenu.OptionsBar.DrawDragBorder = false;
            this.bar_TopMenu.OptionsBar.UseWholeRow = true;
            this.bar_TopMenu.Text = "Main menu";
            // 
            // btn_Sound
            // 
            this.btn_Sound.ActAsDropDown = true;
            this.btn_Sound.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btn_Sound.Caption = "Sound";
            this.btn_Sound.DropDownControl = this.mnu_Sound;
            this.btn_Sound.Id = 0;
            this.btn_Sound.Name = "btn_Sound";
            // 
            // mnu_Sound
            // 
            this.mnu_Sound.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_AddSoundTop),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SettingsForm)});
            this.mnu_Sound.Manager = this.brm_TopBar;
            this.mnu_Sound.Name = "mnu_Sound";
            // 
            // btn_AddSoundTop
            // 
            this.btn_AddSoundTop.Caption = "Add Sound";
            this.btn_AddSoundTop.Id = 2;
            this.btn_AddSoundTop.Name = "btn_AddSoundTop";
            this.btn_AddSoundTop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_AddSoundTop_ItemClick);
            // 
            // btn_SettingsForm
            // 
            this.btn_SettingsForm.Caption = "Settings";
            this.btn_SettingsForm.Id = 3;
            this.btn_SettingsForm.Name = "btn_SettingsForm";
            this.btn_SettingsForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SettingsForm_ItemClick);
            // 
            // btn_Help
            // 
            this.btn_Help.ActAsDropDown = true;
            this.btn_Help.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btn_Help.Caption = "Help";
            this.btn_Help.DropDownControl = this.mnu_Help;
            this.btn_Help.Id = 1;
            this.btn_Help.Name = "btn_Help";
            // 
            // mnu_Help
            // 
            this.mnu_Help.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_About)});
            this.mnu_Help.Manager = this.brm_TopBar;
            this.mnu_Help.Name = "mnu_Help";
            // 
            // btn_About
            // 
            this.btn_About.Caption = "About";
            this.btn_About.Id = 4;
            this.btn_About.Name = "btn_About";
            this.btn_About.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_About_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.brm_TopBar;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(804, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 655);
            this.barDockControlBottom.Manager = this.brm_TopBar;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(804, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.brm_TopBar;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 635);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(804, 20);
            this.barDockControlRight.Manager = this.brm_TopBar;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 635);
            // 
            // pgb_SoundProgress
            // 
            this.pgb_SoundProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgb_SoundProgress.Location = new System.Drawing.Point(5, 5);
            this.pgb_SoundProgress.MenuManager = this.brm_TopBar;
            this.pgb_SoundProgress.Name = "pgb_SoundProgress";
            this.pgb_SoundProgress.Size = new System.Drawing.Size(770, 10);
            this.pgb_SoundProgress.TabIndex = 5;
            // 
            // pnl_SoundPlay
            // 
            this.pnl_SoundPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_SoundPlay.Controls.Add(this.ctx_AudioStatus);
            this.pnl_SoundPlay.Controls.Add(this.ctx_CurrentSoundName);
            this.pnl_SoundPlay.Controls.Add(this.ctx_SoundDuration);
            this.pnl_SoundPlay.Controls.Add(this.btn_Previous);
            this.pnl_SoundPlay.Controls.Add(this.btn_Next);
            this.pnl_SoundPlay.Controls.Add(this.btn_PlayPause);
            this.pnl_SoundPlay.Controls.Add(this.pgb_SoundProgress);
            this.pnl_SoundPlay.Location = new System.Drawing.Point(12, 496);
            this.pnl_SoundPlay.Name = "pnl_SoundPlay";
            this.pnl_SoundPlay.Size = new System.Drawing.Size(780, 63);
            this.pnl_SoundPlay.TabIndex = 6;
            // 
            // ctx_AudioStatus
            // 
            this.ctx_AudioStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ctx_AudioStatus.Location = new System.Drawing.Point(140, 42);
            this.ctx_AudioStatus.Name = "ctx_AudioStatus";
            this.ctx_AudioStatus.Size = new System.Drawing.Size(24, 13);
            this.ctx_AudioStatus.TabIndex = 10;
            this.ctx_AudioStatus.Text = "XXXX";
            // 
            // ctx_CurrentSoundName
            // 
            this.ctx_CurrentSoundName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ctx_CurrentSoundName.Location = new System.Drawing.Point(140, 21);
            this.ctx_CurrentSoundName.Name = "ctx_CurrentSoundName";
            this.ctx_CurrentSoundName.Size = new System.Drawing.Size(24, 13);
            this.ctx_CurrentSoundName.TabIndex = 9;
            this.ctx_CurrentSoundName.Text = "XXXX";
            // 
            // ctx_SoundDuration
            // 
            this.ctx_SoundDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctx_SoundDuration.Location = new System.Drawing.Point(747, 44);
            this.ctx_SoundDuration.Name = "ctx_SoundDuration";
            this.ctx_SoundDuration.Size = new System.Drawing.Size(28, 13);
            this.ctx_SoundDuration.TabIndex = 8;
            this.ctx_SoundDuration.Text = "00:00";
            // 
            // btn_Previous
            // 
            this.btn_Previous.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Previous.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Previous.ImageOptions.SvgImage")));
            this.btn_Previous.Location = new System.Drawing.Point(5, 21);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(39, 36);
            this.btn_Previous.TabIndex = 7;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Next.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Next.ImageOptions.SvgImage")));
            this.btn_Next.Location = new System.Drawing.Point(95, 21);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(39, 36);
            this.btn_Next.TabIndex = 7;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_PlayPause
            // 
            this.btn_PlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PlayPause.ImageOptions.SvgImage = global::Sesuruk.Properties.Resources.next;
            this.btn_PlayPause.Location = new System.Drawing.Point(50, 21);
            this.btn_PlayPause.Name = "btn_PlayPause";
            this.btn_PlayPause.Size = new System.Drawing.Size(39, 36);
            this.btn_PlayPause.TabIndex = 6;
            this.btn_PlayPause.Click += new System.EventHandler(this.btn_PlayPause_Click);
            // 
            // pnl_OpButtons
            // 
            this.pnl_OpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_OpButtons.Controls.Add(this.btn_PlayFromSpeaker);
            this.pnl_OpButtons.Controls.Add(this.btn_DeleteSound);
            this.pnl_OpButtons.Controls.Add(this.btn_AddSound);
            this.pnl_OpButtons.Location = new System.Drawing.Point(12, 565);
            this.pnl_OpButtons.Name = "pnl_OpButtons";
            this.pnl_OpButtons.Size = new System.Drawing.Size(780, 78);
            this.pnl_OpButtons.TabIndex = 7;
            // 
            // btn_PlayFromSpeaker
            // 
            this.btn_PlayFromSpeaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_PlayFromSpeaker.ImageOptions.SvgImage = global::Sesuruk.Properties.Resources.Headphone;
            this.btn_PlayFromSpeaker.Location = new System.Drawing.Point(5, 23);
            this.btn_PlayFromSpeaker.Name = "btn_PlayFromSpeaker";
            this.btn_PlayFromSpeaker.Size = new System.Drawing.Size(39, 36);
            this.btn_PlayFromSpeaker.TabIndex = 12;
            this.btn_PlayFromSpeaker.ToolTip = "Play sound from speakers also";
            this.btn_PlayFromSpeaker.Click += new System.EventHandler(this.btn_PlayFromSpeaker_Click);
            // 
            // btn_DeleteSound
            // 
            this.btn_DeleteSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_DeleteSound.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_DeleteSound.ImageOptions.SvgImage")));
            this.btn_DeleteSound.Location = new System.Drawing.Point(387, 23);
            this.btn_DeleteSound.Name = "btn_DeleteSound";
            this.btn_DeleteSound.Size = new System.Drawing.Size(39, 36);
            this.btn_DeleteSound.TabIndex = 11;
            this.btn_DeleteSound.ToolTip = "Remove sound";
            this.btn_DeleteSound.Click += new System.EventHandler(this.btn_DeleteSound_Click);
            // 
            // btn_AddSound
            // 
            this.btn_AddSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_AddSound.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_AddSound.ImageOptions.SvgImage")));
            this.btn_AddSound.Location = new System.Drawing.Point(329, 23);
            this.btn_AddSound.Name = "btn_AddSound";
            this.btn_AddSound.Size = new System.Drawing.Size(39, 36);
            this.btn_AddSound.TabIndex = 10;
            this.btn_AddSound.ToolTip = "Add new sound";
            this.btn_AddSound.Click += new System.EventHandler(this.btn_AddSound_Click);
            // 
            // dgv_SoundsList
            // 
            this.dgv_SoundsList.DataSource = typeof(Sesuruk.Functions.Sound);
            this.dgv_SoundsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SoundsList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.dgv_SoundsList.Location = new System.Drawing.Point(2, 2);
            this.dgv_SoundsList.MainView = this.grv_Main;
            this.dgv_SoundsList.MenuManager = this.brm_TopBar;
            this.dgv_SoundsList.Name = "dgv_SoundsList";
            this.dgv_SoundsList.Size = new System.Drawing.Size(776, 459);
            this.dgv_SoundsList.TabIndex = 18;
            this.dgv_SoundsList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_Main});
            this.dgv_SoundsList.Click += new System.EventHandler(this.dgv_SoundsList_Click);
            // 
            // grv_Main
            // 
            this.grv_Main.GridControl = this.dgv_SoundsList;
            this.grv_Main.Name = "grv_Main";
            this.grv_Main.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grv_Main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grv_Main.OptionsBehavior.Editable = false;
            this.grv_Main.OptionsBehavior.ReadOnly = true;
            // 
            // jds_SoundSource
            // 
            this.jds_SoundSource.Name = "jds_SoundSource";
            // 
            // pnl_SoundsList
            // 
            this.pnl_SoundsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_SoundsList.Controls.Add(this.dgv_SoundsList);
            this.pnl_SoundsList.Location = new System.Drawing.Point(12, 27);
            this.pnl_SoundsList.Name = "pnl_SoundsList";
            this.pnl_SoundsList.Size = new System.Drawing.Size(780, 463);
            this.pnl_SoundsList.TabIndex = 23;
            // 
            // FormMain
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 655);
            this.Controls.Add(this.pnl_SoundsList);
            this.Controls.Add(this.pnl_OpButtons);
            this.Controls.Add(this.pnl_SoundPlay);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.IconOptions.Image = global::Sesuruk.Properties.Resources.Sesuruk;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(476, 687);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sesuruk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brm_TopBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnu_Sound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnu_Help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgb_SoundProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_SoundPlay)).EndInit();
            this.pnl_SoundPlay.ResumeLayout(false);
            this.pnl_SoundPlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_OpButtons)).EndInit();
            this.pnl_OpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SoundsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_SoundsList)).EndInit();
            this.pnl_SoundsList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager brm_TopBar;
        private DevExpress.XtraBars.Bar bar_TopMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btn_Sound;
        private DevExpress.XtraBars.BarButtonItem btn_Help;
        private DevExpress.XtraEditors.PanelControl pnl_SoundPlay;
        private DevExpress.XtraEditors.ProgressBarControl pgb_SoundProgress;
        private DevExpress.XtraEditors.SimpleButton btn_PlayPause;
        private DevExpress.XtraEditors.SimpleButton btn_Previous;
        private DevExpress.XtraEditors.SimpleButton btn_Next;
        private DevExpress.XtraEditors.LabelControl ctx_SoundDuration;
        private DevExpress.XtraEditors.LabelControl ctx_CurrentSoundName;
        private DevExpress.XtraEditors.PanelControl pnl_OpButtons;
        private DevExpress.XtraEditors.SimpleButton btn_DeleteSound;
        private DevExpress.XtraEditors.SimpleButton btn_AddSound;
        private DevExpress.XtraEditors.LabelControl ctx_AudioStatus;
        private DevExpress.XtraBars.PopupMenu mnu_Sound;
        private DevExpress.XtraBars.PopupMenu mnu_Help;
        private DevExpress.XtraBars.BarButtonItem btn_AddSoundTop;
        private DevExpress.XtraBars.BarButtonItem btn_SettingsForm;
        private DevExpress.XtraBars.BarButtonItem btn_About;
        private DevExpress.XtraGrid.GridControl dgv_SoundsList;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_Main;
        private DevExpress.DataAccess.Json.JsonDataSource jds_SoundSource;
        private DevExpress.XtraEditors.PanelControl pnl_SoundsList;
        private DevExpress.XtraEditors.SimpleButton btn_PlayFromSpeaker;
    }
}

