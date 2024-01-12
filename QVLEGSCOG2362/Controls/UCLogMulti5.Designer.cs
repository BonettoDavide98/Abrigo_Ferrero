namespace QVLEGSCOG2362
{
    partial class UCLogMulti5
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnIngrandisci = new System.Windows.Forms.Button();
            this.btnDescrizione = new System.Windows.Forms.Button();
            this.btnImage = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ucTabControl = new QVLEGSCOG2362.UCTabControl();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCam5 = new System.Windows.Forms.Label();
            this.panelImage5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCam4 = new System.Windows.Forms.Label();
            this.panelImage4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCam3 = new System.Windows.Forms.Label();
            this.panelImage3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCam2 = new System.Windows.Forms.Label();
            this.panelImage2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.panelImage1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageDescrizione = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRagioneScarto5 = new System.Windows.Forms.Label();
            this.lblRagioneScarto4 = new System.Windows.Forms.Label();
            this.lblRagioneScarto3 = new System.Windows.Forms.Label();
            this.lblRagioneScarto2 = new System.Windows.Forms.Label();
            this.lblRagioneScarto1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.ucTabControl.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageDescrizione.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(965, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2020-11-12 09:00";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ucTabControl, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(959, 151);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnIngrandisci);
            this.panel6.Controls.Add(this.btnDescrizione);
            this.panel6.Controls.Add(this.btnImage);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(54, 145);
            this.panel6.TabIndex = 3;
            // 
            // btnIngrandisci
            // 
            this.btnIngrandisci.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.img_ingrandisci;
            this.btnIngrandisci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIngrandisci.Location = new System.Drawing.Point(7, 92);
            this.btnIngrandisci.Name = "btnIngrandisci";
            this.btnIngrandisci.Size = new System.Drawing.Size(40, 40);
            this.btnIngrandisci.TabIndex = 2;
            this.btnIngrandisci.UseVisualStyleBackColor = true;
            this.btnIngrandisci.Click += new System.EventHandler(this.btnIngrandisci_Click);
            // 
            // btnDescrizione
            // 
            this.btnDescrizione.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.img_text;
            this.btnDescrizione.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDescrizione.Location = new System.Drawing.Point(7, 49);
            this.btnDescrizione.Name = "btnDescrizione";
            this.btnDescrizione.Size = new System.Drawing.Size(40, 40);
            this.btnDescrizione.TabIndex = 1;
            this.btnDescrizione.UseVisualStyleBackColor = true;
            this.btnDescrizione.Click += new System.EventHandler(this.btnDescrizione_Click);
            // 
            // btnImage
            // 
            this.btnImage.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.iconfinder_icon_image_211677_1_;
            this.btnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImage.Location = new System.Drawing.Point(7, 7);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(40, 40);
            this.btnImage.TabIndex = 0;
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // ucTabControl
            // 
            this.ucTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.ucTabControl.Controls.Add(this.tabPageImage);
            this.ucTabControl.Controls.Add(this.tabPageDescrizione);
            this.ucTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabControl.HideTab = true;
            this.ucTabControl.Location = new System.Drawing.Point(63, 3);
            this.ucTabControl.Multiline = true;
            this.ucTabControl.Name = "ucTabControl";
            this.ucTabControl.SelectedIndex = 0;
            this.ucTabControl.Size = new System.Drawing.Size(893, 145);
            this.ucTabControl.TabIndex = 2;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.tableLayoutPanel1);
            this.tabPageImage.Location = new System.Drawing.Point(23, 4);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(866, 137);
            this.tabPageImage.TabIndex = 0;
            this.tabPageImage.Text = "Img";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 131);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.lblCam5);
            this.panel5.Controls.Add(this.panelImage5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(520, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(130, 131);
            this.panel5.TabIndex = 9;
            // 
            // lblCam5
            // 
            this.lblCam5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCam5.Location = new System.Drawing.Point(5, 0);
            this.lblCam5.Name = "lblCam5";
            this.lblCam5.Size = new System.Drawing.Size(117, 23);
            this.lblCam5.TabIndex = 9;
            this.lblCam5.Text = "BTN_CAM_5";
            this.lblCam5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImage5
            // 
            this.panelImage5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage5.BackColor = System.Drawing.Color.Transparent;
            this.panelImage5.Location = new System.Drawing.Point(8, 27);
            this.panelImage5.Margin = new System.Windows.Forms.Padding(8);
            this.panelImage5.Name = "panelImage5";
            this.panelImage5.Size = new System.Drawing.Size(114, 99);
            this.panelImage5.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.lblCam4);
            this.panel4.Controls.Add(this.panelImage4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(390, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(130, 131);
            this.panel4.TabIndex = 9;
            // 
            // lblCam4
            // 
            this.lblCam4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCam4.Location = new System.Drawing.Point(5, 0);
            this.lblCam4.Name = "lblCam4";
            this.lblCam4.Size = new System.Drawing.Size(117, 23);
            this.lblCam4.TabIndex = 9;
            this.lblCam4.Text = "BTN_CAM_4";
            this.lblCam4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImage4
            // 
            this.panelImage4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage4.BackColor = System.Drawing.Color.Transparent;
            this.panelImage4.Location = new System.Drawing.Point(8, 27);
            this.panelImage4.Margin = new System.Windows.Forms.Padding(8);
            this.panelImage4.Name = "panelImage4";
            this.panelImage4.Size = new System.Drawing.Size(114, 99);
            this.panelImage4.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.lblCam3);
            this.panel3.Controls.Add(this.panelImage3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(260, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 131);
            this.panel3.TabIndex = 8;
            // 
            // lblCam3
            // 
            this.lblCam3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCam3.Location = new System.Drawing.Point(5, 0);
            this.lblCam3.Name = "lblCam3";
            this.lblCam3.Size = new System.Drawing.Size(117, 23);
            this.lblCam3.TabIndex = 8;
            this.lblCam3.Text = "BTN_CAM_3";
            this.lblCam3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImage3
            // 
            this.panelImage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage3.BackColor = System.Drawing.Color.Transparent;
            this.panelImage3.Location = new System.Drawing.Point(8, 27);
            this.panelImage3.Margin = new System.Windows.Forms.Padding(8);
            this.panelImage3.Name = "panelImage3";
            this.panelImage3.Size = new System.Drawing.Size(114, 99);
            this.panelImage3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lblCam2);
            this.panel2.Controls.Add(this.panelImage2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(130, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 131);
            this.panel2.TabIndex = 8;
            // 
            // lblCam2
            // 
            this.lblCam2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCam2.Location = new System.Drawing.Point(5, 0);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(117, 23);
            this.lblCam2.TabIndex = 8;
            this.lblCam2.Text = "BTN_CAM_2";
            this.lblCam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImage2
            // 
            this.panelImage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage2.BackColor = System.Drawing.Color.Transparent;
            this.panelImage2.Location = new System.Drawing.Point(8, 27);
            this.panelImage2.Margin = new System.Windows.Forms.Padding(8);
            this.panelImage2.Name = "panelImage2";
            this.panelImage2.Size = new System.Drawing.Size(114, 99);
            this.panelImage2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblCam1);
            this.panel1.Controls.Add(this.panelImage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 131);
            this.panel1.TabIndex = 7;
            // 
            // lblCam1
            // 
            this.lblCam1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCam1.Location = new System.Drawing.Point(5, 0);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(117, 23);
            this.lblCam1.TabIndex = 7;
            this.lblCam1.Text = "BTN_CAM_1";
            this.lblCam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImage1
            // 
            this.panelImage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage1.BackColor = System.Drawing.Color.Transparent;
            this.panelImage1.Location = new System.Drawing.Point(8, 27);
            this.panelImage1.Margin = new System.Windows.Forms.Padding(8);
            this.panelImage1.Name = "panelImage1";
            this.panelImage1.Size = new System.Drawing.Size(114, 99);
            this.panelImage1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(653, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 131);
            this.label1.TabIndex = 9;
            this.label1.Text = "MOTIVO SCARTO";
            // 
            // tabPageDescrizione
            // 
            this.tabPageDescrizione.Controls.Add(this.tableLayoutPanel2);
            this.tabPageDescrizione.Location = new System.Drawing.Point(23, 4);
            this.tabPageDescrizione.Name = "tabPageDescrizione";
            this.tabPageDescrizione.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDescrizione.Size = new System.Drawing.Size(866, 164);
            this.tabPageDescrizione.TabIndex = 1;
            this.tabPageDescrizione.Text = "Descr";
            this.tabPageDescrizione.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel2.Controls.Add(this.lblRagioneScarto5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRagioneScarto4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRagioneScarto3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRagioneScarto2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRagioneScarto1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(860, 158);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblRagioneScarto5
            // 
            this.lblRagioneScarto5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRagioneScarto5.BackColor = System.Drawing.SystemColors.Control;
            this.lblRagioneScarto5.ForeColor = System.Drawing.Color.Red;
            this.lblRagioneScarto5.Location = new System.Drawing.Point(527, 0);
            this.lblRagioneScarto5.Name = "lblRagioneScarto5";
            this.lblRagioneScarto5.Size = new System.Drawing.Size(125, 158);
            this.lblRagioneScarto5.TabIndex = 4;
            this.lblRagioneScarto5.Text = "MOTIVO SCARTO";
            // 
            // lblRagioneScarto4
            // 
            this.lblRagioneScarto4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRagioneScarto4.BackColor = System.Drawing.SystemColors.Control;
            this.lblRagioneScarto4.ForeColor = System.Drawing.Color.Red;
            this.lblRagioneScarto4.Location = new System.Drawing.Point(396, 0);
            this.lblRagioneScarto4.Name = "lblRagioneScarto4";
            this.lblRagioneScarto4.Size = new System.Drawing.Size(125, 158);
            this.lblRagioneScarto4.TabIndex = 3;
            this.lblRagioneScarto4.Text = "MOTIVO SCARTO";
            // 
            // lblRagioneScarto3
            // 
            this.lblRagioneScarto3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRagioneScarto3.BackColor = System.Drawing.SystemColors.Control;
            this.lblRagioneScarto3.ForeColor = System.Drawing.Color.Red;
            this.lblRagioneScarto3.Location = new System.Drawing.Point(265, 0);
            this.lblRagioneScarto3.Name = "lblRagioneScarto3";
            this.lblRagioneScarto3.Size = new System.Drawing.Size(125, 158);
            this.lblRagioneScarto3.TabIndex = 2;
            this.lblRagioneScarto3.Text = "MOTIVO SCARTO";
            // 
            // lblRagioneScarto2
            // 
            this.lblRagioneScarto2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRagioneScarto2.BackColor = System.Drawing.SystemColors.Control;
            this.lblRagioneScarto2.ForeColor = System.Drawing.Color.Red;
            this.lblRagioneScarto2.Location = new System.Drawing.Point(134, 0);
            this.lblRagioneScarto2.Name = "lblRagioneScarto2";
            this.lblRagioneScarto2.Size = new System.Drawing.Size(125, 158);
            this.lblRagioneScarto2.TabIndex = 0;
            this.lblRagioneScarto2.Text = "MOTIVO SCARTO";
            // 
            // lblRagioneScarto1
            // 
            this.lblRagioneScarto1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRagioneScarto1.BackColor = System.Drawing.SystemColors.Control;
            this.lblRagioneScarto1.ForeColor = System.Drawing.Color.Red;
            this.lblRagioneScarto1.Location = new System.Drawing.Point(3, 0);
            this.lblRagioneScarto1.Name = "lblRagioneScarto1";
            this.lblRagioneScarto1.Size = new System.Drawing.Size(125, 158);
            this.lblRagioneScarto1.TabIndex = 1;
            this.lblRagioneScarto1.Text = "MOTIVO SCARTO";
            // 
            // UCLogMulti5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCLogMulti5";
            this.Size = new System.Drawing.Size(965, 170);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ucTabControl.ResumeLayout(false);
            this.tabPageImage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPageDescrizione.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelImage1;
        private System.Windows.Forms.Panel panelImage5;
        private System.Windows.Forms.Panel panelImage4;
        private System.Windows.Forms.Panel panelImage3;
        private System.Windows.Forms.Panel panelImage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblRagioneScarto5;
        private System.Windows.Forms.Label lblRagioneScarto4;
        private System.Windows.Forms.Label lblRagioneScarto3;
        private System.Windows.Forms.Label lblRagioneScarto2;
        private System.Windows.Forms.Label lblRagioneScarto1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private UCTabControl ucTabControl;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.TabPage tabPageDescrizione;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnIngrandisci;
        private System.Windows.Forms.Button btnDescrizione;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.Label lblCam5;
        private System.Windows.Forms.Label lblCam4;
        private System.Windows.Forms.Label lblCam3;
        private System.Windows.Forms.Label lblCam2;
        private System.Windows.Forms.Label lblCam1;
    }
}
