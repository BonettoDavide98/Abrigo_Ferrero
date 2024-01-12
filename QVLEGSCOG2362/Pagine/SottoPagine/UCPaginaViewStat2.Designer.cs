namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    partial class UCPaginaViewStat2
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitolo.Location = new System.Drawing.Point(0, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(865, 32);
            this.lblTitolo.TabIndex = 43;
            this.lblTitolo.Text = "LBL_STATISTICHE_2";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 32);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(865, 441);
            this.panelContainer.TabIndex = 51;
            // 
            // UCPaginaViewStat2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.lblTitolo);
            this.DoubleBuffered = true;
            this.Name = "UCPaginaViewStat2";
            this.Size = new System.Drawing.Size(865, 473);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Panel panelContainer;
    }
}
