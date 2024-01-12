namespace QVLEGSCOG2362
{
    partial class FrmGestioneTurni
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestioneTurni));
            this.turniDataGridView = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.nomeTurnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oraInizioTurnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oraFineTurnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giornoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orariTurniBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.turniDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orariTurniBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // turniDataGridView
            // 
            this.turniDataGridView.AllowUserToAddRows = false;
            this.turniDataGridView.AllowUserToDeleteRows = false;
            this.turniDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.turniDataGridView.AutoGenerateColumns = false;
            this.turniDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.turniDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.turniDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turniDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeTurnoDataGridViewTextBoxColumn,
            this.oraInizioTurnoDataGridViewTextBoxColumn,
            this.oraFineTurnoDataGridViewTextBoxColumn,
            this.giornoDataGridViewTextBoxColumn});
            this.turniDataGridView.DataSource = this.orariTurniBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.turniDataGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.turniDataGridView.Location = new System.Drawing.Point(12, 12);
            this.turniDataGridView.Name = "turniDataGridView";
            this.turniDataGridView.ReadOnly = true;
            this.turniDataGridView.RowHeadersWidth = 6;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turniDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.turniDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.turniDataGridView.Size = new System.Drawing.Size(682, 400);
            this.turniDataGridView.TabIndex = 1020;
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
            this.btnClose.Location = new System.Drawing.Point(841, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 1024;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAggiungi.BackColor = System.Drawing.Color.Transparent;
            this.btnAggiungi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAggiungi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAggiungi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnAggiungi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAggiungi.Image = ((System.Drawing.Image)(resources.GetObject("btnAggiungi.Image")));
            this.btnAggiungi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAggiungi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAggiungi.Location = new System.Drawing.Point(700, 89);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(181, 78);
            this.btnAggiungi.TabIndex = 1025;
            this.btnAggiungi.Text = "BTN_ADD";
            this.btnAggiungi.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAggiungi.UseVisualStyleBackColor = false;
            this.btnAggiungi.Click += new System.EventHandler(this.btnAggiungi_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModifica.BackColor = System.Drawing.Color.Transparent;
            this.btnModifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifica.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnModifica.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModifica.Image = ((System.Drawing.Image)(resources.GetObject("btnModifica.Image")));
            this.btnModifica.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifica.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnModifica.Location = new System.Drawing.Point(700, 173);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(181, 78);
            this.btnModifica.TabIndex = 1026;
            this.btnModifica.Text = "BTN_EDIT";
            this.btnModifica.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnModifica.UseVisualStyleBackColor = false;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnElimina.BackColor = System.Drawing.Color.Transparent;
            this.btnElimina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElimina.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnElimina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnElimina.Image = ((System.Drawing.Image)(resources.GetObject("btnElimina.Image")));
            this.btnElimina.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnElimina.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnElimina.Location = new System.Drawing.Point(700, 257);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(181, 78);
            this.btnElimina.TabIndex = 1027;
            this.btnElimina.Text = "BTN_DELETE";
            this.btnElimina.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnElimina.UseVisualStyleBackColor = false;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // nomeTurnoDataGridViewTextBoxColumn
            // 
            this.nomeTurnoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeTurnoDataGridViewTextBoxColumn.DataPropertyName = "NomeTurno";
            this.nomeTurnoDataGridViewTextBoxColumn.HeaderText = "NomeTurno";
            this.nomeTurnoDataGridViewTextBoxColumn.Name = "nomeTurnoDataGridViewTextBoxColumn";
            this.nomeTurnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oraInizioTurnoDataGridViewTextBoxColumn
            // 
            this.oraInizioTurnoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oraInizioTurnoDataGridViewTextBoxColumn.DataPropertyName = "OraInizioTurno";
            this.oraInizioTurnoDataGridViewTextBoxColumn.HeaderText = "OraInizioTurno";
            this.oraInizioTurnoDataGridViewTextBoxColumn.Name = "oraInizioTurnoDataGridViewTextBoxColumn";
            this.oraInizioTurnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // oraFineTurnoDataGridViewTextBoxColumn
            // 
            this.oraFineTurnoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oraFineTurnoDataGridViewTextBoxColumn.DataPropertyName = "OraFineTurno";
            this.oraFineTurnoDataGridViewTextBoxColumn.HeaderText = "OraFineTurno";
            this.oraFineTurnoDataGridViewTextBoxColumn.Name = "oraFineTurnoDataGridViewTextBoxColumn";
            this.oraFineTurnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // giornoDataGridViewTextBoxColumn
            // 
            this.giornoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.giornoDataGridViewTextBoxColumn.DataPropertyName = "Giorno";
            this.giornoDataGridViewTextBoxColumn.HeaderText = "Giorno";
            this.giornoDataGridViewTextBoxColumn.Name = "giornoDataGridViewTextBoxColumn";
            this.giornoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orariTurniBindingSource
            // 
            this.orariTurniBindingSource.DataSource = typeof(QVLEGSCOG2362.DataType.Definizione_Turni);
            // 
            // FrmGestioneTurni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 424);
            this.ControlBox = false;
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.turniDataGridView);
            this.Name = "FrmGestioneTurni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BTN_GESTIONE_TURNI";
            ((System.ComponentModel.ISupportInitialize)(this.turniDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orariTurniBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView turniDataGridView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.BindingSource orariTurniBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inizioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeTurnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oraInizioTurnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oraFineTurnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giornoDataGridViewTextBoxColumn;
    }
}