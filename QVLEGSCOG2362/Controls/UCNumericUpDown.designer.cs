namespace QVLEGSCOG2362
{
    partial class UCNumericUpDown
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
            this.btnMeno = new System.Windows.Forms.Button();
            this.btnPiu = new System.Windows.Forms.Button();
            this.nud = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMeno
            // 
            this.btnMeno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMeno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeno.Location = new System.Drawing.Point(0, 1);
            this.btnMeno.Margin = new System.Windows.Forms.Padding(6);
            this.btnMeno.Name = "btnMeno";
            this.btnMeno.Size = new System.Drawing.Size(46, 31);
            this.btnMeno.TabIndex = 0;
            this.btnMeno.Text = "-";
            this.btnMeno.UseVisualStyleBackColor = true;
            this.btnMeno.Click += new System.EventHandler(this.btnMeno_Click);
            this.btnMeno.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMeno_MouseDown);
            this.btnMeno.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMeno_MouseUp);
            // 
            // btnPiu
            // 
            this.btnPiu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPiu.Location = new System.Drawing.Point(348, 1);
            this.btnPiu.Margin = new System.Windows.Forms.Padding(6);
            this.btnPiu.Name = "btnPiu";
            this.btnPiu.Size = new System.Drawing.Size(46, 31);
            this.btnPiu.TabIndex = 1;
            this.btnPiu.Text = "+";
            this.btnPiu.UseVisualStyleBackColor = true;
            this.btnPiu.Click += new System.EventHandler(this.btnPiu_Click);
            this.btnPiu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPiu_MouseDown);
            this.btnPiu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPiu_MouseUp);
            // 
            // nud
            // 
            this.nud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nud.BackColor = System.Drawing.SystemColors.Window;
            this.nud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud.Location = new System.Drawing.Point(47, 2);
            this.nud.Margin = new System.Windows.Forms.Padding(6);
            this.nud.Name = "nud";
            this.nud.Size = new System.Drawing.Size(300, 29);
            this.nud.TabIndex = 2;
            this.nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            this.nud.Click += new System.EventHandler(this.nud_Click);
            this.nud.Enter += new System.EventHandler(this.nud_Enter);
            // 
            // UCNumericUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nud);
            this.Controls.Add(this.btnPiu);
            this.Controls.Add(this.btnMeno);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UCNumericUpDown";
            this.Size = new System.Drawing.Size(395, 32);
            ((System.ComponentModel.ISupportInitialize)(this.nud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMeno;
        private System.Windows.Forms.Button btnPiu;
        private System.Windows.Forms.NumericUpDown nud;

    }
}
