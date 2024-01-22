namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    partial class UCPaginaSelezionePattern
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPaginaSelezionePattern));
            this.lblTitolo = new System.Windows.Forms.Label();
            this.tablePanelContainer = new System.Windows.Forms.TableLayoutPanel();
            this.flowPanelOKCanc = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tablePanelPatternContainer = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPatternGrid = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tablePanelRowColumns = new System.Windows.Forms.TableLayoutPanel();
            this.panelPattern = new System.Windows.Forms.Panel();
            this.nudRows = new QVLEGSCOG2362.UCNumericUpDown();
            this.nudColumns = new QVLEGSCOG2362.UCNumericUpDown();
            this.lblRighe = new System.Windows.Forms.Label();
            this.lblColonne = new System.Windows.Forms.Label();
            this.tablePanelContainer.SuspendLayout();
            this.flowPanelOKCanc.SuspendLayout();
            this.tablePanelPatternContainer.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tablePanelRowColumns.SuspendLayout();
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
            this.lblTitolo.Size = new System.Drawing.Size(944, 32);
            this.lblTitolo.TabIndex = 44;
            this.lblTitolo.Text = "PATTERN";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tablePanelContainer
            // 
            this.tablePanelContainer.ColumnCount = 1;
            this.tablePanelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelContainer.Controls.Add(this.flowPanelOKCanc, 0, 2);
            this.tablePanelContainer.Controls.Add(this.tablePanelPatternContainer, 0, 1);
            this.tablePanelContainer.Controls.Add(this.tablePanelRowColumns, 0, 0);
            this.tablePanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelContainer.Location = new System.Drawing.Point(0, 32);
            this.tablePanelContainer.Name = "tablePanelContainer";
            this.tablePanelContainer.RowCount = 3;
            this.tablePanelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tablePanelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tablePanelContainer.Size = new System.Drawing.Size(944, 613);
            this.tablePanelContainer.TabIndex = 45;
            // 
            // flowPanelOKCanc
            // 
            this.flowPanelOKCanc.Controls.Add(this.btnAnnulla);
            this.flowPanelOKCanc.Controls.Add(this.btnSave);
            this.flowPanelOKCanc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelOKCanc.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowPanelOKCanc.Location = new System.Drawing.Point(3, 556);
            this.flowPanelOKCanc.Name = "flowPanelOKCanc";
            this.flowPanelOKCanc.Size = new System.Drawing.Size(938, 54);
            this.flowPanelOKCanc.TabIndex = 1;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAnnulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAnnulla.FlatAppearance.BorderSize = 0;
            this.btnAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnulla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulla.ForeColor = System.Drawing.Color.Black;
            this.btnAnnulla.Image = global::QVLEGSCOG2362.Properties.Resources.if_player_stop_1829;
            this.btnAnnulla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnulla.Location = new System.Drawing.Point(801, 3);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(134, 50);
            this.btnAnnulla.TabIndex = 1104;
            this.btnAnnulla.Text = "BTN_ANNULLA";
            this.btnAnnulla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnulla.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(661, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 50);
            this.btnSave.TabIndex = 1105;
            this.btnSave.Text = "BTN_SALVA";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // tablePanelPatternContainer
            // 
            this.tablePanelPatternContainer.ColumnCount = 2;
            this.tablePanelPatternContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablePanelPatternContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelPatternContainer.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tablePanelPatternContainer.Controls.Add(this.panelPattern, 1, 0);
            this.tablePanelPatternContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelPatternContainer.Location = new System.Drawing.Point(3, 63);
            this.tablePanelPatternContainer.Name = "tablePanelPatternContainer";
            this.tablePanelPatternContainer.RowCount = 1;
            this.tablePanelPatternContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelPatternContainer.Size = new System.Drawing.Size(938, 487);
            this.tablePanelPatternContainer.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPatternGrid);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(144, 481);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnPatternGrid
            // 
            this.btnPatternGrid.BackColor = System.Drawing.Color.DarkGray;
            this.btnPatternGrid.FlatAppearance.BorderSize = 0;
            this.btnPatternGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatternGrid.Location = new System.Drawing.Point(3, 3);
            this.btnPatternGrid.Name = "btnPatternGrid";
            this.btnPatternGrid.Size = new System.Drawing.Size(145, 145);
            this.btnPatternGrid.TabIndex = 93;
            this.btnPatternGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPatternGrid.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 145);
            this.button1.TabIndex = 94;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 145);
            this.button2.TabIndex = 95;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // tablePanelRowColumns
            // 
            this.tablePanelRowColumns.ColumnCount = 5;
            this.tablePanelRowColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelRowColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelRowColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelRowColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelRowColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelRowColumns.Controls.Add(this.lblColonne, 3, 0);
            this.tablePanelRowColumns.Controls.Add(this.lblRighe, 0, 0);
            this.tablePanelRowColumns.Controls.Add(this.nudColumns, 4, 0);
            this.tablePanelRowColumns.Controls.Add(this.nudRows, 1, 0);
            this.tablePanelRowColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelRowColumns.Location = new System.Drawing.Point(3, 3);
            this.tablePanelRowColumns.Name = "tablePanelRowColumns";
            this.tablePanelRowColumns.RowCount = 1;
            this.tablePanelRowColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelRowColumns.Size = new System.Drawing.Size(938, 54);
            this.tablePanelRowColumns.TabIndex = 3;
            // 
            // panelPattern
            // 
            this.panelPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPattern.Location = new System.Drawing.Point(153, 3);
            this.panelPattern.Name = "panelPattern";
            this.panelPattern.Size = new System.Drawing.Size(782, 481);
            this.panelPattern.TabIndex = 1;
            // 
            // nudRows
            // 
            this.nudRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRows.DecimalPlaces = 0;
            this.nudRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRows.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRows.Location = new System.Drawing.Point(112, 11);
            this.nudRows.Margin = new System.Windows.Forms.Padding(6);
            this.nudRows.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(328, 32);
            this.nudRows.TabIndex = 3;
            this.nudRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRows.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudColumns
            // 
            this.nudColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudColumns.DecimalPlaces = 0;
            this.nudColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudColumns.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumns.Location = new System.Drawing.Point(604, 11);
            this.nudColumns.Margin = new System.Windows.Forms.Padding(6);
            this.nudColumns.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudColumns.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(328, 32);
            this.nudColumns.TabIndex = 6;
            this.nudColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudColumns.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblRighe
            // 
            this.lblRighe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRighe.AutoSize = true;
            this.lblRighe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRighe.Location = new System.Drawing.Point(3, 17);
            this.lblRighe.Name = "lblRighe";
            this.lblRighe.Size = new System.Drawing.Size(100, 20);
            this.lblRighe.TabIndex = 7;
            this.lblRighe.Text = "LBL_RIGHE";
            // 
            // lblColonne
            // 
            this.lblColonne.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColonne.AutoSize = true;
            this.lblColonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonne.Location = new System.Drawing.Point(471, 17);
            this.lblColonne.Name = "lblColonne";
            this.lblColonne.Size = new System.Drawing.Size(124, 20);
            this.lblColonne.TabIndex = 9;
            this.lblColonne.Text = "LBL_COLONNE";
            // 
            // UCPaginaSelezionePattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanelContainer);
            this.Controls.Add(this.lblTitolo);
            this.Name = "UCPaginaSelezionePattern";
            this.Size = new System.Drawing.Size(944, 645);
            this.tablePanelContainer.ResumeLayout(false);
            this.flowPanelOKCanc.ResumeLayout(false);
            this.tablePanelPatternContainer.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tablePanelRowColumns.ResumeLayout(false);
            this.tablePanelRowColumns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.TableLayoutPanel tablePanelContainer;
        private System.Windows.Forms.FlowLayoutPanel flowPanelOKCanc;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tablePanelPatternContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnPatternGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tablePanelRowColumns;
        private System.Windows.Forms.Panel panelPattern;
        private UCNumericUpDown nudColumns;
        private UCNumericUpDown nudRows;
        private System.Windows.Forms.Label lblRighe;
        private System.Windows.Forms.Label lblColonne;
    }
}
