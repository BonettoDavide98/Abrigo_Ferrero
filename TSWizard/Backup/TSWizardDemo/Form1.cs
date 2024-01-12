using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TSWizardDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button runWizard;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.runWizard = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// runWizard
			// 
			this.runWizard.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.runWizard.Location = new System.Drawing.Point(79, 26);
			this.runWizard.Name = "runWizard";
			this.runWizard.TabIndex = 0;
			this.runWizard.Text = "Run Wizard";
			this.runWizard.Click += new System.EventHandler(this.runWizard_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 75);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.runWizard});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void runWizard_Click(object sender, System.EventArgs e)
		{
			DemoWizard wizard = new DemoWizard();

			wizard.ShowDialog();
		}
	}
}
