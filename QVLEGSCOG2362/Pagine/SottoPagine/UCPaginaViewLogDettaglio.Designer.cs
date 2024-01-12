namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    partial class UCPaginaViewLogDettaglio
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
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageDettaglio = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.panelImage = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ucTabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageDettaglio.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucTabControl1
            // 
            this.ucTabControl1.Controls.Add(this.tabPageMain);
            this.ucTabControl1.Controls.Add(this.tabPageDettaglio);
            this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabControl1.HideTab = true;
            this.ucTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ucTabControl1.Name = "ucTabControl1";
            this.ucTabControl1.SelectedIndex = 0;
            this.ucTabControl1.Size = new System.Drawing.Size(704, 499);
            this.ucTabControl1.TabIndex = 46;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.flowLayoutPanel1);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(696, 473);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(690, 467);
            this.flowLayoutPanel1.TabIndex = 45;
            // 
            // tabPageDettaglio
            // 
            this.tabPageDettaglio.Controls.Add(this.tableLayoutPanel1);
            this.tabPageDettaglio.Location = new System.Drawing.Point(4, 22);
            this.tabPageDettaglio.Name = "tabPageDettaglio";
            this.tabPageDettaglio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDettaglio.Size = new System.Drawing.Size(696, 441);
            this.tabPageDettaglio.TabIndex = 1;
            this.tabPageDettaglio.Text = "Dettaglio";
            this.tabPageDettaglio.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.btnGoBack, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 435);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGoBack.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.img_go_backSmall;
            this.btnGoBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGoBack.Location = new System.Drawing.Point(598, 3);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(89, 34);
            this.btnGoBack.TabIndex = 11;
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // panelImage
            // 
            this.panelImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImage.BackColor = System.Drawing.Color.Transparent;
            this.panelImage.Location = new System.Drawing.Point(3, 3);
            this.panelImage.Name = "panelImage";
            this.tableLayoutPanel1.SetRowSpan(this.panelImage, 2);
            this.panelImage.Size = new System.Drawing.Size(384, 429);
            this.panelImage.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(393, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(294, 389);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // UCPaginaViewLogDettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucTabControl1);
            this.DoubleBuffered = true;
            this.Name = "UCPaginaViewLogDettaglio";
            this.Size = new System.Drawing.Size(704, 499);
            this.ucTabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageDettaglio.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private UCTabControl ucTabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageDettaglio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
