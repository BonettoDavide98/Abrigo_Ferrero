namespace QVLEGSCOG2362.Pagine
{
    partial class UCPaginaOnLine
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
            this.lblTitolo = new System.Windows.Forms.Label();
            this.rbShowBad = new System.Windows.Forms.RadioButton();
            this.rbShowLock = new System.Windows.Forms.RadioButton();
            this.rbShow1N = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbShowLong = new System.Windows.Forms.RadioButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnSnap = new System.Windows.Forms.Button();
            this.lblCntTout = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitolo.Location = new System.Drawing.Point(0, 4);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(265, 32);
            this.lblTitolo.TabIndex = 42;
            this.lblTitolo.Text = "LBL_ONLINE";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbShowBad
            // 
            this.rbShowBad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbShowBad.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbShowBad.AutoSize = true;
            this.rbShowBad.FlatAppearance.BorderSize = 0;
            this.rbShowBad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbShowBad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowBad.Location = new System.Drawing.Point(122, 3);
            this.rbShowBad.Name = "rbShowBad";
            this.rbShowBad.Size = new System.Drawing.Size(114, 25);
            this.rbShowBad.TabIndex = 44;
            this.rbShowBad.Text = "LBL_SHOW_BAD";
            this.rbShowBad.UseVisualStyleBackColor = true;
            this.rbShowBad.CheckedChanged += new System.EventHandler(this.rbShow_CheckedChanged);
            // 
            // rbShowLock
            // 
            this.rbShowLock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbShowLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbShowLock.AutoSize = true;
            this.rbShowLock.FlatAppearance.BorderSize = 0;
            this.rbShowLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbShowLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowLock.Location = new System.Drawing.Point(242, 3);
            this.rbShowLock.Name = "rbShowLock";
            this.rbShowLock.Size = new System.Drawing.Size(122, 25);
            this.rbShowLock.TabIndex = 45;
            this.rbShowLock.Text = "LBL_SHOW_LOCK";
            this.rbShowLock.UseVisualStyleBackColor = true;
            this.rbShowLock.CheckedChanged += new System.EventHandler(this.rbShow_CheckedChanged);
            // 
            // rbShow1N
            // 
            this.rbShow1N.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbShow1N.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbShow1N.AutoSize = true;
            this.rbShow1N.Checked = true;
            this.rbShow1N.FlatAppearance.BorderSize = 0;
            this.rbShow1N.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbShow1N.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShow1N.Location = new System.Drawing.Point(3, 3);
            this.rbShow1N.Name = "rbShow1N";
            this.rbShow1N.Size = new System.Drawing.Size(113, 25);
            this.rbShow1N.TabIndex = 46;
            this.rbShow1N.TabStop = true;
            this.rbShow1N.Text = "LBL_SHOW_1_N";
            this.rbShow1N.UseVisualStyleBackColor = true;
            this.rbShow1N.CheckedChanged += new System.EventHandler(this.rbShow_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.rbShow1N);
            this.flowLayoutPanel1.Controls.Add(this.rbShowBad);
            this.flowLayoutPanel1.Controls.Add(this.rbShowLock);
            this.flowLayoutPanel1.Controls.Add(this.rbShowLong);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(271, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(500, 32);
            this.flowLayoutPanel1.TabIndex = 47;
            // 
            // rbShowLong
            // 
            this.rbShowLong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbShowLong.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbShowLong.AutoSize = true;
            this.rbShowLong.FlatAppearance.BorderSize = 0;
            this.rbShowLong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbShowLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbShowLong.Location = new System.Drawing.Point(370, 3);
            this.rbShowLong.Name = "rbShowLong";
            this.rbShowLong.Size = new System.Drawing.Size(124, 25);
            this.rbShowLong.TabIndex = 47;
            this.rbShowLong.Text = "LBL_SHOW_LONG";
            this.rbShowLong.UseVisualStyleBackColor = true;
            this.rbShowLong.CheckedChanged += new System.EventHandler(this.rbShow_CheckedChanged);
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Location = new System.Drawing.Point(3, 38);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1060, 555);
            this.panelContainer.TabIndex = 48;
            // 
            // btnSnap
            // 
            this.btnSnap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnap.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.btnSalvaFoto_Image;
            this.btnSnap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSnap.FlatAppearance.BorderSize = 0;
            this.btnSnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.Location = new System.Drawing.Point(915, 4);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(148, 32);
            this.btnSnap.TabIndex = 1;
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSnap.UseVisualStyleBackColor = true;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // lblCntTout
            // 
            this.lblCntTout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCntTout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCntTout.Location = new System.Drawing.Point(777, 4);
            this.lblCntTout.Name = "lblCntTout";
            this.lblCntTout.Size = new System.Drawing.Size(132, 32);
            this.lblCntTout.TabIndex = 49;
            this.lblCntTout.Text = "label1";
            this.lblCntTout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UCPaginaOnLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCntTout);
            this.Controls.Add(this.btnSnap);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTitolo);
            this.Name = "UCPaginaOnLine";
            this.Size = new System.Drawing.Size(1066, 600);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.RadioButton rbShowBad;
        private System.Windows.Forms.RadioButton rbShowLock;
        private System.Windows.Forms.RadioButton rbShow1N;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.Label lblCntTout;
        private System.Windows.Forms.RadioButton rbShowLong;
    }
}
