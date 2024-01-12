using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace TSWizardDemo
{
	public class Step3 : TSWizards.BaseStep
	{
		private System.Windows.Forms.TextBox orderConfirm;
        private Label label1;
		private System.ComponentModel.IContainer components = null;

		public Step3()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			Logo = new Bitmap(typeof(Step3), "customLogo.jpg");
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
            this.orderConfirm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Text = "Please confirm your order.  If you are satisfied with your choices click next to " +
                "have our talented chef prepare your order before your very eyes!";
            // 
            // orderConfirm
            // 
            this.orderConfirm.Location = new System.Drawing.Point(8, 8);
            this.orderConfirm.Multiline = true;
            this.orderConfirm.Name = "orderConfirm";
            this.orderConfirm.ReadOnly = true;
            this.orderConfirm.Size = new System.Drawing.Size(440, 185);
            this.orderConfirm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "step3";
            // 
            // Step3
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderConfirm);
            this.Name = "Step3";
            this.NextStep = "Step4";
            this.PreviousStep = "Step2";
            this.StepDescription = "Please confirm your order.  If you are satisfied with your choices click next to " +
                "have our talented chef prepare your order before your very eyes!";
            this.StepTitle = "Order confirmation";
            this.ShowStep += new TSWizards.ShowStepEventHandler(this.Step3_ShowStep);
            this.Controls.SetChildIndex(this.orderConfirm, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Description, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Step3_ShowStep(object sender, TSWizards.ShowStepEventArgs e)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			Step2 step2 = Wizard.GetStep("Step2") as Step2;

			if( step2 == null )
			{
				throw new ApplicationException("Step2 of the wizard wasn't really step2");
			}

			StringCollection order = step2.GetOrder();

			foreach(string item in order)
			{
				sb.AppendFormat("{0},\r\n", item);
			}

			orderConfirm.Text = sb.ToString();
		}
	}
}

