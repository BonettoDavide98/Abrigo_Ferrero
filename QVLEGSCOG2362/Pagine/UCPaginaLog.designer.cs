namespace QVLEGSCOG2362.Pagine
{
    partial class UCPaginaLog
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
            this.btnResetAllarmi = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.ucNotificationPanel1 = new QVLEGSCOG2362.NotificationPanelDgv();
            this.SuspendLayout();
            // 
            // lblTitolo
            // 
            this.lblTitolo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitolo.Location = new System.Drawing.Point(0, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(1066, 52);
            this.lblTitolo.TabIndex = 42;
            this.lblTitolo.Text = "LBL_FRM_LOG";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResetAllarmi
            // 
            this.btnResetAllarmi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetAllarmi.BackColor = System.Drawing.SystemColors.Control;
            this.btnResetAllarmi.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.reset_alarm;
            this.btnResetAllarmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetAllarmi.FlatAppearance.BorderSize = 0;
            this.btnResetAllarmi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetAllarmi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetAllarmi.ForeColor = System.Drawing.Color.Black;
            this.btnResetAllarmi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetAllarmi.Location = new System.Drawing.Point(918, 2);
            this.btnResetAllarmi.Name = "btnResetAllarmi";
            this.btnResetAllarmi.Size = new System.Drawing.Size(145, 52);
            this.btnResetAllarmi.TabIndex = 1103;
            this.btnResetAllarmi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetAllarmi.UseVisualStyleBackColor = false;
            this.btnResetAllarmi.Click += new System.EventHandler(this.btnResetAllarmi_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.SystemColors.Control;
            this.btnHome.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.index;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(3, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(60, 49);
            this.btnHome.TabIndex = 2;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Visible = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // ucNotificationPanel1
            // 
            this.ucNotificationPanel1.BackColor = System.Drawing.Color.Transparent;
            this.ucNotificationPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNotificationPanel1.Location = new System.Drawing.Point(0, 52);
            this.ucNotificationPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.ucNotificationPanel1.Name = "ucNotificationPanel1";
            this.ucNotificationPanel1.Size = new System.Drawing.Size(1066, 548);
            this.ucNotificationPanel1.TabIndex = 0;
            this.ucNotificationPanel1.OnReset += new System.EventHandler(this.ucNotificationPanel1_OnReset);
            // 
            // UCPaginaLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucNotificationPanel1);
            this.Controls.Add(this.btnResetAllarmi);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lblTitolo);
            this.Name = "UCPaginaLog";
            this.Size = new System.Drawing.Size(1066, 600);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Button btnHome;
        private NotificationPanelDgv ucNotificationPanel1;
        private System.Windows.Forms.Button btnResetAllarmi;
    }
}
