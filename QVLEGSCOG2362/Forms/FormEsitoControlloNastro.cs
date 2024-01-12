using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormEsitoControlloNastro : Form
    {

        private bool controlloNastroOk = false;
        private DBL.LinguaManager linguaManager = null;

        public bool retry = false;

        public FormEsitoControlloNastro(bool controlloNastroOk, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.controlloNastroOk = controlloNastroOk;
            this.linguaManager = linguaManager;

            if (controlloNastroOk)
            {
                lblText.ForeColor = System.Drawing.Color.Green;
                lblText.Text = linguaManager.GetTranslation("MSG_CONTROLLO_NASTRO_OK");
                btnBypass.Visible = false;

            }
            else
            {
                lblText.ForeColor = System.Drawing.Color.Red;
                lblText.Text = linguaManager.GetTranslation("MSG_CONTROLLO_NASTRO_KO");
            }

            btnOK.Text = linguaManager.GetTranslation("BTN_OK");
            btnBypass.Text = linguaManager.GetTranslation("BTN_BYPASS");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.controlloNastroOk == false)
                this.retry = true;
            this.Close();
        }

        private void btnBypass_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_LOGIN"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}