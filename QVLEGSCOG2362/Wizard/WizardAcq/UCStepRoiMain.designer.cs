namespace QVLEGSCOG2362.Wizard
{
    partial class UCStepRoiMain
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnDisegnaRettangolo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Size = new System.Drawing.Size(900, 30);
            this.Description.Text = "LBL_STEP_ROI_MAIN";
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Location = new System.Drawing.Point(10, 76);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(537, 360);
            this.panelContainer.TabIndex = 2;
            // 
            // btnDisegnaRettangolo
            // 
            this.btnDisegnaRettangolo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisegnaRettangolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisegnaRettangolo.Image = global::QVLEGSCOG2362.Properties.Resources.imgRettangolo;
            this.btnDisegnaRettangolo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisegnaRettangolo.Location = new System.Drawing.Point(3, 3);
            this.btnDisegnaRettangolo.Name = "btnDisegnaRettangolo";
            this.btnDisegnaRettangolo.Size = new System.Drawing.Size(334, 60);
            this.btnDisegnaRettangolo.TabIndex = 44;
            this.btnDisegnaRettangolo.Text = "BTN_ROI_MAIN";
            this.btnDisegnaRettangolo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDisegnaRettangolo.UseVisualStyleBackColor = true;
            this.btnDisegnaRettangolo.Click += new System.EventHandler(this.btnDisegnaRettangolo_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblDescrizione);
            this.panel1.Controls.Add(this.panelContainer);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 646);
            this.panel1.TabIndex = 45;
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrizione.Location = new System.Drawing.Point(10, 439);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(537, 201);
            this.lblDescrizione.TabIndex = 43;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE_ROI_MAIN";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnDisegnaRettangolo, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(568, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // UCStepRoiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "UCStepRoiMain";
            this.NextStep = "Step4";
            this.PreviousStep = "Step2";
            this.Size = new System.Drawing.Size(916, 690);
            this.StepDescription = "LBL_STEP_ROI_MAIN";
            this.Controls.SetChildIndex(this.Description, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnDisegnaRettangolo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDescrizione;
    }
}
