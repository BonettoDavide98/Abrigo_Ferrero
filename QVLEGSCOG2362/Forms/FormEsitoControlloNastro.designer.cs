namespace QVLEGSCOG2362
{
    partial class FormEsitoControlloNastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEsitoControlloNastro));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBypass = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOK.Image = global::QVLEGSCOG2362.Properties.Resources.imgApplica;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(322, 188);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 60);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "BTN_OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBypass
            // 
            this.btnBypass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBypass.Image = global::QVLEGSCOG2362.Properties.Resources.imgChiudi;
            this.btnBypass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBypass.Location = new System.Drawing.Point(458, 188);
            this.btnBypass.Name = "btnBypass";
            this.btnBypass.Size = new System.Drawing.Size(130, 60);
            this.btnBypass.TabIndex = 1;
            this.btnBypass.Text = "BTN_BYPASS";
            this.btnBypass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBypass.UseVisualStyleBackColor = true;
            this.btnBypass.Click += new System.EventHandler(this.btnBypass_Click);
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(12, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(576, 176);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "label1";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEsitoControlloNastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 260);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnBypass);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEsitoControlloNastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parameters";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBypass;
        private System.Windows.Forms.Label lblText;
    }
}