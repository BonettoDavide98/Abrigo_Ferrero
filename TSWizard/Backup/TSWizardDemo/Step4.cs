using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace TSWizardDemo
{
	public class Step4 : TSWizards.BaseStep
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label preparing;
		private System.Windows.Forms.ProgressBar progress;
		private System.ComponentModel.IContainer components = null;

		public Step4()
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
			this.label1 = new System.Windows.Forms.Label();
			this.preparing = new System.Windows.Forms.Label();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Text = "Our world class chef is now preparing your order, please wait";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Now preparing:";
			// 
			// preparing
			// 
			this.preparing.AutoSize = true;
			this.preparing.Location = new System.Drawing.Point(96, 80);
			this.preparing.Name = "preparing";
			this.preparing.Size = new System.Drawing.Size(44, 13);
			this.preparing.TabIndex = 2;
			this.preparing.Text = "{FOOD}";
			// 
			// progress
			// 
			this.progress.Anchor = (System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.progress.Location = new System.Drawing.Point(24, 104);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(424, 23);
			this.progress.TabIndex = 3;
			// 
			// Step4
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Description,
																		  this.progress,
																		  this.preparing,
																		  this.label1});
			this.Name = "Step4";
			this.StepDescription = "Our world class chef is now preparing your order, please wait";
			this.StepTitle = "Now preparing!";
			this.ShowStep += new TSWizards.ShowStepEventHandler(this.Step4_ShowStep);
			this.ResumeLayout(false);

		}
		#endregion

		private void Step4_ShowStep(object sender, TSWizards.ShowStepEventArgs e)
		{
			MethodInvoker mi = new MethodInvoker( this.DoWork );

			mi.BeginInvoke(new AsyncCallback(DonePreparing), null);
		}

		private void DoWork()
		{
			Step2 step2 = Wizard.GetStep("Step2") as Step2;

			if( step2 == null )
			{
				throw new ApplicationException("Step2 of the wizard wasn't really step2");
			}

			StringCollection order = step2.GetOrder();

			if( order.Count > 0 )
			{
				BeginPreparingOrder(order.Count);

				foreach(string item in order)
				{
					Preparing(item);
					Thread.Sleep(1000);
					Prepared();
				}
			}
		}

		private void BeginPreparingOrder(int items)
		{
			if( InvokeRequired )
			{
				this.Invoke( new IntDelegate(BeginPreparingOrder), new object [] { items } );
				return ;
			}

			progress.Maximum = items * 10;
			progress.Value = 0;
		}

		private void Preparing(string item)
		{
			if( InvokeRequired )
			{
				this.Invoke( new StringDelegate(Preparing), new object [] { item } );
				return ;
			}

			preparing.Text = item;
		}

		private void Prepared()
		{
			if( InvokeRequired )
			{
				this.Invoke( new MethodInvoker(Prepared), new object [] { } );
				return ;
			}

			progress.PerformStep();
		}

		private void DonePreparing(IAsyncResult result)
		{
			if( InvokeRequired )
			{
				Invoke(new AsyncCallback(DonePreparing), new Object [] { result } );
				return ;
			}

			NextStep = "Step5";
			Wizard.MoveNext();
		}

		private delegate void IntDelegate(int num);
		private delegate void StringDelegate(string str);
	}
}

