namespace QVLEGSCOG2362
{
    partial class FrmAggiungiModificaTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAggiungiModificaTurno));
            this.lblID = new System.Windows.Forms.Label();
            this.lblInizio = new System.Windows.Forms.Label();
            this.lblFine = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dateTimePickerInizio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFine = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblID.Location = new System.Drawing.Point(8, 59);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(64, 20);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "LBL_ID";
            // 
            // lblInizio
            // 
            this.lblInizio.AutoSize = true;
            this.lblInizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInizio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInizio.Location = new System.Drawing.Point(8, 93);
            this.lblInizio.Name = "lblInizio";
            this.lblInizio.Size = new System.Drawing.Size(95, 20);
            this.lblInizio.TabIndex = 2;
            this.lblInizio.Text = "LBL_INIZIO";
            // 
            // lblFine
            // 
            this.lblFine.AutoSize = true;
            this.lblFine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFine.Location = new System.Drawing.Point(8, 125);
            this.lblFine.Name = "lblFine";
            this.lblFine.Size = new System.Drawing.Size(84, 20);
            this.lblFine.TabIndex = 3;
            this.lblFine.Text = "LBL_FINE";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(167, 56);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(198, 26);
            this.txtID.TabIndex = 4;
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
            // dateTimePickerInizio
            // 
            this.dateTimePickerInizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerInizio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerInizio.Location = new System.Drawing.Point(167, 88);
            this.dateTimePickerInizio.Name = "dateTimePickerInizio";
            this.dateTimePickerInizio.ShowUpDown = true;
            this.dateTimePickerInizio.Size = new System.Drawing.Size(198, 26);
            this.dateTimePickerInizio.TabIndex = 1032;
            this.dateTimePickerInizio.Value = new System.DateTime(2020, 4, 30, 16, 22, 0, 0);
            // 
            // dateTimePickerFine
            // 
            this.dateTimePickerFine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFine.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFine.Location = new System.Drawing.Point(167, 120);
            this.dateTimePickerFine.Name = "dateTimePickerFine";
            this.dateTimePickerFine.ShowUpDown = true;
            this.dateTimePickerFine.Size = new System.Drawing.Size(198, 26);
            this.dateTimePickerFine.TabIndex = 1033;
            // 
            // FrmAggiungiModificaTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 238);
            this.ControlBox = false;
            this.Controls.Add(this.dateTimePickerFine);
            this.Controls.Add(this.dateTimePickerInizio);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblFine);
            this.Controls.Add(this.lblInizio);
            this.Controls.Add(this.lblID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(420, 360);
            this.Name = "FrmAggiungiModificaTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aggiungi Turno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblInizio;
        private System.Windows.Forms.Label lblFine;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dateTimePickerInizio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFine;
        private System.Windows.Forms.TextBox txtID;
    }
}