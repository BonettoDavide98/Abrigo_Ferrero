namespace QVLEGSCOG2362.Pagine
{
    partial class UCPaginaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPaginaView));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOnline = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnSoglie = new System.Windows.Forms.Button();
            this.btnStatistiche1 = new System.Windows.Forms.Button();
            this.btnStatistiche2 = new System.Windows.Forms.Button();
            this.btnStatistiche3 = new System.Windows.Forms.Button();
            this.btnStatistiche4 = new System.Windows.Forms.Button();
            this.timerAggiornaStatistiche = new System.Windows.Forms.Timer(this.components);
            this.tabControlMain = new QVLEGSCOG2362.UCTabControl();
            this.tabPageOnLine = new System.Windows.Forms.TabPage();
            this.ucPaginaOnLine1 = new QVLEGSCOG2362.Pagine.UCPaginaOnLine();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.ucPaginaViewLog1 = new QVLEGSCOG2362.Pagine.SottoPagine.UCPaginaViewLog();
            this.tabPageSoglie = new System.Windows.Forms.TabPage();
            this.ucPaginaViewSoglie1 = new QVLEGSCOG2362.Pagine.SottoPagine.UCPaginaViewSoglie();
            this.tabPageStatistiche1 = new System.Windows.Forms.TabPage();
            this.ucPaginaViewStat11 = new QVLEGSCOG2362.Pagine.SottoPagine.UCPaginaViewStat1();
            this.tabPageStatistiche2 = new System.Windows.Forms.TabPage();
            this.ucPaginaViewStat21 = new QVLEGSCOG2362.Pagine.SottoPagine.UCPaginaViewStat2();
            this.tabPageStatistiche3 = new System.Windows.Forms.TabPage();
            this.ucPaginaViewStat31 = new QVLEGSCOG2362.Pagine.SottoPagine.UCPaginaViewStat3();
            this.tabPageStatistiche4 = new System.Windows.Forms.TabPage();
            this.ucPaginaViewStat41 = new QVLEGSCOG2362.Pagine.SottoPagine.UCPaginaViewStat4();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageOnLine.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageSoglie.SuspendLayout();
            this.tabPageStatistiche1.SuspendLayout();
            this.tabPageStatistiche2.SuspendLayout();
            this.tabPageStatistiche3.SuspendLayout();
            this.tabPageStatistiche4.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "move2.png");
            this.imageList1.Images.SetKeyName(1, "Ricette.png");
            this.imageList1.Images.SetKeyName(2, "Ricette_Piccola.png");
            this.imageList1.Images.SetKeyName(3, "zoom_fit_Size.png");
            this.imageList1.Images.SetKeyName(4, "zoom_fit_Size1.png");
            this.imageList1.Images.SetKeyName(5, "zoom-in_1.png");
            this.imageList1.Images.SetKeyName(6, "zoom-out_1.png");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnOnline);
            this.flowLayoutPanel1.Controls.Add(this.btnLog);
            this.flowLayoutPanel1.Controls.Add(this.btnSoglie);
            this.flowLayoutPanel1.Controls.Add(this.btnStatistiche1);
            this.flowLayoutPanel1.Controls.Add(this.btnStatistiche2);
            this.flowLayoutPanel1.Controls.Add(this.btnStatistiche3);
            this.flowLayoutPanel1.Controls.Add(this.btnStatistiche4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1201, 62);
            this.flowLayoutPanel1.TabIndex = 89;
            // 
            // btnOnline
            // 
            this.btnOnline.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOnline.BackColor = System.Drawing.Color.White;
            this.btnOnline.FlatAppearance.BorderSize = 0;
            this.btnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnline.Image = global::QVLEGSCOG2362.Properties.Resources.imgScattaFoto;
            this.btnOnline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOnline.Location = new System.Drawing.Point(3, 3);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(145, 50);
            this.btnOnline.TabIndex = 95;
            this.btnOnline.Text = "BTN_ONLINE";
            this.btnOnline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOnline.UseVisualStyleBackColor = false;
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLog.BackColor = System.Drawing.Color.White;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Image = global::QVLEGSCOG2362.Properties.Resources.img_log;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(154, 3);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(145, 50);
            this.btnLog.TabIndex = 90;
            this.btnLog.Text = "BTN_LOG";
            this.btnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnSoglie
            // 
            this.btnSoglie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSoglie.BackColor = System.Drawing.Color.White;
            this.btnSoglie.FlatAppearance.BorderSize = 0;
            this.btnSoglie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoglie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoglie.Image = global::QVLEGSCOG2362.Properties.Resources.img_soglie;
            this.btnSoglie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoglie.Location = new System.Drawing.Point(305, 3);
            this.btnSoglie.Name = "btnSoglie";
            this.btnSoglie.Size = new System.Drawing.Size(145, 50);
            this.btnSoglie.TabIndex = 91;
            this.btnSoglie.Text = "BTN_SOGLIE";
            this.btnSoglie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSoglie.UseVisualStyleBackColor = false;
            this.btnSoglie.Click += new System.EventHandler(this.btnSoglie_Click);
            // 
            // btnStatistiche1
            // 
            this.btnStatistiche1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStatistiche1.BackColor = System.Drawing.Color.White;
            this.btnStatistiche1.FlatAppearance.BorderSize = 0;
            this.btnStatistiche1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistiche1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistiche1.Image = global::QVLEGSCOG2362.Properties.Resources.img_view;
            this.btnStatistiche1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistiche1.Location = new System.Drawing.Point(456, 3);
            this.btnStatistiche1.Name = "btnStatistiche1";
            this.btnStatistiche1.Size = new System.Drawing.Size(145, 50);
            this.btnStatistiche1.TabIndex = 92;
            this.btnStatistiche1.Text = "BTN_STATISTICHE_1";
            this.btnStatistiche1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistiche1.UseVisualStyleBackColor = false;
            this.btnStatistiche1.Click += new System.EventHandler(this.btnStatistiche1_Click);
            // 
            // btnStatistiche2
            // 
            this.btnStatistiche2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStatistiche2.BackColor = System.Drawing.Color.White;
            this.btnStatistiche2.FlatAppearance.BorderSize = 0;
            this.btnStatistiche2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistiche2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistiche2.Image = global::QVLEGSCOG2362.Properties.Resources.img_view;
            this.btnStatistiche2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistiche2.Location = new System.Drawing.Point(607, 3);
            this.btnStatistiche2.Name = "btnStatistiche2";
            this.btnStatistiche2.Size = new System.Drawing.Size(145, 50);
            this.btnStatistiche2.TabIndex = 93;
            this.btnStatistiche2.Text = "BTN_STATISTICHE_2";
            this.btnStatistiche2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistiche2.UseVisualStyleBackColor = false;
            this.btnStatistiche2.Click += new System.EventHandler(this.btnStatistiche2_Click);
            // 
            // btnStatistiche3
            // 
            this.btnStatistiche3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStatistiche3.BackColor = System.Drawing.Color.White;
            this.btnStatistiche3.FlatAppearance.BorderSize = 0;
            this.btnStatistiche3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistiche3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistiche3.Image = global::QVLEGSCOG2362.Properties.Resources.img_view;
            this.btnStatistiche3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistiche3.Location = new System.Drawing.Point(758, 3);
            this.btnStatistiche3.Name = "btnStatistiche3";
            this.btnStatistiche3.Size = new System.Drawing.Size(145, 50);
            this.btnStatistiche3.TabIndex = 94;
            this.btnStatistiche3.Text = "BTN_STATISTICHE_3";
            this.btnStatistiche3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistiche3.UseVisualStyleBackColor = false;
            this.btnStatistiche3.Click += new System.EventHandler(this.btnStatistiche3_Click);
            // 
            // btnStatistiche4
            // 
            this.btnStatistiche4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStatistiche4.BackColor = System.Drawing.Color.White;
            this.btnStatistiche4.FlatAppearance.BorderSize = 0;
            this.btnStatistiche4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistiche4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistiche4.Image = global::QVLEGSCOG2362.Properties.Resources.img_view;
            this.btnStatistiche4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistiche4.Location = new System.Drawing.Point(909, 3);
            this.btnStatistiche4.Name = "btnStatistiche4";
            this.btnStatistiche4.Size = new System.Drawing.Size(145, 50);
            this.btnStatistiche4.TabIndex = 96;
            this.btnStatistiche4.Text = "BTN_STATISTICHE_4";
            this.btnStatistiche4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistiche4.UseVisualStyleBackColor = false;
            this.btnStatistiche4.Click += new System.EventHandler(this.btnStatistiche4_Click);
            // 
            // timerAggiornaStatistiche
            // 
            this.timerAggiornaStatistiche.Interval = 10000;
            this.timerAggiornaStatistiche.Tick += new System.EventHandler(this.timerAggiornaStatistiche_Tick);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageOnLine);
            this.tabControlMain.Controls.Add(this.tabPageLog);
            this.tabControlMain.Controls.Add(this.tabPageSoglie);
            this.tabControlMain.Controls.Add(this.tabPageStatistiche1);
            this.tabControlMain.Controls.Add(this.tabPageStatistiche2);
            this.tabControlMain.Controls.Add(this.tabPageStatistiche3);
            this.tabControlMain.Controls.Add(this.tabPageStatistiche4);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.HideTab = true;
            this.tabControlMain.ImageList = this.imageList1;
            this.tabControlMain.ItemSize = new System.Drawing.Size(80, 18);
            this.tabControlMain.Location = new System.Drawing.Point(0, 62);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1201, 597);
            this.tabControlMain.TabIndex = 88;
            // 
            // tabPageOnLine
            // 
            this.tabPageOnLine.Controls.Add(this.ucPaginaOnLine1);
            this.tabPageOnLine.Location = new System.Drawing.Point(4, 22);
            this.tabPageOnLine.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageOnLine.Name = "tabPageOnLine";
            this.tabPageOnLine.Size = new System.Drawing.Size(1193, 571);
            this.tabPageOnLine.TabIndex = 5;
            this.tabPageOnLine.Text = "OnLine";
            this.tabPageOnLine.UseVisualStyleBackColor = true;
            // 
            // ucPaginaOnLine1
            // 
            this.ucPaginaOnLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaOnLine1.Location = new System.Drawing.Point(0, 0);
            this.ucPaginaOnLine1.Margin = new System.Windows.Forms.Padding(0);
            this.ucPaginaOnLine1.Name = "ucPaginaOnLine1";
            this.ucPaginaOnLine1.Size = new System.Drawing.Size(1193, 571);
            this.ucPaginaOnLine1.TabIndex = 0;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.ucPaginaViewLog1);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(1193, 571);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // ucPaginaViewLog1
            // 
            this.ucPaginaViewLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaViewLog1.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaViewLog1.Name = "ucPaginaViewLog1";
            this.ucPaginaViewLog1.Size = new System.Drawing.Size(1187, 565);
            this.ucPaginaViewLog1.TabIndex = 0;
            // 
            // tabPageSoglie
            // 
            this.tabPageSoglie.Controls.Add(this.ucPaginaViewSoglie1);
            this.tabPageSoglie.Location = new System.Drawing.Point(4, 22);
            this.tabPageSoglie.Name = "tabPageSoglie";
            this.tabPageSoglie.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSoglie.Size = new System.Drawing.Size(1193, 571);
            this.tabPageSoglie.TabIndex = 1;
            this.tabPageSoglie.Text = "Soglie";
            this.tabPageSoglie.UseVisualStyleBackColor = true;
            // 
            // ucPaginaViewSoglie1
            // 
            this.ucPaginaViewSoglie1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaViewSoglie1.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaViewSoglie1.Name = "ucPaginaViewSoglie1";
            this.ucPaginaViewSoglie1.Size = new System.Drawing.Size(1187, 565);
            this.ucPaginaViewSoglie1.TabIndex = 0;
            // 
            // tabPageStatistiche1
            // 
            this.tabPageStatistiche1.Controls.Add(this.ucPaginaViewStat11);
            this.tabPageStatistiche1.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistiche1.Name = "tabPageStatistiche1";
            this.tabPageStatistiche1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistiche1.Size = new System.Drawing.Size(1193, 571);
            this.tabPageStatistiche1.TabIndex = 2;
            this.tabPageStatistiche1.Text = "Statistiche 1";
            this.tabPageStatistiche1.UseVisualStyleBackColor = true;
            // 
            // ucPaginaViewStat11
            // 
            this.ucPaginaViewStat11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaViewStat11.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaViewStat11.Name = "ucPaginaViewStat11";
            this.ucPaginaViewStat11.Size = new System.Drawing.Size(1187, 565);
            this.ucPaginaViewStat11.TabIndex = 0;
            // 
            // tabPageStatistiche2
            // 
            this.tabPageStatistiche2.Controls.Add(this.ucPaginaViewStat21);
            this.tabPageStatistiche2.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistiche2.Name = "tabPageStatistiche2";
            this.tabPageStatistiche2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistiche2.Size = new System.Drawing.Size(1193, 571);
            this.tabPageStatistiche2.TabIndex = 3;
            this.tabPageStatistiche2.Text = "Statistiche 2";
            this.tabPageStatistiche2.UseVisualStyleBackColor = true;
            // 
            // ucPaginaViewStat21
            // 
            this.ucPaginaViewStat21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaViewStat21.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaViewStat21.Name = "ucPaginaViewStat21";
            this.ucPaginaViewStat21.Size = new System.Drawing.Size(1187, 565);
            this.ucPaginaViewStat21.TabIndex = 0;
            // 
            // tabPageStatistiche3
            // 
            this.tabPageStatistiche3.Controls.Add(this.ucPaginaViewStat31);
            this.tabPageStatistiche3.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistiche3.Name = "tabPageStatistiche3";
            this.tabPageStatistiche3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistiche3.Size = new System.Drawing.Size(1193, 571);
            this.tabPageStatistiche3.TabIndex = 4;
            this.tabPageStatistiche3.Text = "Statistiche 3";
            this.tabPageStatistiche3.UseVisualStyleBackColor = true;
            // 
            // ucPaginaViewStat31
            // 
            this.ucPaginaViewStat31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaViewStat31.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaViewStat31.Name = "ucPaginaViewStat31";
            this.ucPaginaViewStat31.Size = new System.Drawing.Size(1187, 565);
            this.ucPaginaViewStat31.TabIndex = 0;
            // 
            // tabPageStatistiche4
            // 
            this.tabPageStatistiche4.Controls.Add(this.ucPaginaViewStat41);
            this.tabPageStatistiche4.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistiche4.Name = "tabPageStatistiche4";
            this.tabPageStatistiche4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatistiche4.Size = new System.Drawing.Size(1193, 571);
            this.tabPageStatistiche4.TabIndex = 6;
            this.tabPageStatistiche4.Text = "Statistiche 4";
            this.tabPageStatistiche4.UseVisualStyleBackColor = true;
            // 
            // ucPaginaViewStat41
            // 
            this.ucPaginaViewStat41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaViewStat41.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaViewStat41.Name = "ucPaginaViewStat41";
            this.ucPaginaViewStat41.Size = new System.Drawing.Size(1187, 565);
            this.ucPaginaViewStat41.TabIndex = 0;
            // 
            // UCPaginaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UCPaginaView";
            this.Size = new System.Drawing.Size(1201, 659);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageOnLine.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPageSoglie.ResumeLayout(false);
            this.tabPageStatistiche1.ResumeLayout(false);
            this.tabPageStatistiche2.ResumeLayout(false);
            this.tabPageStatistiche3.ResumeLayout(false);
            this.tabPageStatistiche4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QVLEGSCOG2362.UCTabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageSoglie;
        private System.Windows.Forms.TabPage tabPageStatistiche1;
        private System.Windows.Forms.TabPage tabPageStatistiche2;
        private System.Windows.Forms.TabPage tabPageStatistiche3;
        private System.Windows.Forms.ImageList imageList1;
        private SottoPagine.UCPaginaViewLog ucPaginaViewLog1;
        private SottoPagine.UCPaginaViewSoglie ucPaginaViewSoglie1;
        private SottoPagine.UCPaginaViewStat1 ucPaginaViewStat11;
        private SottoPagine.UCPaginaViewStat2 ucPaginaViewStat21;
        private SottoPagine.UCPaginaViewStat3 ucPaginaViewStat31;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnSoglie;
        private System.Windows.Forms.Button btnStatistiche1;
        private System.Windows.Forms.Button btnStatistiche2;
        private System.Windows.Forms.Button btnStatistiche3;
        private System.Windows.Forms.Timer timerAggiornaStatistiche;
        private System.Windows.Forms.TabPage tabPageOnLine;
        private System.Windows.Forms.Button btnOnline;
        private UCPaginaOnLine ucPaginaOnLine1;
        private System.Windows.Forms.TabPage tabPageStatistiche4;
        private System.Windows.Forms.Button btnStatistiche4;
        private SottoPagine.UCPaginaViewStat4 ucPaginaViewStat41;
    }
}
