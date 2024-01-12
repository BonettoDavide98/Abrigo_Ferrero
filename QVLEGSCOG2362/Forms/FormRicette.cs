using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormRicette : Form
    {

        private int numCamere = -1;
        private Action<bool, bool> actionCaricaRicetta = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        public FormRicette(int numCamere, Action<bool, bool> actionCaricaRicetta, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.numCamere = numCamere;
            this.actionCaricaRicetta = actionCaricaRicetta;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;

            RefreshForm();

            Translate(linguaManager);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_FORMATI");
            dgvColIdFormato.HeaderText = linguaManager.GetTranslation("LBL_ID");
            dgvColDescrizioneFormato.HeaderText = linguaManager.GetTranslation("LBL_DESCRIZIONE");

            btnNuovoFormato.Text = linguaManager.GetTranslation("BTN_NUOVO");
            btnCopiaFormato.Text = linguaManager.GetTranslation("BTN_COPIA");
            btnEliminaFormatoGenerale.Text = linguaManager.GetTranslation("BTN_ELIMINA");
            btnCaricaFormatoAllCamera.Text = linguaManager.GetTranslation("BTN_CARICA");
        }

        private void RefreshForm()
        {
            formatoIntestazioneBindingSource.DataSource = DBL.FormatoManager.ReadAllFormatiHeader();
        }

        private void btnNuovoFormato_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    if (new FormAddFormato(this.numCamere, this.impostazioni, this.linguaManager).ShowDialog() == DialogResult.OK)
                    {
                        RefreshForm();
                    }
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

        private void btnCopiaFormato_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    DataType.Formato format = (DataType.Formato)formatoIntestazioneBindingSource.Current;
                    if (format != null)
                    {
                        if (new FormCopiaFormato(this.numCamere, this.impostazioni, format.IdFormato, this.linguaManager).ShowDialog() == DialogResult.OK)
                        {
                            RefreshForm();
                        }
                    }
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

        private void btnEliminaFormatoGenerale_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    DataType.Formato formatoDaEliminare = (DataType.Formato)formatoIntestazioneBindingSource.Current;

                    string formatoCorrente = DBL.ImpostazioniManager.ReadFormatoCorrente();

                    if (formatoDaEliminare.IdFormato == formatoCorrente)
                    {
                        MessageBox.Show(this.linguaManager.GetTranslation("MSG_IMPOSSIBILE_ELIMINARE"), this.linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show(this.linguaManager.GetTranslation("MSG_DOMANDA_ELIMINARE"), this.linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string path = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "RICETTE", formatoDaEliminare.IdFormato);

                            if (System.IO.Directory.Exists(path))
                            {
                                System.IO.Directory.Delete(path, true);
                            }

                            DBL.FormatoManager.DeleteFormato(formatoDaEliminare.IdFormato);
                            RefreshForm();
                        }
                    }
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

        private void btnCaricaFormatoAllCamera_Click(object sender, EventArgs e)
        {
            try
            {
                DataType.Formato format = (DataType.Formato)formatoIntestazioneBindingSource.Current;

                DBL.ImpostazioniManager.WriteFormatoCorrente(format.IdFormato);

                this.actionCaricaRicetta?.Invoke(false, this.impostazioni.ControlloNastro);

                this.Close();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
