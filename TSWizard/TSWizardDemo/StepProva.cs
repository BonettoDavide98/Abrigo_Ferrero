using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSWizardDemo
{
    public partial class StepProva : TSWizards.BaseInteriorStep
    {
        public StepProva()
        {
            InitializeComponent();
        }

        private void StepProvaShowStep(object sender, TSWizards.ShowStepEventArgs e)
        {
            NextStep = "Step5";
            //Wizard.MoveNext();
        }
    }
}
