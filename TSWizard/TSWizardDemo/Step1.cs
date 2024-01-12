using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace TSWizardDemo
{
	public class Step1 : TSWizards.BaseExteriorStep
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox noShowWelcome;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components = null;

		public Step1()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			SideBarImage = new Bitmap(typeof(Step1), "customSideBarImage.jpg");
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.noShowWelcome = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Size = new System.Drawing.Size(312, 48);
			this.Description.Text = "Welcome to the Wait On Us ordering wizard!";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.Location = new System.Drawing.Point(24, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Click next to proceed with your order";
			// 
			// noShowWelcome
			// 
			this.noShowWelcome.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.noShowWelcome.Location = new System.Drawing.Point(8, 288);
			this.noShowWelcome.Name = "noShowWelcome";
			this.noShowWelcome.Size = new System.Drawing.Size(240, 24);
			this.noShowWelcome.TabIndex = 2;
			this.noShowWelcome.Text = "Don\'t show this welcome screen again";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(280, 32);
			this.label2.TabIndex = 3;
			this.label2.Text = "In this wizard I will take your order then fetch it in 30 seconds or less; or els" +
				"e its free!";
			// 
			// Step1
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Description,
																		  this.label2,
																		  this.noShowWelcome,
																		  this.label1});
			this.Name = "Step1";
			this.NextStep = "Step2";
			this.StepDescription = "Welcome to the Wait On Us ordering wizard!";
			this.StepTitle = "Welcome to the Wait On Us ordering wizard!";
			this.ResumeLayout(false);

		}
		#endregion

		public bool NoShowWelcomeAgain
		{
			get
			{
				return noShowWelcome.Checked;
			}
			set
			{
				noShowWelcome.Checked = value;
			}
		}
	}
}

