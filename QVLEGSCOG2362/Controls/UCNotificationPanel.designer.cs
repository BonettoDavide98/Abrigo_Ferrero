namespace QVLEGSCOG2362
{
    partial class UCNotificationPanel
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
            this.components = new System.ComponentModel.Container();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.timerAsyncOperations = new System.Windows.Forms.Timer(this.components);
            this.buttonResetMessages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMessages.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMessages.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.ItemHeight = 20;
            this.listBoxMessages.Location = new System.Drawing.Point(0, 0);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(1220, 120);
            this.listBoxMessages.TabIndex = 1;
            // 
            // timerAsyncOperations
            // 
            this.timerAsyncOperations.Enabled = true;
            this.timerAsyncOperations.Interval = 200;
            this.timerAsyncOperations.Tick += new System.EventHandler(this.timerAsyncOperations_Tick);
            // 
            // buttonResetMessages
            // 
            this.buttonResetMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetMessages.BackColor = System.Drawing.SystemColors.Control;
            this.buttonResetMessages.BackgroundImage = global::QVLEGSCOG2362.Properties.Resources.closeDark;
            this.buttonResetMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonResetMessages.FlatAppearance.BorderSize = 0;
            this.buttonResetMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetMessages.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonResetMessages.Location = new System.Drawing.Point(1220, 0);
            this.buttonResetMessages.Name = "buttonResetMessages";
            this.buttonResetMessages.Size = new System.Drawing.Size(30, 120);
            this.buttonResetMessages.TabIndex = 67;
            this.buttonResetMessages.UseVisualStyleBackColor = false;
            this.buttonResetMessages.Click += new System.EventHandler(this.buttonResetMessages_Click);
            // 
            // UCNotificationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonResetMessages);
            this.Controls.Add(this.listBoxMessages);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCNotificationPanel";
            this.Size = new System.Drawing.Size(1256, 147);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.Timer timerAsyncOperations;
        private System.Windows.Forms.Button buttonResetMessages;
    }
}
