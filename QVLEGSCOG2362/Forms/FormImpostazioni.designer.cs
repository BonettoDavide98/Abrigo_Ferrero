namespace QVLEGSCOG2362
{
    partial class FormImpostazioni
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnUtenti = new System.Windows.Forms.Button();
            this.btnTurni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(12, 41);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(760, 479);
            this.propertyGrid1.TabIndex = 1;
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.Location = new System.Drawing.Point(697, 526);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(75, 23);
            this.btnSalva.TabIndex = 2;
            this.btnSalva.Text = "BTN_SALVA";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnUtenti
            // 
            this.btnUtenti.Location = new System.Drawing.Point(12, 12);
            this.btnUtenti.Name = "btnUtenti";
            this.btnUtenti.Size = new System.Drawing.Size(75, 23);
            this.btnUtenti.TabIndex = 3;
            this.btnUtenti.Text = "BTN_UTENTI";
            this.btnUtenti.UseVisualStyleBackColor = true;
            this.btnUtenti.Click += new System.EventHandler(this.btnUtenti_Click);
            // 
            // btnTurni
            // 
            this.btnTurni.Location = new System.Drawing.Point(93, 12);
            this.btnTurni.Name = "btnTurni";
            this.btnTurni.Size = new System.Drawing.Size(75, 23);
            this.btnTurni.TabIndex = 4;
            this.btnTurni.Text = "BTN_TURNI";
            this.btnTurni.UseVisualStyleBackColor = true;
            this.btnTurni.Click += new System.EventHandler(this.btnTurni_Click);
            // 
            // FormImpostazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnTurni);
            this.Controls.Add(this.btnUtenti);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "FormImpostazioni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_IMPOSTAZIONI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnUtenti;
        private System.Windows.Forms.Button btnTurni;
    }
}