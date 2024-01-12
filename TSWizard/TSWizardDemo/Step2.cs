using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace TSWizardDemo
{
	public class Step2 : TSWizards.BaseStep
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox caesarSalad;
		private System.Windows.Forms.CheckBox tossedSalad;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox broccoliSoup;
		private System.Windows.Forms.CheckBox clamSoup;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox steakDone;
		private System.Windows.Forms.CheckBox sirloinTip;
		private System.Windows.Forms.ComboBox sirloinDone;
		private System.Windows.Forms.CheckBox fish;
		private System.Windows.Forms.CheckBox chicken;
		private System.Windows.Forms.CheckBox tofu;
		private System.Windows.Forms.CheckBox steak;
		private System.ComponentModel.IContainer components = null;

		public Step2()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			Logo = new Bitmap(typeof(Step2), "customSideBarLogo.jpg");
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tossedSalad = new System.Windows.Forms.CheckBox();
			this.caesarSalad = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.clamSoup = new System.Windows.Forms.CheckBox();
			this.broccoliSoup = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.steak = new System.Windows.Forms.CheckBox();
			this.tofu = new System.Windows.Forms.CheckBox();
			this.chicken = new System.Windows.Forms.CheckBox();
			this.fish = new System.Windows.Forms.CheckBox();
			this.sirloinDone = new System.Windows.Forms.ComboBox();
			this.sirloinTip = new System.Windows.Forms.CheckBox();
			this.steakDone = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Description
			// 
			this.Description.Text = "What would you like to order?";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tossedSalad,
																					this.caesarSalad});
			this.groupBox1.Location = new System.Drawing.Point(24, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 80);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Salads";
			// 
			// tossedSalad
			// 
			this.tossedSalad.Location = new System.Drawing.Point(8, 48);
			this.tossedSalad.Name = "tossedSalad";
			this.tossedSalad.TabIndex = 1;
			this.tossedSalad.Text = "Tossed";
			// 
			// caesarSalad
			// 
			this.caesarSalad.Location = new System.Drawing.Point(8, 16);
			this.caesarSalad.Name = "caesarSalad";
			this.caesarSalad.TabIndex = 0;
			this.caesarSalad.Text = "Caesar";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.clamSoup,
																					this.broccoliSoup});
			this.groupBox2.Location = new System.Drawing.Point(24, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(136, 80);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Soups";
			// 
			// clamSoup
			// 
			this.clamSoup.Location = new System.Drawing.Point(8, 48);
			this.clamSoup.Name = "clamSoup";
			this.clamSoup.Size = new System.Drawing.Size(120, 24);
			this.clamSoup.TabIndex = 1;
			this.clamSoup.Text = "Clam Chowder";
			// 
			// broccoliSoup
			// 
			this.broccoliSoup.Location = new System.Drawing.Point(8, 16);
			this.broccoliSoup.Name = "broccoliSoup";
			this.broccoliSoup.Size = new System.Drawing.Size(120, 24);
			this.broccoliSoup.TabIndex = 0;
			this.broccoliSoup.Text = "Cream of Broccoli  ";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.steak,
																					this.tofu,
																					this.chicken,
																					this.fish,
																					this.sirloinDone,
																					this.sirloinTip,
																					this.steakDone});
			this.groupBox3.Location = new System.Drawing.Point(168, 32);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(280, 168);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Main Dishes";
			// 
			// steak
			// 
			this.steak.Location = new System.Drawing.Point(16, 24);
			this.steak.Name = "steak";
			this.steak.Size = new System.Drawing.Size(56, 24);
			this.steak.TabIndex = 0;
			this.steak.Text = "Steak";
			// 
			// tofu
			// 
			this.tofu.Location = new System.Drawing.Point(16, 120);
			this.tofu.Name = "tofu";
			this.tofu.TabIndex = 6;
			this.tofu.Text = "Tofu Burger";
			// 
			// chicken
			// 
			this.chicken.Location = new System.Drawing.Point(16, 96);
			this.chicken.Name = "chicken";
			this.chicken.TabIndex = 5;
			this.chicken.Text = "Baked Chicken";
			// 
			// fish
			// 
			this.fish.Location = new System.Drawing.Point(16, 72);
			this.fish.Name = "fish";
			this.fish.Size = new System.Drawing.Size(88, 24);
			this.fish.TabIndex = 4;
			this.fish.Text = "Broiled Fish";
			// 
			// sirloinDone
			// 
			this.sirloinDone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sirloinDone.Items.AddRange(new object[] {
															 "Rare",
															 "Medium Rare",
															 "Medium Well",
															 "Well Done"});
			this.sirloinDone.Location = new System.Drawing.Point(96, 48);
			this.sirloinDone.Name = "sirloinDone";
			this.sirloinDone.Size = new System.Drawing.Size(96, 21);
			this.sirloinDone.TabIndex = 3;
			// 
			// sirloinTip
			// 
			this.sirloinTip.Location = new System.Drawing.Point(16, 48);
			this.sirloinTip.Name = "sirloinTip";
			this.sirloinTip.Size = new System.Drawing.Size(80, 24);
			this.sirloinTip.TabIndex = 2;
			this.sirloinTip.Text = "Sirloin Tips";
			// 
			// steakDone
			// 
			this.steakDone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.steakDone.Items.AddRange(new object[] {
														   "Rare",
														   "Medium Rare",
														   "Medium Well",
														   "Well Done"});
			this.steakDone.Location = new System.Drawing.Point(72, 24);
			this.steakDone.Name = "steakDone";
			this.steakDone.Size = new System.Drawing.Size(96, 21);
			this.steakDone.TabIndex = 1;
			// 
			// Step2
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Description,
																		  this.groupBox3,
																		  this.groupBox2,
																		  this.groupBox1});
			this.Name = "Step2";
			this.NextStep = "Step3";
			this.PreviousStep = "Step1";
			this.StepDescription = "What would you like to order?";
			this.StepTitle = "Place order";
			this.ValidateStep += new System.ComponentModel.CancelEventHandler(this.Step2_ValidateStep);
			this.ResetStep += new System.EventHandler(this.Step2_ResetStep);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Step2_ResetStep(object sender, System.EventArgs e)
		{
			ResetCheckBoxes(this);
		}

		private void ResetCheckBoxes(Control parent)
		{
			CheckBox chk = null;
			ComboBox cbo = null;

			foreach(Control c in parent.Controls)
			{
				chk = c as CheckBox;
				cbo = c as ComboBox;
				if( chk != null )
				{
					chk.Checked = false;
				}
				else if( cbo != null )
				{
					cbo.SelectedIndex = -1;
				}
				else
				{
					ResetCheckBoxes(c);
				}
			}
		}

		public StringCollection GetOrder()
		{
			StringCollection sCol = new StringCollection();

			if( caesarSalad.Checked )
			{
				sCol.Add("Caesar Salad");
			}

			if( tossedSalad.Checked )
			{
				sCol.Add("Tossed Salad");
			}

			if( broccoliSoup.Checked )
			{
				sCol.Add("Broccoli Soup");
			}

			if( clamSoup.Checked )
			{
				sCol.Add("Clam Chowder");
			}

			if( steak.Checked )
			{
				sCol.Add("Steak - " + steakDone.Text);
			}

			if( sirloinTip.Checked )
			{
				sCol.Add("Sirloin Tips - " + sirloinDone.Text);
			}

			if( fish.Checked )
			{
				sCol.Add("Broiled Fish");
			}

			if( chicken.Checked )
			{
				sCol.Add("Baked Chicken");
			}

			if( tofu.Checked )
			{
				sCol.Add("Tofu Burger");
			}

			return sCol;
		}

		private void Step2_ValidateStep(object sender, CancelEventArgs e) 
		{
			if(tofu.Checked==true)
			{
				MessageBox.Show("We are out of tofu burgers please reselect", "Reselect items");
				e.Cancel=true;
			}
		}
	}
}

