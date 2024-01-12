using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FrmLogin : Form
    {

        public bool Ok = false;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        public FrmLogin(DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.linguaManager = linguaManager;
            this.impostazioni = impostazioni;

            btnAccedi.Text = this.linguaManager.GetTranslation("BTN_NEW_LOGIN");
            btnClose.Text = this.linguaManager.GetTranslation("BTN_ANNULLA");
            lblTestoUsername.Text = this.linguaManager.GetTranslation("LBL_USERNAME");
            lblTestoPassword.Text = this.linguaManager.GetTranslation("LBL_PASSWORD");
        }

        private void btnAccedi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Trim().Length > 0 && txtPassword.Text.Trim().Length > 0)
                {
                    DataType.Utente user = null;

                    if (DBL.UtenteProvider.TryLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim(), ref user))
                    {
                        if (user != null)
                        {
                            if (user.LivelloUtente != DataType.Livello.LivelloUtente.Amministratore)
                            {
                                //if (USBManager.LoginUsb(user))
                                //{
                                Class.LoginLogoutManager.Login(user, this.impostazioni.LoginTimeout);
                                Ok = true;
                                this.Close();
                                //}
                                //else
                                //    MessageBox.Show("Errore nel login con USB!", "Problema autenticazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                Class.LoginLogoutManager.Login(user, this.impostazioni.LoginTimeout);
                                Ok = true;
                                this.Close();
                            }
                        }
                        else
                            MessageBox.Show(this.linguaManager.GetTranslation("MSG_USER_KO"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show(this.linguaManager.GetTranslation("MSG_LOGIN_KO"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_USER_EMPTY"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            FormStringInput f = new FormStringInput(txtUsername.Text, 0, false);
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtUsername.Text = f.Testo;
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            FormStringInput f = new FormStringInput(txtPassword.Text, 0, true);
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtPassword.Text = f.Testo;
            }
        }
    }
}
