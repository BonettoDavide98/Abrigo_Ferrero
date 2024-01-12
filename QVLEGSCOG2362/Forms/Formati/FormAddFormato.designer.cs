namespace QVLEGSCOG2362
{
    partial class FormAddFormato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFormato));
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.rbTemplate1 = new System.Windows.Forms.RadioButton();
            this.rbTemplate2 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.tbModo = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rbModoSingolo = new System.Windows.Forms.RadioButton();
            this.rbModoScatola = new System.Windows.Forms.RadioButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(225, 15);
            this.txtId.Margin = new System.Windows.Forms.Padding(6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(381, 31);
            this.txtId.TabIndex = 2;
            this.txtId.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(225, 58);
            this.txtDescrizione.Margin = new System.Windows.Forms.Padding(6);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(381, 31);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.Enter += new System.EventHandler(this.txt_DescrizioneEnter);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblId.Location = new System.Drawing.Point(11, 18);
            this.lblId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(82, 25);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "LBL_ID";
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.AutoSize = true;
            this.lblDescrizione.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDescrizione.Location = new System.Drawing.Point(11, 61);
            this.lblDescrizione.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(203, 25);
            this.lblDescrizione.TabIndex = 5;
            this.lblDescrizione.Text = "LBL_DESCRIZIONE";
            // 
            // rbTemplate1
            // 
            this.rbTemplate1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbTemplate1.AutoSize = true;
            this.rbTemplate1.Checked = true;
            this.rbTemplate1.Location = new System.Drawing.Point(39, 12);
            this.rbTemplate1.Name = "rbTemplate1";
            this.rbTemplate1.Size = new System.Drawing.Size(216, 29);
            this.rbTemplate1.TabIndex = 6;
            this.rbTemplate1.TabStop = true;
            this.rbTemplate1.Text = "LBL_TEMPLATE_1";
            this.rbTemplate1.UseVisualStyleBackColor = true;
            // 
            // rbTemplate2
            // 
            this.rbTemplate2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbTemplate2.AutoSize = true;
            this.rbTemplate2.Location = new System.Drawing.Point(334, 12);
            this.rbTemplate2.Name = "rbTemplate2";
            this.rbTemplate2.Size = new System.Drawing.Size(216, 29);
            this.rbTemplate2.TabIndex = 7;
            this.rbTemplate2.Text = "LBL_TEMPLATE_2";
            this.rbTemplate2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rbTemplate1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbTemplate2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 98);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 202);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.rotondo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(298, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(289, 143);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.rettangolare;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 143);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.Image = global::QVLEGSCOG2362.Properties.Resources.imgChiudi;
            this.btnAnnulla.Location = new System.Drawing.Point(403, 514);
            this.btnAnnulla.Margin = new System.Windows.Forms.Padding(6);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(203, 58);
            this.btnAnnulla.TabIndex = 1;
            this.btnAnnulla.Text = "BTN_ANNULLA";
            this.btnAnnulla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.Image = global::QVLEGSCOG2362.Properties.Resources.imgApplica;
            this.btnSalva.Location = new System.Drawing.Point(188, 514);
            this.btnSalva.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(203, 58);
            this.btnSalva.TabIndex = 0;
            this.btnSalva.Text = "BTN_SALVA";
            this.btnSalva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // tbModo
            // 
            this.tbModo.ColumnCount = 2;
            this.tbModo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbModo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbModo.Controls.Add(this.pictureBox3, 1, 1);
            this.tbModo.Controls.Add(this.rbModoSingolo, 0, 0);
            this.tbModo.Controls.Add(this.rbModoScatola, 1, 0);
            this.tbModo.Controls.Add(this.pictureBox4, 0, 1);
            this.tbModo.Location = new System.Drawing.Point(16, 303);
            this.tbModo.Name = "tbModo";
            this.tbModo.RowCount = 2;
            this.tbModo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbModo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tbModo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbModo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbModo.Size = new System.Drawing.Size(590, 202);
            this.tbModo.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.Scatola;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(298, 56);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(289, 143);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // rbModoSingolo
            // 
            this.rbModoSingolo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbModoSingolo.AutoSize = true;
            this.rbModoSingolo.Checked = true;
            this.rbModoSingolo.Location = new System.Drawing.Point(22, 12);
            this.rbModoSingolo.Name = "rbModoSingolo";
            this.rbModoSingolo.Size = new System.Drawing.Size(251, 29);
            this.rbModoSingolo.TabIndex = 6;
            this.rbModoSingolo.TabStop = true;
            this.rbModoSingolo.Text = "LBL_MODO_SINGOLO";
            this.rbModoSingolo.UseVisualStyleBackColor = true;
            // 
            // rbModoScatola
            // 
            this.rbModoScatola.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbModoScatola.AutoSize = true;
            this.rbModoScatola.Location = new System.Drawing.Point(315, 12);
            this.rbModoScatola.Name = "rbModoScatola";
            this.rbModoScatola.Size = new System.Drawing.Size(255, 29);
            this.rbModoScatola.TabIndex = 7;
            this.rbModoScatola.Text = "LBL_MODO_SCATOLA";
            this.rbModoScatola.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.rettangolare;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(3, 56);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(289, 143);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // FormAddFormato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(621, 580);
            this.ControlBox = false;
            this.Controls.Add(this.lblDescrizione);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.tbModo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormAddFormato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LBL_FRM_ADD_FORMATO";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbModo.ResumeLayout(false);
            this.tbModo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.RadioButton rbTemplate1;
        private System.Windows.Forms.RadioButton rbTemplate2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tbModo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton rbModoSingolo;
        private System.Windows.Forms.RadioButton rbModoScatola;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}