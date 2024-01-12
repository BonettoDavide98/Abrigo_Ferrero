namespace QVLEGSCOG2362
{
    partial class FrmAggiungiModificaUtente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAggiungiModificaUtente));
            this.lblTestoUsername = new System.Windows.Forms.Label();
            this.lblTestoPassword = new System.Windows.Forms.Label();
            this.lblTestoOperatore = new System.Windows.Forms.Label();
            this.lblTestoLivello = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtOperatore = new System.Windows.Forms.TextBox();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTestoUsername
            // 
            this.lblTestoUsername.AutoSize = true;
            this.lblTestoUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestoUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTestoUsername.Location = new System.Drawing.Point(12, 59);
            this.lblTestoUsername.Name = "lblTestoUsername";
            this.lblTestoUsername.Size = new System.Drawing.Size(139, 20);
            this.lblTestoUsername.TabIndex = 0;
            this.lblTestoUsername.Text = "LBL_USERNAME";
            // 
            // lblTestoPassword
            // 
            this.lblTestoPassword.AutoSize = true;
            this.lblTestoPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestoPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTestoPassword.Location = new System.Drawing.Point(12, 91);
            this.lblTestoPassword.Name = "lblTestoPassword";
            this.lblTestoPassword.Size = new System.Drawing.Size(141, 20);
            this.lblTestoPassword.TabIndex = 1;
            this.lblTestoPassword.Text = "LBL_PASSWORD";
            // 
            // lblTestoOperatore
            // 
            this.lblTestoOperatore.AutoSize = true;
            this.lblTestoOperatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestoOperatore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTestoOperatore.Location = new System.Drawing.Point(12, 123);
            this.lblTestoOperatore.Name = "lblTestoOperatore";
            this.lblTestoOperatore.Size = new System.Drawing.Size(147, 20);
            this.lblTestoOperatore.TabIndex = 2;
            this.lblTestoOperatore.Text = "LBL_OPERATORE";
            // 
            // lblTestoLivello
            // 
            this.lblTestoLivello.AutoSize = true;
            this.lblTestoLivello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestoLivello.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTestoLivello.Location = new System.Drawing.Point(12, 155);
            this.lblTestoLivello.Name = "lblTestoLivello";
            this.lblTestoLivello.Size = new System.Drawing.Size(113, 20);
            this.lblTestoLivello.TabIndex = 3;
            this.lblTestoLivello.Text = "LBL_LIVELLO";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(167, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(198, 26);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(167, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(198, 26);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtOperatore
            // 
            this.txtOperatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperatore.Location = new System.Drawing.Point(167, 120);
            this.txtOperatore.Name = "txtOperatore";
            this.txtOperatore.Size = new System.Drawing.Size(198, 26);
            this.txtOperatore.TabIndex = 6;
            // 
            // cmbLivello
            // 
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLivello.FormattingEnabled = true;
            this.cmbLivello.Location = new System.Drawing.Point(167, 152);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(198, 28);
            this.cmbLivello.TabIndex = 7;
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.BackColor = System.Drawing.Color.Transparent;
            this.btnSalva.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalva.BackgroundImage")));
            this.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalva.FlatAppearance.BorderSize = 0;
            this.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalva.Location = new System.Drawing.Point(12, 188);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(380, 47);
            this.btnSalva.TabIndex = 10;
            this.btnSalva.UseVisualStyleBackColor = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(367, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 1031;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // FrmAggiungiModificaUtente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 238);
            this.ControlBox = false;
            this.Controls.Add(this.lblTestoUsername);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.cmbLivello);
            this.Controls.Add(this.txtOperatore);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblTestoLivello);
            this.Controls.Add(this.lblTestoOperatore);
            this.Controls.Add(this.lblTestoPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(420, 360);
            this.Name = "FrmAggiungiModificaUtente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LBL_TITOLO_NEW_UTENTE";
            this.Load += new System.EventHandler(this.frmAggiungiModificaUtente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestoUsername;
        private System.Windows.Forms.Label lblTestoPassword;
        private System.Windows.Forms.Label lblTestoOperatore;
        private System.Windows.Forms.Label lblTestoLivello;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtOperatore;
        internal System.Windows.Forms.ComboBox cmbLivello;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnClose;
    }
}