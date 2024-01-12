namespace QVLEGSCOG2362.Pagine
{
    partial class UCPaginaOnLine2Cam
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
            this.ucTabControl1 = new QVLEGSCOG2362.UCTabControl();
            this.tabPageGenerale = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.panelCamera1 = new System.Windows.Forms.Panel();
            this.panelCamera2 = new System.Windows.Forms.Panel();
            this.lblCam2 = new System.Windows.Forms.Label();
            this.tabPageSingola = new System.Windows.Forms.TabPage();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ucTabControl1.SuspendLayout();
            this.tabPageGenerale.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageSingola.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // ucTabControl1
            // 
            this.ucTabControl1.Controls.Add(this.tabPageGenerale);
            this.ucTabControl1.Controls.Add(this.tabPageSingola);
            this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabControl1.HideTab = true;
            this.ucTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ucTabControl1.Name = "ucTabControl1";
            this.ucTabControl1.SelectedIndex = 0;
            this.ucTabControl1.Size = new System.Drawing.Size(1066, 600);
            this.ucTabControl1.TabIndex = 43;
            // 
            // tabPageGenerale
            // 
            this.tabPageGenerale.Controls.Add(this.tableLayoutPanel1);
            this.tabPageGenerale.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenerale.Name = "tabPageGenerale";
            this.tabPageGenerale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGenerale.Size = new System.Drawing.Size(1058, 574);
            this.tabPageGenerale.TabIndex = 0;
            this.tabPageGenerale.Text = "Generale";
            this.tabPageGenerale.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblCam1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelCamera1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelCamera2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCam2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1052, 568);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCam1
            // 
            this.lblCam1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCam1.AutoSize = true;
            this.lblCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam1.Location = new System.Drawing.Point(207, 1);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(111, 20);
            this.lblCam1.TabIndex = 0;
            this.lblCam1.Text = "BTN_CAM_1";
            // 
            // panelCamera1
            // 
            this.panelCamera1.BackColor = System.Drawing.Color.White;
            this.panelCamera1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCamera1.Location = new System.Drawing.Point(3, 25);
            this.panelCamera1.Name = "panelCamera1";
            this.panelCamera1.Size = new System.Drawing.Size(520, 540);
            this.panelCamera1.TabIndex = 11;
            // 
            // panelCamera2
            // 
            this.panelCamera2.BackColor = System.Drawing.Color.White;
            this.panelCamera2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCamera2.Location = new System.Drawing.Point(529, 25);
            this.panelCamera2.Name = "panelCamera2";
            this.panelCamera2.Size = new System.Drawing.Size(520, 540);
            this.panelCamera2.TabIndex = 10;
            // 
            // lblCam2
            // 
            this.lblCam2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCam2.AutoSize = true;
            this.lblCam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam2.Location = new System.Drawing.Point(733, 1);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(111, 20);
            this.lblCam2.TabIndex = 1;
            this.lblCam2.Text = "BTN_CAM_2";
            // 
            // tabPageSingola
            // 
            this.tabPageSingola.Controls.Add(this.pictureBox6);
            this.tabPageSingola.Controls.Add(this.tableLayoutPanel2);
            this.tabPageSingola.Location = new System.Drawing.Point(4, 22);
            this.tabPageSingola.Name = "tabPageSingola";
            this.tabPageSingola.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSingola.Size = new System.Drawing.Size(1058, 574);
            this.tabPageSingola.TabIndex = 1;
            this.tabPageSingola.Text = "Singola";
            this.tabPageSingola.UseVisualStyleBackColor = true;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.Automation;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Location = new System.Drawing.Point(3, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(1052, 568);
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1034, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(222, 582);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // UCPaginaOnLine2Cam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucTabControl1);
            this.Name = "UCPaginaOnLine2Cam";
            this.Size = new System.Drawing.Size(1066, 600);
            this.ucTabControl1.ResumeLayout(false);
            this.tabPageGenerale.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageSingola.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UCTabControl ucTabControl1;
        private System.Windows.Forms.TabPage tabPageGenerale;
        private System.Windows.Forms.TabPage tabPageSingola;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelCamera2;
        private System.Windows.Forms.Panel panelCamera1;
        private System.Windows.Forms.Label lblCam1;
        private System.Windows.Forms.Label lblCam2;
    }
}
