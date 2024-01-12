namespace QVLEGSCOG2362
{
    partial class FormRicette
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dvgFormatiIntestazione = new System.Windows.Forms.DataGridView();
            this.dgvColDescrizioneFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.btnCopiaFormato = new System.Windows.Forms.Button();
            this.btnNuovoFormato = new System.Windows.Forms.Button();
            this.btnEliminaFormatoGenerale = new System.Windows.Forms.Button();
            this.btnCaricaFormatoAllCamera = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.dgvColIdFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatoIntestazioneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFormatiIntestazione)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatoIntestazioneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnCopiaFormato, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnNuovoFormato, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEliminaFormatoGenerale, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnCaricaFormatoAllCamera, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(667, 37);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(130, 298);
            this.tableLayoutPanel2.TabIndex = 46;
            // 
            // dvgFormatiIntestazione
            // 
            this.dvgFormatiIntestazione.AllowUserToAddRows = false;
            this.dvgFormatiIntestazione.AllowUserToDeleteRows = false;
            this.dvgFormatiIntestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgFormatiIntestazione.AutoGenerateColumns = false;
            this.dvgFormatiIntestazione.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgFormatiIntestazione.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgFormatiIntestazione.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgFormatiIntestazione.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgFormatiIntestazione.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColIdFormato,
            this.dgvColDescrizioneFormato});
            this.dvgFormatiIntestazione.DataSource = this.formatoIntestazioneBindingSource;
            this.dvgFormatiIntestazione.Location = new System.Drawing.Point(3, 37);
            this.dvgFormatiIntestazione.MultiSelect = false;
            this.dvgFormatiIntestazione.Name = "dvgFormatiIntestazione";
            this.dvgFormatiIntestazione.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgFormatiIntestazione.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgFormatiIntestazione.RowTemplate.Height = 35;
            this.dvgFormatiIntestazione.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgFormatiIntestazione.Size = new System.Drawing.Size(658, 562);
            this.dvgFormatiIntestazione.TabIndex = 47;
            // 
            // dgvColDescrizioneFormato
            // 
            this.dgvColDescrizioneFormato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvColDescrizioneFormato.DataPropertyName = "DescrizioneFormato";
            this.dgvColDescrizioneFormato.HeaderText = "LBL_DESCRIZIONE";
            this.dgvColDescrizioneFormato.Name = "dgvColDescrizioneFormato";
            this.dgvColDescrizioneFormato.ReadOnly = true;
            // 
            // lblTitolo
            // 
            this.lblTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitolo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitolo.Location = new System.Drawing.Point(3, 2);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(790, 32);
            this.lblTitolo.TabIndex = 45;
            this.lblTitolo.Text = "LBL_FRM_FORMATI";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCopiaFormato
            // 
            this.btnCopiaFormato.BackColor = System.Drawing.Color.White;
            this.btnCopiaFormato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopiaFormato.FlatAppearance.BorderSize = 0;
            this.btnCopiaFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiaFormato.Image = global::QVLEGSCOG2362.Properties.Resources.imgCopia;
            this.btnCopiaFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiaFormato.Location = new System.Drawing.Point(3, 72);
            this.btnCopiaFormato.Name = "btnCopiaFormato";
            this.btnCopiaFormato.Size = new System.Drawing.Size(124, 63);
            this.btnCopiaFormato.TabIndex = 45;
            this.btnCopiaFormato.Text = "BTN_COPIA";
            this.btnCopiaFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiaFormato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopiaFormato.UseVisualStyleBackColor = false;
            this.btnCopiaFormato.Click += new System.EventHandler(this.btnCopiaFormato_Click);
            // 
            // btnNuovoFormato
            // 
            this.btnNuovoFormato.BackColor = System.Drawing.Color.White;
            this.btnNuovoFormato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNuovoFormato.FlatAppearance.BorderSize = 0;
            this.btnNuovoFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuovoFormato.Image = global::QVLEGSCOG2362.Properties.Resources.imgNuovo;
            this.btnNuovoFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuovoFormato.Location = new System.Drawing.Point(3, 3);
            this.btnNuovoFormato.Name = "btnNuovoFormato";
            this.btnNuovoFormato.Size = new System.Drawing.Size(124, 63);
            this.btnNuovoFormato.TabIndex = 28;
            this.btnNuovoFormato.Text = "BTN_NUOVO";
            this.btnNuovoFormato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuovoFormato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuovoFormato.UseVisualStyleBackColor = false;
            this.btnNuovoFormato.Click += new System.EventHandler(this.btnNuovoFormato_Click);
            // 
            // btnEliminaFormatoGenerale
            // 
            this.btnEliminaFormatoGenerale.BackColor = System.Drawing.Color.White;
            this.btnEliminaFormatoGenerale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminaFormatoGenerale.FlatAppearance.BorderSize = 0;
            this.btnEliminaFormatoGenerale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminaFormatoGenerale.Image = global::QVLEGSCOG2362.Properties.Resources.imgGomma;
            this.btnEliminaFormatoGenerale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminaFormatoGenerale.Location = new System.Drawing.Point(3, 141);
            this.btnEliminaFormatoGenerale.Name = "btnEliminaFormatoGenerale";
            this.btnEliminaFormatoGenerale.Size = new System.Drawing.Size(124, 63);
            this.btnEliminaFormatoGenerale.TabIndex = 37;
            this.btnEliminaFormatoGenerale.Text = "BTN_ELIMINA";
            this.btnEliminaFormatoGenerale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminaFormatoGenerale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminaFormatoGenerale.UseVisualStyleBackColor = false;
            this.btnEliminaFormatoGenerale.Click += new System.EventHandler(this.btnEliminaFormatoGenerale_Click);
            // 
            // btnCaricaFormatoAllCamera
            // 
            this.btnCaricaFormatoAllCamera.BackColor = System.Drawing.Color.White;
            this.btnCaricaFormatoAllCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCaricaFormatoAllCamera.FlatAppearance.BorderSize = 0;
            this.btnCaricaFormatoAllCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaricaFormatoAllCamera.Image = global::QVLEGSCOG2362.Properties.Resources.imgApplica;
            this.btnCaricaFormatoAllCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaricaFormatoAllCamera.Location = new System.Drawing.Point(3, 210);
            this.btnCaricaFormatoAllCamera.Name = "btnCaricaFormatoAllCamera";
            this.btnCaricaFormatoAllCamera.Size = new System.Drawing.Size(124, 63);
            this.btnCaricaFormatoAllCamera.TabIndex = 35;
            this.btnCaricaFormatoAllCamera.Text = "BTN_CARICA ";
            this.btnCaricaFormatoAllCamera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCaricaFormatoAllCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaricaFormatoAllCamera.UseVisualStyleBackColor = false;
            this.btnCaricaFormatoAllCamera.Click += new System.EventHandler(this.btnCaricaFormatoAllCamera_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.CloseSmall;
            this.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChiudi.FlatAppearance.BorderSize = 0;
            this.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiudi.Location = new System.Drawing.Point(748, 2);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(49, 32);
            this.btnChiudi.TabIndex = 48;
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // dgvColIdFormato
            // 
            this.dgvColIdFormato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvColIdFormato.DataPropertyName = "IdFormato";
            this.dgvColIdFormato.HeaderText = "LBL_ID";
            this.dgvColIdFormato.Name = "dgvColIdFormato";
            this.dgvColIdFormato.ReadOnly = true;
            this.dgvColIdFormato.Width = 94;
            // 
            // formatoIntestazioneBindingSource
            // 
            this.formatoIntestazioneBindingSource.DataSource = typeof(QVLEGSCOG2362.DataType.Formato);
            // 
            // FormRicette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.dvgFormatiIntestazione);
            this.Controls.Add(this.lblTitolo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRicette";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormRicette";
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgFormatiIntestazione)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatoIntestazioneBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCopiaFormato;
        private System.Windows.Forms.Button btnNuovoFormato;
        private System.Windows.Forms.Button btnEliminaFormatoGenerale;
        private System.Windows.Forms.Button btnCaricaFormatoAllCamera;
        private System.Windows.Forms.DataGridView dvgFormatiIntestazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColIdFormato;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColDescrizioneFormato;
        private System.Windows.Forms.BindingSource formatoIntestazioneBindingSource;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.Button btnChiudi;
    }
}