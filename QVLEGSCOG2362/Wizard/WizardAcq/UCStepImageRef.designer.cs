namespace QVLEGSCOG2362.Wizard
{
    partial class UCStepImageRef
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
            this.btnSnap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUltimaFoto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Size = new System.Drawing.Size(900, 30);
            this.Description.Text = "LBL_STEP_IMAGE_REF";
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
            // btnSnap
            // 
            this.btnSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.Image = global::QVLEGSCOG2362.Properties.Resources.imgScattaFoto;
            this.btnSnap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnap.Location = new System.Drawing.Point(10, 10);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(130, 60);
            this.btnSnap.TabIndex = 11;
            this.btnSnap.Text = "BTN_SNAP";
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSnap.UseVisualStyleBackColor = true;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnUltimaFoto);
            this.panel1.Controls.Add(this.lblDescrizione);
            this.panel1.Controls.Add(this.btnSnap);
            this.panel1.Controls.Add(this.panelContainer);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 646);
            this.panel1.TabIndex = 12;
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrizione.Location = new System.Drawing.Point(10, 439);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(537, 201);
            this.lblDescrizione.TabIndex = 44;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE_IMAGE_REF";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(568, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 47;
            // 
            // btnUltimaFoto
            // 
            this.btnUltimaFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimaFoto.Image = global::QVLEGSCOG2362.Properties.Resources.img;
            this.btnUltimaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUltimaFoto.Location = new System.Drawing.Point(146, 10);
            this.btnUltimaFoto.Name = "btnUltimaFoto";
            this.btnUltimaFoto.Size = new System.Drawing.Size(130, 60);
            this.btnUltimaFoto.TabIndex = 50;
            this.btnUltimaFoto.Text = "BTN_ULTIMA_FOTO";
            this.btnUltimaFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUltimaFoto.UseVisualStyleBackColor = true;
            this.btnUltimaFoto.Click += new System.EventHandler(this.btnUltimaFoto_Click);
            // 
            // UCStepImageRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "UCStepImageRef";
            this.NextStep = "Step4";
            this.PreviousStep = "Step2";
            this.Size = new System.Drawing.Size(916, 690);
            this.StepDescription = "LBL_STEP_IMAGE_REF";
            this.Controls.SetChildIndex(this.Description, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.Button btnUltimaFoto;
    }
}
