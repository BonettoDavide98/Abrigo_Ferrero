namespace QVLEGSCOG2362
{
    partial class NotificationPanelDgv
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonResetMessages = new System.Windows.Forms.Button();
            this.dgvMessaggi = new System.Windows.Forms.DataGridView();
            this.Messaggio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messaggiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.timerAsyncOperations = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessaggi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messaggiBindingSource)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonResetMessages
            // 
            this.buttonResetMessages.BackColor = System.Drawing.SystemColors.Control;
            this.buttonResetMessages.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.closeDark;
            this.buttonResetMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonResetMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetMessages.FlatAppearance.BorderSize = 0;
            this.buttonResetMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetMessages.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonResetMessages.Location = new System.Drawing.Point(486, 3);
            this.buttonResetMessages.Name = "buttonResetMessages";
            this.buttonResetMessages.Size = new System.Drawing.Size(1, 147);
            this.buttonResetMessages.TabIndex = 68;
            this.buttonResetMessages.UseVisualStyleBackColor = false;
            this.buttonResetMessages.Click += new System.EventHandler(this.buttonResetMessages_Click);
            // 
            // dgvMessaggi
            // 
            this.dgvMessaggi.AllowUserToAddRows = false;
            this.dgvMessaggi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMessaggi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMessaggi.AutoGenerateColumns = false;
            this.dgvMessaggi.BackgroundColor = System.Drawing.Color.White;
            this.dgvMessaggi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessaggi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMessaggi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessaggi.ColumnHeadersVisible = false;
            this.dgvMessaggi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Messaggio});
            this.dgvMessaggi.DataSource = this.messaggiBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMessaggi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMessaggi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMessaggi.EnableHeadersVisualStyles = false;
            this.dgvMessaggi.GridColor = System.Drawing.SystemColors.Control;
            this.dgvMessaggi.Location = new System.Drawing.Point(3, 3);
            this.dgvMessaggi.Name = "dgvMessaggi";
            this.dgvMessaggi.ReadOnly = true;
            this.dgvMessaggi.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMessaggi.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMessaggi.Size = new System.Drawing.Size(477, 147);
            this.dgvMessaggi.TabIndex = 69;
            this.dgvMessaggi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMessaggi_CellClick);
            // 
            // Messaggio
            // 
            this.Messaggio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Messaggio.DataPropertyName = "Messaggio";
            this.Messaggio.HeaderText = "Messaggi";
            this.Messaggio.Name = "Messaggio";
            this.Messaggio.ReadOnly = true;
            // 
            // messaggiBindingSource
            // 
            this.messaggiBindingSource.DataSource = typeof(QVLEGSCOG2362.NotificationPanelDgv.MessaggioDgv);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonResetMessages, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.dgvMessaggi, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(483, 153);
            this.tableLayoutPanelMain.TabIndex = 70;
            // 
            // timerAsyncOperations
            // 
            this.timerAsyncOperations.Enabled = true;
            this.timerAsyncOperations.Interval = 200;
            this.timerAsyncOperations.Tick += new System.EventHandler(this.timerAsyncOperations_Tick);
            // 
            // NotificationPanelDgv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "NotificationPanelDgv";
            this.Size = new System.Drawing.Size(483, 153);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessaggi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messaggiBindingSource)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonResetMessages;
        private System.Windows.Forms.DataGridView dgvMessaggi;
        private System.Windows.Forms.BindingSource messaggiBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Messaggio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Timer timerAsyncOperations;
    }
}
