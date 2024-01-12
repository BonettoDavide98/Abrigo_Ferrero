using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace TSWizardDemo
{
	public class Step5 : TSWizards.BaseExteriorStep
	{
		private System.Windows.Forms.CheckBox runAgain;
		private TSWizards.Controls.BulletList itemsPrepared;
		private System.ComponentModel.IContainer components = null;

		public Step5()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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
			this.runAgain = new System.Windows.Forms.CheckBox();
			this.itemsPrepared = new TSWizards.Controls.BulletList();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Text = "Your order is complete!";
			// 
			// runAgain
			// 
			this.runAgain.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.runAgain.Location = new System.Drawing.Point(8, 280);
			this.runAgain.Name = "runAgain";
			this.runAgain.Size = new System.Drawing.Size(208, 32);
			this.runAgain.TabIndex = 1;
			this.runAgain.Text = "Would you like to run the Wait On Us order wizard again?";
			// 
			// itemsPrepared
			// 
			this.itemsPrepared.Location = new System.Drawing.Point(32, 64);
			this.itemsPrepared.Name = "itemsPrepared";
			this.itemsPrepared.Size = new System.Drawing.Size(264, 208);
			this.itemsPrepared.TabIndex = 2;
			this.itemsPrepared.Text = "We have prepared the following for you:";
			// 
			// Step5
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.itemsPrepared,
																		  this.Description,
																		  this.runAgain});
			this.IsFinished = true;
			this.Name = "Step5";
			this.NextStep = "FINISHED";
			this.StepDescription = "Your order is complete!";
			this.StepTitle = "Done!";
			this.ShowStep += new TSWizards.ShowStepEventHandler(this.Step5_ShowStep);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnFinish()
		{
			if( runAgain.Checked )
			{
				string moveTo;
				
				Step1 step1 = Wizard.GetStep("Step1") as Step1;

				if( !step1.NoShowWelcomeAgain )
					moveTo = "Step1";
				else
					moveTo = "Step2";
				
				Wizard.ResetSteps();

				Wizard.MoveTo(moveTo);
			}
			else
			{
				base.OnFinish();
			}
		}

		private void Step5_ShowStep(object sender, TSWizards.ShowStepEventArgs e)
		{
			Step2 step2 = Wizard.GetStep("Step2") as Step2;
			System.Collections.Specialized.StringCollection order = step2.GetOrder();

			itemsPrepared.Items.Clear();

			foreach(string str in order)
			{
				itemsPrepared.Items.Add(str);
			}
		}
	}
}

