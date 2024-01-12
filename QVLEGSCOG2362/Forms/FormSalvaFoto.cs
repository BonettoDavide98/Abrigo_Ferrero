using System;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormSalvaFoto : Form
    {

        private Class.Core core = null;
        private DBL.LinguaManager linguaManager = null;
        private bool abilitaSalvataggio = false;

        public FormSalvaFoto(Class.Core core, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.core = core;
            this.linguaManager = linguaManager;

            //this.abilitaSalvataggio = this.core[0].AbilitaSalvataggio;

            btnSave.Text = linguaManager.GetTranslation("BTN_SALVA");
            btnEsci.Text = linguaManager.GetTranslation("BTN_ESCI");

            AggiornaBottone();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //this.core.AbilitaSalvataggio = this.abilitaSalvataggio;
            this.DialogResult = DialogResult.OK;
        }

        private void btnAbilitaSaveFoto_Click(object sender, EventArgs e)
        {
            this.abilitaSalvataggio = !this.abilitaSalvataggio;

            AggiornaBottone();
        }

        private void AggiornaBottone()
        {
            if (this.abilitaSalvataggio)
            {
                btnAbilitaSaveFoto.Text = linguaManager.GetTranslation("LBL_ABILITATO");
                btnAbilitaSaveFoto.ForeColor = Color.Green;
            }
            else
            {
                btnAbilitaSaveFoto.Text = linguaManager.GetTranslation("LBL_DISABILITATO");
                btnAbilitaSaveFoto.ForeColor = Color.Red;
            }
        }

    }
}