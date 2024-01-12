namespace QVLEGSCOG2362
{
    partial class UCTrackBar
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
            this.ucTrackBarBase1 = new QVLEGSCOG2362.UCTrackBarBase();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nudMax = new QVLEGSCOG2362.UCNumericUpDown();
            this.nudMin = new QVLEGSCOG2362.UCNumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucTrackBarBase1
            // 
            this.ucTrackBarBase1.BackColor = System.Drawing.SystemColors.Control;
            this.ucTrackBarBase1.ColoraHue = false;
            this.ucTrackBarBase1.ColoraTutto = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ucTrackBarBase1, 2);
            this.ucTrackBarBase1.CursoreMassimo = QVLEGSCOG2362.UCTrackBarBase.FormaCursore.Linea;
            this.ucTrackBarBase1.CursoreMinimo = QVLEGSCOG2362.UCTrackBarBase.FormaCursore.Linea;
            this.ucTrackBarBase1.Descrizione = "";
            this.ucTrackBarBase1.DimensioneBarra = 12;
            this.ucTrackBarBase1.DimensioneFreccia = 15;
            this.ucTrackBarBase1.Disegno = QVLEGSCOG2362.UCTrackBarBase.TipoDisegno.Interno;
            this.ucTrackBarBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTrackBarBase1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTrackBarBase1.Location = new System.Drawing.Point(3, 3);
            this.ucTrackBarBase1.Margine = 20;
            this.ucTrackBarBase1.Maximum = 255;
            this.ucTrackBarBase1.Minimum = 0;
            this.ucTrackBarBase1.Name = "ucTrackBarBase1";
            this.ucTrackBarBase1.PosizioneBarra = 20;
            this.ucTrackBarBase1.PosizioneStep = 35;
            this.ucTrackBarBase1.PrimoColore = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ucTrackBarBase1.RotazioneStep = QVLEGSCOG2362.UCTrackBarBase.Rotazione.Zero;
            this.ucTrackBarBase1.SecondoColore = System.Drawing.Color.Cornsilk;
            this.ucTrackBarBase1.Size = new System.Drawing.Size(600, 54);
            this.ucTrackBarBase1.StepDisplayValue = 25;
            this.ucTrackBarBase1.TabIndex = 0;
            this.ucTrackBarBase1.UsaDoppioValore = true;
            this.ucTrackBarBase1.ValueMax = 250;
            this.ucTrackBarBase1.ValueMin = 5;
            this.ucTrackBarBase1.VisuaizzaValori = false;
            this.ucTrackBarBase1.VisualizzaStep = true;
            this.ucTrackBarBase1.ValueChanged += new System.EventHandler(this.ucTrackBarBase1_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nudMax, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ucTrackBarBase1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudMin, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // nudMax
            // 
            this.nudMax.DecimalPlaces = 0;
            this.nudMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMax.Location = new System.Drawing.Point(309, 66);
            this.nudMax.Margin = new System.Windows.Forms.Padding(6);
            this.nudMax.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMax.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMax.Name = "nudMax";
            this.nudMax.Size = new System.Drawing.Size(291, 28);
            this.nudMax.TabIndex = 2;
            this.nudMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMax.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMax.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // nudMin
            // 
            this.nudMin.DecimalPlaces = 0;
            this.nudMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMin.Location = new System.Drawing.Point(6, 66);
            this.nudMin.Margin = new System.Windows.Forms.Padding(6);
            this.nudMin.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMin.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(291, 28);
            this.nudMin.TabIndex = 1;
            this.nudMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMin.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMin.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // UCTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCTrackBar";
            this.Size = new System.Drawing.Size(606, 100);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCTrackBarBase ucTrackBarBase1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UCNumericUpDown nudMax;
        private UCNumericUpDown nudMin;
    }
}
