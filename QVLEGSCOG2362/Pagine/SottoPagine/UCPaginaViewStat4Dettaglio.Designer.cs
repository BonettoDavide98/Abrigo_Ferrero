namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    partial class UCPaginaViewStat4Dettaglio
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartTurnoPrecedente = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtFromData = new System.Windows.Forms.DateTimePicker();
            this.dtFromTempo = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtToData = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFrom = new System.Windows.Forms.Label();
            this.lblFiltroTo = new System.Windows.Forms.Label();
            this.dtToTempo = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCerca = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoPrecedente)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chartTurnoPrecedente, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(337, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 527F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 527);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // chartTurnoPrecedente
            // 
            this.chartTurnoPrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.chartTurnoPrecedente.ChartAreas.Add(chartArea5);
            this.chartTurnoPrecedente.Location = new System.Drawing.Point(3, 3);
            this.chartTurnoPrecedente.Name = "chartTurnoPrecedente";
            series5.ChartArea = "ChartArea1";
            series5.Name = "Series1";
            this.chartTurnoPrecedente.Series.Add(series5);
            this.chartTurnoPrecedente.Size = new System.Drawing.Size(651, 521);
            this.chartTurnoPrecedente.TabIndex = 44;
            this.chartTurnoPrecedente.Text = "chart1";
            // 
            // dtFromData
            // 
            this.dtFromData.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromData.Location = new System.Drawing.Point(3, 23);
            this.dtFromData.Name = "dtFromData";
            this.dtFromData.ShowUpDown = true;
            this.dtFromData.Size = new System.Drawing.Size(222, 31);
            this.dtFromData.TabIndex = 49;
            // 
            // dtFromTempo
            // 
            this.dtFromTempo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromTempo.CustomFormat = "HH:mm";
            this.dtFromTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromTempo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromTempo.Location = new System.Drawing.Point(231, 23);
            this.dtFromTempo.Name = "dtFromTempo";
            this.dtFromTempo.ShowUpDown = true;
            this.dtFromTempo.Size = new System.Drawing.Size(94, 31);
            this.dtFromTempo.TabIndex = 50;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dtToData, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblFiltroFrom, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtFromTempo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFiltroTo, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtToTempo, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.dtFromData, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(328, 524);
            this.tableLayoutPanel2.TabIndex = 51;
            // 
            // dtToData
            // 
            this.dtToData.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToData.Location = new System.Drawing.Point(3, 80);
            this.dtToData.Name = "dtToData";
            this.dtToData.ShowUpDown = true;
            this.dtToData.Size = new System.Drawing.Size(222, 31);
            this.dtToData.TabIndex = 53;
            // 
            // lblFiltroFrom
            // 
            this.lblFiltroFrom.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblFiltroFrom, 2);
            this.lblFiltroFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroFrom.Location = new System.Drawing.Point(3, 0);
            this.lblFiltroFrom.Name = "lblFiltroFrom";
            this.lblFiltroFrom.Size = new System.Drawing.Size(160, 20);
            this.lblFiltroFrom.TabIndex = 51;
            this.lblFiltroFrom.Text = "LBL_FILTRO_FROM";
            // 
            // lblFiltroTo
            // 
            this.lblFiltroTo.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblFiltroTo, 2);
            this.lblFiltroTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroTo.Location = new System.Drawing.Point(3, 57);
            this.lblFiltroTo.Name = "lblFiltroTo";
            this.lblFiltroTo.Size = new System.Drawing.Size(134, 20);
            this.lblFiltroTo.TabIndex = 52;
            this.lblFiltroTo.Text = "LBL_FILTRO_TO";
            // 
            // dtToTempo
            // 
            this.dtToTempo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToTempo.CustomFormat = "HH:mm";
            this.dtToTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToTempo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToTempo.Location = new System.Drawing.Point(231, 80);
            this.dtToTempo.Name = "dtToTempo";
            this.dtToTempo.ShowUpDown = true;
            this.dtToTempo.Size = new System.Drawing.Size(94, 31);
            this.dtToTempo.TabIndex = 54;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnCerca, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnExport, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 137);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(322, 384);
            this.tableLayoutPanel3.TabIndex = 55;
            // 
            // btnCerca
            // 
            this.btnCerca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerca.Image = global::QVLEGSCOG2362.Properties.Resources.imgSearch;
            this.btnCerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerca.Location = new System.Drawing.Point(3, 3);
            this.btnCerca.Name = "btnCerca";
            this.btnCerca.Size = new System.Drawing.Size(155, 60);
            this.btnCerca.TabIndex = 46;
            this.btnCerca.Text = "BTN_CERCA";
            this.btnCerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerca.UseVisualStyleBackColor = true;
            this.btnCerca.Click += new System.EventHandler(this.btnCerca_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = global::QVLEGSCOG2362.Properties.Resources.Export_32x32;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(164, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(155, 60);
            this.btnExport.TabIndex = 47;
            this.btnExport.Text = "BTN_EXPORT";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // UCPaginaViewStat4Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "UCPaginaViewStat4Dettaglio";
            this.Size = new System.Drawing.Size(997, 533);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoPrecedente)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnoPrecedente;
        private System.Windows.Forms.DateTimePicker dtFromData;
        private System.Windows.Forms.DateTimePicker dtFromTempo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblFiltroFrom;
        private System.Windows.Forms.DateTimePicker dtToData;
        private System.Windows.Forms.Label lblFiltroTo;
        private System.Windows.Forms.DateTimePicker dtToTempo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnCerca;
        private System.Windows.Forms.Button btnExport;
    }
}
