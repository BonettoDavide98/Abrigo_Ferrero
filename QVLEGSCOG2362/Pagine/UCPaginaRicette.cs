using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaRicette : UserControl
    {

        private int numCamere = -1;
        private Action<bool, bool> actionCaricaRicetta = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        public UCPaginaRicette()
        {
            InitializeComponent();
        }

        public void Init(int numCamere, Action<bool, bool> actionCaricaRicetta, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            this.numCamere = numCamere;
            this.actionCaricaRicetta = actionCaricaRicetta;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;
            RefreshForm();
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_FORMATI");
            dgvColIdFormato.HeaderText = linguaManager.GetTranslation("LBL_ID");
            dgvColDescrizioneFormato.HeaderText = linguaManager.GetTranslation("LBL_DESCRIZIONE");

            btnNuovoFormato.Text = linguaManager.GetTranslation("BTN_NUOVO");
            btnCopiaFormato.Text = linguaManager.GetTranslation("BTN_COPIA");
            btnEliminaFormatoGenerale.Text = linguaManager.GetTranslation("BTN_ELIMINA");
            btnEsporta.Text = linguaManager.GetTranslation("BTN_EXPORT");
            btnImporta.Text = linguaManager.GetTranslation("BTN_IMPORT");
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

        private void btnEsporta_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    using (FolderBrowserDialog sfd = new FolderBrowserDialog())
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                string path = sfd.SelectedPath;

                                DataType.Formato format = (DataType.Formato)formatoIntestazioneBindingSource.Current;

                                string pathRicettaExport = System.IO.Path.Combine(path, $"{format.IdFormato}_{format.DescrizioneFormato}");

                                if (System.IO.Directory.Exists(pathRicettaExport))
                                {
                                    System.IO.Directory.Delete(pathRicettaExport, true);
                                }

                                System.IO.Directory.CreateDirectory(pathRicettaExport);

                                for (int i = 0; i < this.numCamere; i++)
                                {
                                    string fileName = System.IO.Path.Combine(pathRicettaExport, $"{i + 1}.xml");
                                    DataType.ParametriAlgoritmo par = DBL.FormatoManager.ReadParametriAlgoritmo(format.IdFormato, i);
                                    DataType.Extension.ToXmlFile(par, fileName);
                                }

                                string pathSrc = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "RICETTE", format.IdFormato);
                                string pathDest = System.IO.Path.Combine(pathRicettaExport, "DATI");

                                Utilities.CommonUtility.DirectoryCopy(pathSrc, pathDest, true);

                                MessageBox.Show(this.linguaManager.GetTranslation("MSG_EXPORT_OK"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                Class.ExceptionManager.AddException(ex);
                                MessageBox.Show(this.linguaManager.GetTranslation("MSG_ERROR_EXPORT"), this.linguaManager.GetTranslation("MSG_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

        private void btnImporta_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    using (FolderBrowserDialog sfd = new FolderBrowserDialog())
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                DataType.Formato format = (DataType.Formato)formatoIntestazioneBindingSource.Current;

                                string pathRicettaImport = sfd.SelectedPath;

                                for (int i = 0; i < this.numCamere; i++)
                                {
                                    string fileName = System.IO.Path.Combine(pathRicettaImport, $"{i + 1}.xml");
                                    DataType.ParametriAlgoritmo par = DataType.Extension.FromXmlFile<DataType.ParametriAlgoritmo>(fileName);
                                    DBL.FormatoManager.WriteParametriAlgoritmo(format.IdFormato, i, par);
                                }

                                string pathSrc = System.IO.Path.Combine(pathRicettaImport, "DATI");
                                string pathDest = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "RICETTE", format.IdFormato);

                                if (System.IO.Directory.Exists(pathDest))
                                {
                                    System.IO.Directory.Delete(pathDest, true);
                                }

                                Utilities.CommonUtility.DirectoryCopy(pathSrc, pathDest, true);

                                MessageBox.Show(this.linguaManager.GetTranslation("MSG_IMPORT_OK"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                Class.ExceptionManager.AddException(ex);
                                MessageBox.Show(this.linguaManager.GetTranslation("MSG_ERROR_IMPORT"), this.linguaManager.GetTranslation("MSG_ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                Utilities.WaitManager.OpenWaitForm("LBL_WAIT_CARICAMENTO");

                DataType.Formato format = (DataType.Formato)formatoIntestazioneBindingSource.Current;
                DBL.ImpostazioniManager.WriteFormatoCorrente(format.IdFormato);
                this.actionCaricaRicetta?.Invoke(false, this.impostazioni.ControlloNastro);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                Utilities.WaitManager.CloseWaitForm();
            }
        }

    }
}