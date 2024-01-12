namespace QVLEGSCOG2362.Pagine
{
    partial class UCPaginaDiagnostica
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
            this.btnAbilitaSalvataggioFoto = new System.Windows.Forms.Button();
            this.panelStatoSalvataggio = new System.Windows.Forms.Panel();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAbilitaSalvataggioFoto
            // 
            this.btnAbilitaSalvataggioFoto.Location = new System.Drawing.Point(3, 35);
            this.btnAbilitaSalvataggioFoto.Name = "btnAbilitaSalvataggioFoto";
            this.btnAbilitaSalvataggioFoto.Size = new System.Drawing.Size(200, 80);
            this.btnAbilitaSalvataggioFoto.TabIndex = 1;
            this.btnAbilitaSalvataggioFoto.Text = "BTN_ABILITA_SALVATAGGIO";
            this.btnAbilitaSalvataggioFoto.UseVisualStyleBackColor = true;
            this.btnAbilitaSalvataggioFoto.Click += new System.EventHandler(this.btnAbilitaSalvataggioFoto_Click);
            // 
            // panelStatoSalvataggio
            // 
            this.panelStatoSalvataggio.BackColor = System.Drawing.Color.Red;
            this.panelStatoSalvataggio.Location = new System.Drawing.Point(209, 50);
            this.panelStatoSalvataggio.Name = "panelStatoSalvataggio";
            this.panelStatoSalvataggio.Size = new System.Drawing.Size(46, 43);
            this.panelStatoSalvataggio.TabIndex = 2;
            // 
            // lblTitolo
            // 
            this.lblTitolo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.Color.White;
            this.lblTitolo.Location = new System.Drawing.Point(0, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(629, 32);
            this.lblTitolo.TabIndex = 43;
            this.lblTitolo.Text = "LBL_FRM_DIAGNOSTICA";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCPaginaDiagnostica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitolo);
            this.Controls.Add(this.panelStatoSalvataggio);
            this.Controls.Add(this.btnAbilitaSalvataggioFoto);
            this.Name = "UCPaginaDiagnostica";
            this.Size = new System.Drawing.Size(629, 365);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAbilitaSalvataggioFoto;
        private System.Windows.Forms.Panel panelStatoSalvataggio;
        private System.Windows.Forms.Label lblTitolo;
    }
}
