namespace QVLEGSCOG2362
{
    partial class UCEditSoglia
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudMax = new QVLEGSCOG2362.UCNumericUpDown();
            this.nudMin = new QVLEGSCOG2362.UCNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IsLogarithmic = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(219, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.MarkerSize = 1;
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(652, 166);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.AnnotationPositionChanged += new System.EventHandler(this.chart1_AnnotationPositionChanged);
            this.chart1.AnnotationPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.AnnotationPositionChangingEventArgs>(this.chart1_AnnotationPositionChanging);
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrizione.Location = new System.Drawing.Point(0, 0);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(219, 96);
            this.lblDescrizione.TabIndex = 1;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDescrizione);
            this.panel1.Controls.Add(this.nudMax);
            this.panel1.Controls.Add(this.nudMin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 166);
            this.panel1.TabIndex = 6;
            // 
            // nudMax
            // 
            this.nudMax.DecimalPlaces = 1;
            this.nudMax.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nudMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMax.Location = new System.Drawing.Point(0, 102);
            this.nudMax.Margin = new System.Windows.Forms.Padding(6);
            this.nudMax.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMax.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(219, 32);
            this.nudMax.TabIndex = 5;
            this.nudMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMax.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudMin
            // 
            this.nudMin.DecimalPlaces = 1;
            this.nudMin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nudMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMin.Location = new System.Drawing.Point(0, 134);
            this.nudMin.Margin = new System.Windows.Forms.Padding(6);
            this.nudMin.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMin.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(219, 32);
            this.nudMin.TabIndex = 4;
            this.nudMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMin.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // UCEditSoglia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "UCEditSoglia";
            this.Size = new System.Drawing.Size(871, 166);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblDescrizione;
        private UCNumericUpDown nudMin;
        private UCNumericUpDown nudMax;
        private System.Windows.Forms.Panel panel1;
    }
}
