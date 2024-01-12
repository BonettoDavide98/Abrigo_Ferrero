namespace QVLEGSCOG2362
{
    partial class FormSalvaFoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSalvaFoto));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEsci = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAbilitaSaveFoto = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.chiudi;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClose.Location = new System.Drawing.Point(610, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 44);
            this.btnClose.TabIndex = 1019;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEsci
            // 
            this.btnEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEsci.BackColor = System.Drawing.Color.Transparent;
            this.btnEsci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEsci.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnEsci.ForeColor = System.Drawing.Color.Black;
            this.btnEsci.Image = ((System.Drawing.Image)(resources.GetObject("btnEsci.Image")));
            this.btnEsci.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEsci.Location = new System.Drawing.Point(336, 196);
            this.btnEsci.Name = "btnEsci";
            this.btnEsci.Size = new System.Drawing.Size(134, 52);
            this.btnEsci.TabIndex = 1021;
            this.btnEsci.Text = "BTN_ESCI";
            this.btnEsci.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEsci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEsci.UseVisualStyleBackColor = false;
            this.btnEsci.Click += new System.EventHandler(this.btnEsci_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(193, 196);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 52);
            this.btnSave.TabIndex = 1020;
            this.btnSave.Text = "BTN_SALVA";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitolo
            // 
            this.lblTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitolo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitolo.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitolo.Location = new System.Drawing.Point(12, 9);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(592, 47);
            this.lblTitolo.TabIndex = 1073;
            this.lblTitolo.Text = "Gestione Salvataggio Foto";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAbilitaSaveFoto);
            this.groupBox2.Location = new System.Drawing.Point(12, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 117);
            this.groupBox2.TabIndex = 1082;
            this.groupBox2.TabStop = false;
            // 
            // btnAbilitaSaveFoto
            // 
            this.btnAbilitaSaveFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbilitaSaveFoto.BackColor = System.Drawing.Color.Transparent;
            this.btnAbilitaSaveFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAbilitaSaveFoto.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnAbilitaSaveFoto.ForeColor = System.Drawing.Color.Black;
            this.btnAbilitaSaveFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnAbilitaSaveFoto.Image")));
            this.btnAbilitaSaveFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbilitaSaveFoto.Location = new System.Drawing.Point(181, 33);
            this.btnAbilitaSaveFoto.Name = "btnAbilitaSaveFoto";
            this.btnAbilitaSaveFoto.Size = new System.Drawing.Size(277, 52);
            this.btnAbilitaSaveFoto.TabIndex = 1074;
            this.btnAbilitaSaveFoto.Text = "BTN_ABILITAZIONE";
            this.btnAbilitaSaveFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbilitaSaveFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbilitaSaveFoto.UseVisualStyleBackColor = false;
            this.btnAbilitaSaveFoto.Click += new System.EventHandler(this.btnAbilitaSaveFoto_Click);
            // 
            // FormSalvaFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(666, 260);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTitolo);
            this.Controls.Add(this.btnEsci);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSalvaFoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parameters";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEsci;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAbilitaSaveFoto;
    }
}