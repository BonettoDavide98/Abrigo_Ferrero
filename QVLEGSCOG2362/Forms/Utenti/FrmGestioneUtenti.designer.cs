namespace QVLEGSCOG2362
{
    partial class FrmGestioneUtenti
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestioneUtenti));
            this.utenteDataGridView = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.utenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idUtente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LivelloD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.utenteDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utenteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // utenteDataGridView
            // 
            this.utenteDataGridView.AllowUserToAddRows = false;
            this.utenteDataGridView.AllowUserToDeleteRows = false;
            this.utenteDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.utenteDataGridView.AutoGenerateColumns = false;
            this.utenteDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.utenteDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.utenteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.utenteDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUtente,
            this.username,
            this.passwordDataGridViewTextBoxColumn,
            this.operatoreDataGridViewTextBoxColumn,
            this.LivelloD});
            this.utenteDataGridView.DataSource = this.utenteBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.utenteDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.utenteDataGridView.Location = new System.Drawing.Point(12, 12);
            this.utenteDataGridView.Name = "utenteDataGridView";
            this.utenteDataGridView.ReadOnly = true;
            this.utenteDataGridView.RowHeadersWidth = 6;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utenteDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.utenteDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.utenteDataGridView.Size = new System.Drawing.Size(682, 400);
            this.utenteDataGridView.TabIndex = 1020;
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
            // utenteBindingSource
            // 
            this.utenteBindingSource.DataSource = typeof(QVLEGSCOG2362.DataType.Utente);
            // 
            // idUtente
            // 
            this.idUtente.DataPropertyName = "ID";
            this.idUtente.HeaderText = "ID";
            this.idUtente.Name = "idUtente";
            this.idUtente.ReadOnly = true;
            this.idUtente.Visible = false;
            // 
            // username
            // 
            this.username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.username.DataPropertyName = "Username";
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // operatoreDataGridViewTextBoxColumn
            // 
            this.operatoreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.operatoreDataGridViewTextBoxColumn.DataPropertyName = "Operatore";
            this.operatoreDataGridViewTextBoxColumn.HeaderText = "Operatore";
            this.operatoreDataGridViewTextBoxColumn.Name = "operatoreDataGridViewTextBoxColumn";
            this.operatoreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // LivelloD
            // 
            this.LivelloD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LivelloD.DataPropertyName = "LivelloUtente";
            this.LivelloD.HeaderText = "Livello";
            this.LivelloD.Name = "LivelloD";
            this.LivelloD.ReadOnly = true;
            this.LivelloD.Width = 77;
            // 
            // FrmGestioneUtenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 424);
            this.ControlBox = false;
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.utenteDataGridView);
            this.Name = "FrmGestioneUtenti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BTN_GESTIONE_UTENTI";
            ((System.ComponentModel.ISupportInitialize)(this.utenteDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utenteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource utenteBindingSource; 
        private System.Windows.Forms.DataGridView utenteDataGridView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUtente;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LivelloD;
    }
}