﻿namespace QVLEGSCOG2362.Wizard
{
    partial class UCStepAcetato
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.nudThreshold = new QVLEGSCOG2362.UCNumericUpDown();
            this.lblAreaMinDifetto = new System.Windows.Forms.Label();
            this.nudAreaMinDifetto = new QVLEGSCOG2362.UCNumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUltimaFoto = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblDistanzaBordo = new System.Windows.Forms.Label();
            this.nudDistanzaBordo = new QVLEGSCOG2362.UCNumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Size = new System.Drawing.Size(1084, 30);
            this.Description.Text = "LBL_STEP_Acetato";
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Location = new System.Drawing.Point(10, 76);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(721, 360);
            this.panelContainer.TabIndex = 2;
            // 
            // btnSnap
            // 
            this.btnSnap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnap.Image = global::QVLEGSCOG2362.Properties.Resources.imgScattaFoto;
            this.btnSnap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnap.Location = new System.Drawing.Point(146, 10);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(130, 60);
            this.btnSnap.TabIndex = 11;
            this.btnSnap.Text = "BTN_SNAP";
            this.btnSnap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSnap.UseVisualStyleBackColor = true;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.nudDistanzaBordo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDistanzaBordo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblThreshold, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudThreshold, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblAreaMinDifetto, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudAreaMinDifetto, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(752, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 646);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(3, 195);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(334, 448);
            this.propertyGrid1.TabIndex = 38;
            // 
            // lblThreshold
            // 
            this.lblThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreshold.Location = new System.Drawing.Point(3, 64);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(147, 20);
            this.lblThreshold.TabIndex = 0;
            this.lblThreshold.Text = "LBL_THRESHOLD";
            // 
            // nudThreshold
            // 
            this.nudThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudThreshold.DecimalPlaces = 0;
            this.nudThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreshold.Location = new System.Drawing.Point(6, 90);
            this.nudThreshold.Margin = new System.Windows.Forms.Padding(6);
            this.nudThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThreshold.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(328, 32);
            this.nudThreshold.TabIndex = 2;
            this.nudThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudThreshold.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblAreaMinDifetto
            // 
            this.lblAreaMinDifetto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAreaMinDifetto.AutoSize = true;
            this.lblAreaMinDifetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaMinDifetto.Location = new System.Drawing.Point(3, 128);
            this.lblAreaMinDifetto.Name = "lblAreaMinDifetto";
            this.lblAreaMinDifetto.Size = new System.Drawing.Size(207, 20);
            this.lblAreaMinDifetto.TabIndex = 7;
            this.lblAreaMinDifetto.Text = "LBL_AREA_MIN_DIFETTO";
            // 
            // nudAreaMinDifetto
            // 
            this.nudAreaMinDifetto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAreaMinDifetto.DecimalPlaces = 1;
            this.nudAreaMinDifetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAreaMinDifetto.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAreaMinDifetto.Location = new System.Drawing.Point(6, 154);
            this.nudAreaMinDifetto.Margin = new System.Windows.Forms.Padding(6);
            this.nudAreaMinDifetto.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudAreaMinDifetto.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAreaMinDifetto.Name = "nudAreaMinDifetto";
            this.nudAreaMinDifetto.Size = new System.Drawing.Size(328, 32);
            this.nudAreaMinDifetto.TabIndex = 8;
            this.nudAreaMinDifetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAreaMinDifetto.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnUltimaFoto);
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Controls.Add(this.lblDescrizione);
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.panelContainer);
            this.panel1.Controls.Add(this.btnSnap);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 646);
            this.panel1.TabIndex = 14;
            // 
            // btnUltimaFoto
            // 
            this.btnUltimaFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimaFoto.Image = global::QVLEGSCOG2362.Properties.Resources.img;
            this.btnUltimaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUltimaFoto.Location = new System.Drawing.Point(282, 10);
            this.btnUltimaFoto.Name = "btnUltimaFoto";
            this.btnUltimaFoto.Size = new System.Drawing.Size(130, 60);
            this.btnUltimaFoto.TabIndex = 49;
            this.btnUltimaFoto.Text = "BTN_ULTIMA_FOTO";
            this.btnUltimaFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUltimaFoto.UseVisualStyleBackColor = true;
            this.btnUltimaFoto.Click += new System.EventHandler(this.btnUltimaFoto_Click);
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Image = global::QVLEGSCOG2362.Properties.Resources.img_log;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(418, 10);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(130, 60);
            this.btnLog.TabIndex = 48;
            this.btnLog.Text = "BTN_LOG";
            this.btnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrizione.Location = new System.Drawing.Point(10, 439);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(721, 201);
            this.lblDescrizione.TabIndex = 47;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE_Acetato";
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Image = global::QVLEGSCOG2362.Properties.Resources.reloadPiccolo2;
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(10, 10);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(130, 60);
            this.btnTest.TabIndex = 46;
            this.btnTest.Text = "BTN_TEST";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblDistanzaBordo
            // 
            this.lblDistanzaBordo.AutoSize = true;
            this.lblDistanzaBordo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistanzaBordo.Location = new System.Drawing.Point(3, 0);
            this.lblDistanzaBordo.Name = "lblDistanzaBordo";
            this.lblDistanzaBordo.Size = new System.Drawing.Size(195, 20);
            this.lblDistanzaBordo.TabIndex = 52;
            this.lblDistanzaBordo.Text = "LBL_DISTANZA_BORDO";
            // 
            // nudDistanzaBordo
            // 
            this.nudDistanzaBordo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDistanzaBordo.DecimalPlaces = 1;
            this.nudDistanzaBordo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDistanzaBordo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudDistanzaBordo.Location = new System.Drawing.Point(6, 26);
            this.nudDistanzaBordo.Margin = new System.Windows.Forms.Padding(6);
            this.nudDistanzaBordo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDistanzaBordo.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDistanzaBordo.Name = "nudDistanzaBordo";
            this.nudDistanzaBordo.Size = new System.Drawing.Size(328, 32);
            this.nudDistanzaBordo.TabIndex = 53;
            this.nudDistanzaBordo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDistanzaBordo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // UCStepAcetato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCStepAcetato";
            this.NextStep = "Step4";
            this.PreviousStep = "Step2";
            this.Size = new System.Drawing.Size(1100, 690);
            this.StepDescription = "LBL_STEP_Acetato";
            this.Controls.SetChildIndex(this.Description, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblThreshold;
        private UCNumericUpDown nudThreshold;
        private UCNumericUpDown nudAreaMinDifetto;
        private System.Windows.Forms.Label lblAreaMinDifetto;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnUltimaFoto;
        private System.Windows.Forms.Label lblDistanzaBordo;
        private UCNumericUpDown nudDistanzaBordo;
    }
}