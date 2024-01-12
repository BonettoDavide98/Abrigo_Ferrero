namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    partial class UCPaginaViewStat2Dettaglio
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmbTipoGrafico = new System.Windows.Forms.ComboBox();
            this.objCmbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTurnoPrecedente = new System.Windows.Forms.Label();
            this.chartTurnoPrecedente = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTurnoAttuale = new System.Windows.Forms.Label();
            this.chartTurnoAttuale = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblUltimaOra = new System.Windows.Forms.Label();
            this.chartUltimaOra = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.objCmbBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoPrecedente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoAttuale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUltimaOra)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoGrafico
            // 
            this.cmbTipoGrafico.DataSource = this.objCmbBindingSource;
            this.cmbTipoGrafico.DisplayMember = "Descrizione";
            this.cmbTipoGrafico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoGrafico.FormattingEnabled = true;
            this.cmbTipoGrafico.Location = new System.Drawing.Point(6, 3);
            this.cmbTipoGrafico.Name = "cmbTipoGrafico";
            this.cmbTipoGrafico.Size = new System.Drawing.Size(501, 28);
            this.cmbTipoGrafico.TabIndex = 45;
            this.cmbTipoGrafico.ValueMember = "Colonna";
            this.cmbTipoGrafico.SelectedIndexChanged += new System.EventHandler(this.cmbTipoGrafico_SelectedIndexChanged);
            // 
            // objCmbBindingSource
            // 
            this.objCmbBindingSource.DataSource = typeof(QVLEGSCOG2362.Pagine.SottoPagine.UCPaginaViewStat2Dettaglio.ObjCmb);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblTurnoPrecedente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartTurnoPrecedente, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTurnoAttuale, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chartTurnoAttuale, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblUltimaOra, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chartUltimaOra, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(856, 433);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // lblTurnoPrecedente
            // 
            this.lblTurnoPrecedente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTurnoPrecedente.AutoSize = true;
            this.lblTurnoPrecedente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoPrecedente.Location = new System.Drawing.Point(317, 0);
            this.lblTurnoPrecedente.Name = "lblTurnoPrecedente";
            this.lblTurnoPrecedente.Size = new System.Drawing.Size(221, 20);
            this.lblTurnoPrecedente.TabIndex = 48;
            this.lblTurnoPrecedente.Text = "LBL_TURNO_PRECEDENTE";
            // 
            // chartTurnoPrecedente
            // 
            this.chartTurnoPrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartTurnoPrecedente.ChartAreas.Add(chartArea1);
            this.chartTurnoPrecedente.Location = new System.Drawing.Point(3, 23);
            this.chartTurnoPrecedente.Name = "chartTurnoPrecedente";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartTurnoPrecedente.Series.Add(series1);
            this.chartTurnoPrecedente.Size = new System.Drawing.Size(850, 118);
            this.chartTurnoPrecedente.TabIndex = 44;
            this.chartTurnoPrecedente.Text = "chart1";
            // 
            // lblTurnoAttuale
            // 
            this.lblTurnoAttuale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTurnoAttuale.AutoSize = true;
            this.lblTurnoAttuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoAttuale.Location = new System.Drawing.Point(336, 144);
            this.lblTurnoAttuale.Name = "lblTurnoAttuale";
            this.lblTurnoAttuale.Size = new System.Drawing.Size(184, 20);
            this.lblTurnoAttuale.TabIndex = 50;
            this.lblTurnoAttuale.Text = "LBL_TURNO_ATTUALE";
            // 
            // chartTurnoAttuale
            // 
            this.chartTurnoAttuale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartTurnoAttuale.ChartAreas.Add(chartArea2);
            this.chartTurnoAttuale.Location = new System.Drawing.Point(3, 167);
            this.chartTurnoAttuale.Name = "chartTurnoAttuale";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chartTurnoAttuale.Series.Add(series2);
            this.chartTurnoAttuale.Size = new System.Drawing.Size(850, 118);
            this.chartTurnoAttuale.TabIndex = 48;
            this.chartTurnoAttuale.Text = "chart1";
            // 
            // lblUltimaOra
            // 
            this.lblUltimaOra.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUltimaOra.AutoSize = true;
            this.lblUltimaOra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaOra.Location = new System.Drawing.Point(353, 288);
            this.lblUltimaOra.Name = "lblUltimaOra";
            this.lblUltimaOra.Size = new System.Drawing.Size(150, 20);
            this.lblUltimaOra.TabIndex = 51;
            this.lblUltimaOra.Text = "LBL_ULTIMA_ORA";
            // 
            // chartUltimaOra
            // 
            this.chartUltimaOra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartUltimaOra.ChartAreas.Add(chartArea3);
            this.chartUltimaOra.Location = new System.Drawing.Point(3, 311);
            this.chartUltimaOra.Name = "chartUltimaOra";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chartUltimaOra.Series.Add(series3);
            this.chartUltimaOra.Size = new System.Drawing.Size(850, 119);
            this.chartUltimaOra.TabIndex = 49;
            this.chartUltimaOra.Text = "chart1";
            // 
            // UCPaginaViewStat2Dettaglio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmbTipoGrafico);
            this.DoubleBuffered = true;
            this.Name = "UCPaginaViewStat2Dettaglio";
            this.Size = new System.Drawing.Size(865, 473);
            ((System.ComponentModel.ISupportInitialize)(this.objCmbBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoPrecedente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnoAttuale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUltimaOra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbTipoGrafico;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblUltimaOra;
        private System.Windows.Forms.Label lblTurnoAttuale;
        private System.Windows.Forms.Label lblTurnoPrecedente;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnoAttuale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUltimaOra;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnoPrecedente;
        private System.Windows.Forms.BindingSource objCmbBindingSource;
    }
}
