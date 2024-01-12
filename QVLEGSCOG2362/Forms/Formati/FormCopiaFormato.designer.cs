namespace QVLEGSCOG2362
{
    partial class FormCopiaFormato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCopiaFormato));
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(225, 15);
            this.txtId.Margin = new System.Windows.Forms.Padding(6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(381, 31);
            this.txtId.TabIndex = 2;
            this.txtId.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(225, 58);
            this.txtDescrizione.Margin = new System.Windows.Forms.Padding(6);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(381, 31);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.Enter += new System.EventHandler(this.txt_DescrizioneEnter);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblId.Location = new System.Drawing.Point(11, 18);
            this.lblId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(82, 25);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "LBL_ID";
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.AutoSize = true;
            this.lblDescrizione.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDescrizione.Location = new System.Drawing.Point(11, 61);
            this.lblDescrizione.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(203, 25);
            this.lblDescrizione.TabIndex = 5;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.Image = global::QVLEGSCOG2362.Properties.Resources.imgChiudi;
            this.btnAnnulla.Location = new System.Drawing.Point(403, 111);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(6);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(203, 58);
            this.btnAnnulla.TabIndex = 1;
            this.btnAnnulla.Text = "BTN_ANNULLA";
            this.btnAnnulla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.Image = global::QVLEGSCOG2362.Properties.Resources.imgApplica;
            this.btnSalva.Location = new System.Drawing.Point(188, 111);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(203, 58);
            this.btnSalva.TabIndex = 0;
            this.btnSalva.Text = "BTN_SALVA";
            this.btnSalva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // FormCopiaFormato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(621, 177);
            this.ControlBox = false;
            this.Controls.Add(this.lblDescrizione);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormCopiaFormato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LBL_FRM_COPY_FORMATO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDescrizione;
    }
}