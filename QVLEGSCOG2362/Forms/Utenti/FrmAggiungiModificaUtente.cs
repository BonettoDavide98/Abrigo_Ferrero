using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FrmAggiungiModificaUtente : Form
    {

        private bool isNewUser;
        private DataType.Utente userToEdit;

        public bool Ok = false;
        private DBL.LinguaManager linguaManager;

        public FrmAggiungiModificaUtente(bool isNewUser, DataType.Utente userToEdit, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.linguaManager = linguaManager;
            this.isNewUser = isNewUser;
            this.userToEdit = userToEdit;

            this.Text = this.linguaManager.GetTranslation("LBL_TITOLO_NEW_UTENTE");
            lblTestoUsername.Text = this.linguaManager.GetTranslation("LBL_USERNAME");
            lblTestoPassword.Text = this.linguaManager.GetTranslation("LBL_PASSWORD");
            lblTestoOperatore.Text = this.linguaManager.GetTranslation("LBL_OPERATORE");
            lblTestoLivello.Text = this.linguaManager.GetTranslation("LBL_LIVELLO");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                cmbLivello.DataSource = DBL.UtenteProvider.GetAllLivelli();
                cmbLivello.ValueMember = "ID";
                cmbLivello.DisplayMember = "Descrizione";

                if (isNewUser)
                    cmbLivello.SelectedIndex = 0;
                else
                {
                    cmbLivello.SelectedValue = (int)userToEdit.LivelloUtente;

                    txtUsername.Text = userToEdit.Username;
                    txtPassword.Text = userToEdit.Password;
                    txtOperatore.Text = userToEdit.Operatore;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAggiungiModificaUtente_Load(object sender, EventArgs e)
        {

        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControllaCampi())
                {
                    Ok = true;
                    this.Close();
                }
                else
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_RIEMPIRE_CAMPI"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool ControllaCampi()
        {
            if (txtUsername.Text.Trim().Length > 0 && txtPassword.Text.Trim().Length > 0 && txtOperatore.Text.Trim().Length > 0 && int.Parse(cmbLivello.SelectedValue.ToString()) >= 0)
                return true;
            return false;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
