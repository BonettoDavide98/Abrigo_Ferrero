using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FrmGestioneUtenti : Form
    {

        private List<DataType.Utente> listaUtenti = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        public FrmGestioneUtenti(DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();
            this.linguaManager = linguaManager;
            this.impostazioni = impostazioni;

            this.Text = this.linguaManager.GetTranslation("BTN_GESTIONE_UTENTI");
            btnAggiungi.Text = this.linguaManager.GetTranslation("BTN_ADD");
            btnElimina.Text = this.linguaManager.GetTranslation("BTN_DELETE");
            btnModifica.Text = this.linguaManager.GetTranslation("BTN_EDIT");

            this.utenteDataGridView.Columns[3].HeaderText = this.linguaManager.GetTranslation("LBL_OPERATORE");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                listaUtenti = new List<DataType.Utente>();

                RefreshDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefreshDgv()
        {
            if (listaUtenti.Count > 0)
                listaUtenti.Clear();

            if (DBL.UtenteProvider.GetAllUsers(ref listaUtenti))
            {
                utenteBindingSource.DataSource = listaUtenti;
                utenteBindingSource.ResetBindings(true);
                utenteDataGridView.Refresh();
            }
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAggiungiModificaUtente frm = new FrmAggiungiModificaUtente(true, null, this.linguaManager);
                frm.ShowDialog();

                if (frm.Ok)
                    if (listaUtenti.Where(t => t.Username.ToLower().CompareTo(frm.txtUsername.Text.Trim().ToLower()) == 0).FirstOrDefault() == null)
                        if (DBL.UtenteProvider.InsertUser(frm.txtUsername.Text.Trim(), frm.txtPassword.Text.Trim(), frm.txtOperatore.Text.Trim(), int.Parse(frm.cmbLivello.SelectedValue.ToString())))
                            RefreshDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (utenteDataGridView.SelectedRows.Count == 1)
                {
                    bool doLogoutAfterEdit = false;

                    var user = listaUtenti.Where(t => t.Username == utenteDataGridView.SelectedRows[0].Cells["username"].Value.ToString()).FirstOrDefault();
                    doLogoutAfterEdit = user.Equals(Class.LoginLogoutManager.GetUserLogged());

                    FrmAggiungiModificaUtente frm = new FrmAggiungiModificaUtente(false, user, this.linguaManager);
                    frm.ShowDialog();

                    if (frm.Ok)
                        if (DBL.UtenteProvider.UpdateUser(user.ID, frm.txtUsername.Text.Trim(), frm.txtPassword.Text.Trim(), frm.txtOperatore.Text.Trim(), int.Parse(frm.cmbLivello.SelectedValue.ToString())))
                        {
                            RefreshDgv();
                            if (doLogoutAfterEdit)
                                Class.LoginLogoutManager.Logout(this.linguaManager.GetTranslation("MSG_EDIT_UTENTE"));
                        }
                }
                else
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_SELECT_ROW"), this.linguaManager.GetTranslation("MSG_ERRORE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (utenteDataGridView.SelectedRows.Count == 1)
                {
                    var user = listaUtenti.Where(t => t.Username == utenteDataGridView.SelectedRows[0].Cells["username"].Value.ToString()).FirstOrDefault();

                    if (MessageBox.Show(this.linguaManager.GetTranslation("MSG_DELETE_USER_QUESTION"), this.linguaManager.GetTranslation("MSG_DELETE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!user.Equals(Class.LoginLogoutManager.GetUserLogged()))
                        {
                            DBL.UtenteProvider.DeleteUser(user.ID);
                            RefreshDgv();
                        }
                        else
                            MessageBox.Show(this.linguaManager.GetTranslation("MSG_DELETE_USER"));
                    }

                }
                else
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_SELECT_ROW"), this.linguaManager.GetTranslation("MSG_ERRORE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

    }
}
