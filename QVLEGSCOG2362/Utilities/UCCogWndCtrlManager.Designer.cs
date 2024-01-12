namespace QVLEGSCOG2362
{
    partial class UCCogWndCtrlManager
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCogWndCtrlManager));
            this.panel = new System.Windows.Forms.Panel();
            this.btnOpenMenu = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnResetZoom = new System.Windows.Forms.Button();
            this.btnZoomMeno = new System.Windows.Forms.Button();
            this.chbAnnotazioni = new System.Windows.Forms.CheckBox();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnZoomPiu = new System.Windows.Forms.Button();
            this.chbMuovi = new System.Windows.Forms.CheckBox();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.panel.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnOpenMenu);
            this.panel.Controls.Add(this.panelMenu);
            this.panel.Controls.Add(this.cogRecordDisplay1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(441, 396);
            this.panel.TabIndex = 1;
            // 
            // btnOpenMenu
            // 
            this.btnOpenMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenMenu.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.menuSmall;
            this.btnOpenMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpenMenu.FlatAppearance.BorderSize = 0;
            this.btnOpenMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMenu.Location = new System.Drawing.Point(401, 0);
            this.btnOpenMenu.Name = "btnOpenMenu";
            this.btnOpenMenu.Size = new System.Drawing.Size(40, 40);
            this.btnOpenMenu.TabIndex = 0;
            this.btnOpenMenu.UseVisualStyleBackColor = false;
            this.btnOpenMenu.Click += new System.EventHandler(this.btnOpenMenu_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.Controls.Add(this.btnSalva);
            this.panelMenu.Controls.Add(this.btnResetZoom);
            this.panelMenu.Controls.Add(this.btnZoomMeno);
            this.panelMenu.Controls.Add(this.chbAnnotazioni);
            this.panelMenu.Controls.Add(this.btnChiudi);
            this.panelMenu.Controls.Add(this.btnZoomPiu);
            this.panelMenu.Controls.Add(this.chbMuovi);
            this.panelMenu.Location = new System.Drawing.Point(193, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(247, 87);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Visible = false;
            this.panelMenu.MouseLeave += new System.EventHandler(this.panelMenu_MouseLeave);
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSalva.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.btnSave_Image;
            this.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalva.FlatAppearance.BorderSize = 0;
            this.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalva.Location = new System.Drawing.Point(11, 3);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(40, 40);
            this.btnSalva.TabIndex = 60;
            this.btnSalva.UseVisualStyleBackColor = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetZoom.BackColor = System.Drawing.Color.Gainsboro;
            this.btnResetZoom.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.zoom_fit_Size;
            this.btnResetZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetZoom.FlatAppearance.BorderSize = 0;
            this.btnResetZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetZoom.Location = new System.Drawing.Point(155, 3);
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(40, 40);
            this.btnResetZoom.TabIndex = 55;
            this.btnResetZoom.UseVisualStyleBackColor = false;
            this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
            // 
            // btnZoomMeno
            // 
            this.btnZoomMeno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomMeno.BackColor = System.Drawing.Color.Gainsboro;
            this.btnZoomMeno.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.zoom_out_1;
            this.btnZoomMeno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomMeno.FlatAppearance.BorderSize = 0;
            this.btnZoomMeno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomMeno.Location = new System.Drawing.Point(106, 3);
            this.btnZoomMeno.Name = "btnZoomMeno";
            this.btnZoomMeno.Size = new System.Drawing.Size(40, 40);
            this.btnZoomMeno.TabIndex = 54;
            this.btnZoomMeno.UseVisualStyleBackColor = false;
            this.btnZoomMeno.Click += new System.EventHandler(this.btnZoomMeno_Click);
            // 
            // chbAnnotazioni
            // 
            this.chbAnnotazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAnnotazioni.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.info2_48x48;
            this.chbAnnotazioni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chbAnnotazioni.Checked = true;
            this.chbAnnotazioni.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAnnotazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAnnotazioni.Location = new System.Drawing.Point(80, 46);
            this.chbAnnotazioni.Name = "chbAnnotazioni";
            this.chbAnnotazioni.Size = new System.Drawing.Size(80, 33);
            this.chbAnnotazioni.TabIndex = 57;
            this.chbAnnotazioni.Text = "            ";
            this.chbAnnotazioni.UseVisualStyleBackColor = true;
            this.chbAnnotazioni.CheckedChanged += new System.EventHandler(this.chbAnnotazioni_CheckedChanged);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.chiudi;
            this.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChiudi.FlatAppearance.BorderSize = 0;
            this.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiudi.Location = new System.Drawing.Point(204, 3);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(40, 40);
            this.btnChiudi.TabIndex = 59;
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnZoomPiu
            // 
            this.btnZoomPiu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomPiu.BackColor = System.Drawing.Color.Gainsboro;
            this.btnZoomPiu.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.zoom_in_1;
            this.btnZoomPiu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZoomPiu.FlatAppearance.BorderSize = 0;
            this.btnZoomPiu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomPiu.Location = new System.Drawing.Point(57, 3);
            this.btnZoomPiu.Name = "btnZoomPiu";
            this.btnZoomPiu.Size = new System.Drawing.Size(40, 40);
            this.btnZoomPiu.TabIndex = 53;
            this.btnZoomPiu.UseVisualStyleBackColor = false;
            this.btnZoomPiu.Click += new System.EventHandler(this.btnZoomPiu_Click);
            // 
            // chbMuovi
            // 
            this.chbMuovi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbMuovi.AutoSize = true;
            this.chbMuovi.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.move2;
            this.chbMuovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chbMuovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMuovi.Location = new System.Drawing.Point(175, 46);
            this.chbMuovi.Name = "chbMuovi";
            this.chbMuovi.Size = new System.Drawing.Size(80, 33);
            this.chbMuovi.TabIndex = 56;
            this.chbMuovi.Text = "        ";
            this.chbMuovi.UseVisualStyleBackColor = true;
            this.chbMuovi.CheckedChanged += new System.EventHandler(this.chbMuovi_CheckedChanged);
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(0, 0);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(441, 396);
            this.cogRecordDisplay1.TabIndex = 1;
            // 
            // UCCogWndCtrlManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "UCCogWndCtrlManager";
            this.Size = new System.Drawing.Size(441, 396);
            this.panel.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnOpenMenu;
        private System.Windows.Forms.Button btnZoomMeno;
        private System.Windows.Forms.Button btnResetZoom;
        private System.Windows.Forms.Button btnZoomPiu;
        private System.Windows.Forms.CheckBox chbMuovi;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.CheckBox chbAnnotazioni;
        private System.Windows.Forms.Button btnSalva;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
    }
}
