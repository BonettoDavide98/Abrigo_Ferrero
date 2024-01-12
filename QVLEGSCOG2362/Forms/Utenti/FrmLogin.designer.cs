namespace QVLEGSCOG2362
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lblTestoUsername = new System.Windows.Forms.Label();
            this.lblTestoPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAccedi = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTestoUsername
            // 
            this.lblTestoUsername.AutoSize = true;
            this.lblTestoUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestoUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTestoUsername.Location = new System.Drawing.Point(60, 17);
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
            this.lblTestoPassword.Location = new System.Drawing.Point(60, 56);
            this.lblTestoPassword.Name = "lblTestoPassword";
            this.lblTestoPassword.Size = new System.Drawing.Size(141, 20);
            this.lblTestoPassword.TabIndex = 1;
            this.lblTestoPassword.Text = "LBL_PASSWORD";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(205, 14);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(182, 26);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Click += new System.EventHandler(this.txtUsername_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(205, 53);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(182, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            // 
            // btnAccedi
            // 
            this.btnAccedi.BackColor = System.Drawing.Color.Transparent;
            this.btnAccedi.FlatAppearance.BorderSize = 0;
            this.btnAccedi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccedi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnAccedi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAccedi.Image = global::QVLEGSCOG2362.Properties.Resources.btnAccedi_Image;
            this.btnAccedi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccedi.Location = new System.Drawing.Point(78, 109);
            this.btnAccedi.Name = "btnAccedi";
            this.btnAccedi.Size = new System.Drawing.Size(142, 57);
            this.btnAccedi.TabIndex = 7;
            this.btnAccedi.Text = "BTN_NEW_LOGIN";
            this.btnAccedi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccedi.UseVisualStyleBackColor = false;
            this.btnAccedi.Click += new System.EventHandler(this.btnAccedi_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnClose.Image = global::QVLEGSCOG2362.Properties.Resources.imgChiudi;
            this.btnClose.Location = new System.Drawing.Point(226, 109);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 57);
            this.btnClose.TabIndex = 1031;
            this.btnClose.Text = "BTN_ANNULLA";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnAccedi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 179);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAccedi);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblTestoPassword);
            this.Controls.Add(this.lblTestoUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestoUsername;
        private System.Windows.Forms.Label lblTestoPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAccedi;
        private System.Windows.Forms.Button btnClose;
    }
}