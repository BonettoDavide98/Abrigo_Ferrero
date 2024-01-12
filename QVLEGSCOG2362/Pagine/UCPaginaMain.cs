using System;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaMain : UserControl
    {

        private object repaintLock = new object();

        private DBL.LinguaManager linguaManager = null;

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private Class.ComunicazioneManager comunicazioneManager = null;

        #region Pagine

        private enum Page
        {
            NN,
            Home,
            EditRicetta,
            Live,
            Diagnostica,
            OnLine,
            Log,
            Soglie,
            Statistiche1,
            Statistiche2,
            Statistiche3,
            Statistiche4,
            Help,
        }

        private Page prevPage = Page.NN;

        #endregion


        public UCPaginaMain()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, Class.ComunicazioneManager comunicazioneManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            try
            {
                this.appManager = appManager;
                this.comunicazioneManager = comunicazioneManager;
                this.impostazioni = impostazioni;
                this.linguaManager = linguaManager;
                this.repaintLock = repaintLock;

                ucPaginaEditRicetta.Init(this.appManager, this.impostazioni, this.CaricaRicetta, this.GoHome, this.linguaManager, this.repaintLock);
                ucPaginaLive.Init(this.appManager, this.impostazioni, this.repaintLock);
                ucPaginaDiagnostica.Init(this.appManager, this.impostazioni, this.linguaManager, this.repaintLock);
                ucPaginaOnLine1.Init(this.appManager, this.impostazioni, this.repaintLock);
                ucPaginaOnLine1.ActivateDisplay();
                ucPaginaViewLog1.Init(this.appManager, this.impostazioni, this.linguaManager, this.repaintLock);
                ucPaginaViewSoglie1.Init(this.appManager, this.impostazioni, this.linguaManager);
                ucPaginaViewStat11.Init(this.appManager, this.impostazioni, this.linguaManager);
                ucPaginaViewStat21.Init(this.appManager, this.impostazioni, this.linguaManager);
                ucPaginaViewStat31.Init(this.appManager, this.impostazioni, this.linguaManager);
                ucPaginaViewStat41.Init(this.appManager, this.impostazioni, this.linguaManager);

                timerAggiornaStatistiche.Enabled = true;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void ActivateDisplay()
        {
            ucPaginaOnLine1.ActivateDisplay();
        }

        public void SetFocus()
        {
            panelLampeggio.BackColor = Color.Red;
            timerLampeggio.Enabled = true;
            timerLampeggio.Start();
        }

        private void ChangePage(Page page)
        {
            bool okChange = true;
            bool saveRicetta = false;

            //CONTROLLO SU PAGINA ATTUALE
            switch (prevPage)
            {
                case Page.OnLine:
                    break;
                case Page.Log:
                    break;
                case Page.Soglie:
                    ucPaginaViewSoglie1.StopUpdate();
                    break;
                case Page.Statistiche1:
                    break;
                case Page.Statistiche2:
                    break;
                case Page.Statistiche3:
                    break;
                case Page.Statistiche4:
                    break;
                case Page.Home:
                    break;
                //case Page.View:
                //    break;
                case Page.EditRicetta:
                    //bool ok = !ucPaginaEditRicetta.IsDirty();
                    //if (!ok)
                    //{
                    //    if (MessageBox.Show(linguaManager.GetTranslation("MSG_ABBANDONARE_MODIFICHE_RICETTA"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //    {
                    //    }
                    //    else
                    //    {
                    //        okChange = false;
                    //    }
                    //}

                    bool ricettaModificata = ucPaginaEditRicetta.IsDirty();
                    if (ricettaModificata)
                    {
                        if (MessageBox.Show(linguaManager.GetTranslation("MSG_SAVE_MODIFICHE_RICETTA"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ucPaginaEditRicetta.Save();
                        }
                        else
                        {
                        }
                    }

                    break;
                case Page.Live:
                    this.appManager.StopLive();
                    ucPaginaOnLine1.ActivateDisplay();
                    this.appManager.Run();
                    break;
                case Page.Diagnostica:
                    break;
                case Page.NN:
                default:
                    okChange = true;
                    break;
            }

            //CONTROLLO SU PAGINA PROSSIMA
            switch (page)
            {
                case Page.Home:
                    break;
                //case Page.View:
                //    break;
                case Page.EditRicetta: 
                    okChange = true; 
                    break;
                case Page.Live:
                    if (MessageBox.Show(linguaManager.GetTranslation("MSG_GO_PAGE_LIVE"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        okChange = false;
                    }
                    break;
                case Page.Diagnostica:
                    break;
            }

            if (okChange)
            {
                switch (page)
                {
                    case Page.OnLine:
                        ucTabControlPagine.SelectedTab = tabPageOnLine;
                        break;
                    case Page.Log:
                        ucPaginaViewLog1.ShowErrors();
                        ucTabControlPagine.SelectedTab = tabPageLog;
                        break;
                    case Page.Soglie:
                        ucPaginaViewSoglie1.StartUpdate();
                        ucTabControlPagine.SelectedTab = tabPageSoglie;
                        break;
                    case Page.Statistiche1:
                        ucTabControlPagine.SelectedTab = tabPageStatistiche1;
                        break;
                    case Page.Statistiche2:
                        ucTabControlPagine.SelectedTab = tabPageStatistiche2;
                        break;
                    case Page.Statistiche3:
                        ucTabControlPagine.SelectedTab = tabPageStatistiche3;
                        break;
                    case Page.Statistiche4:
                        ucTabControlPagine.SelectedTab = tabPageStatistiche4;
                        break;
                    case Page.Home:
                        ucTabControlPagine.SelectedTab = tabPageHome;
                        break;
                    //case Page.View:
                    //    ucTabControlPagine.SelectedTab = tabPageView;
                    //    break;
                    case Page.EditRicetta:

                        string idFormato = DBL.ImpostazioniManager.ReadFormatoCorrente();
                        ucPaginaEditRicetta.CaricaRicetta(idFormato);

                        ucTabControlPagine.SelectedTab = tabPageEditRicetta;
                        break;
                    case Page.Live:
                        this.appManager.Stop();
                        this.appManager.StartLive();
                        this.ucPaginaLive.ActivateDisplay();

                        ucTabControlPagine.SelectedTab = tabPageLive;
                        break;
                    case Page.Diagnostica:
                        ucTabControlPagine.SelectedTab = tabPageDiagnostica;
                        break;
                }

                prevPage = page;
            }
        }

        public void GoHome()
        {
            ChangePage(Page.Home);
        }

        public void Translate()
        {
            lblStazioneValue.Text = linguaManager.GetTranslation(string.Format("LBL_STAZIONE_{0}", this.appManager.GetIdStazione()));
            lblStazioneValue1.Text = linguaManager.GetTranslation(string.Format("LBL_STAZIONE_{0}", this.appManager.GetIdStazione()));
            lblStazione.Text = linguaManager.GetTranslation("LBL_STAZIONE");
            lblTurnoAttuale.Text = linguaManager.GetTranslation("LBL_TURNO_ATTUALE");
            lblUltimaOra.Text = linguaManager.GetTranslation("LBL_ULTIMA_ORA");

            lblCntTotDesc.Text = linguaManager.GetTranslation("LBL_TOT");
            lblCntOkDesc.Text = linguaManager.GetTranslation("LBL_OK");
            lblCntKoDesc.Text = linguaManager.GetTranslation("LBL_KO");

            btnView.Text = linguaManager.GetTranslation("BTN_VIEW");
            btnEditRicetta.Text = linguaManager.GetTranslation("BTN_EDIT_RICETTA");
            btnLive.Text = linguaManager.GetTranslation("BTN_LIVE");
            btnImpostazioni.Text = linguaManager.GetTranslation("BTN_IMPOSTAZIONI");
            btnDiagnostica.Text = linguaManager.GetTranslation("BTN_DIAGNOSTICA");

            btnLog.Text = linguaManager.GetTranslation("BTN_LOG");
            btnSoglie.Text = linguaManager.GetTranslation("BTN_SOGLIE");
            btnStatistiche1.Text = linguaManager.GetTranslation("BTN_STATISTICHE_1");
            btnStatistiche2.Text = linguaManager.GetTranslation("BTN_STATISTICHE_2");
            btnStatistiche3.Text = linguaManager.GetTranslation("BTN_STATISTICHE_3");
            btnStatistiche4.Text = linguaManager.GetTranslation("BTN_STATISTICHE_4");

            ucPaginaEditRicetta.Translate(linguaManager);
            ucPaginaLive.Translate(linguaManager);
            ucPaginaDiagnostica.Translate(linguaManager);
            ucPaginaOnLine1.Translate(linguaManager);
            ucPaginaViewLog1.Translate(linguaManager);
            ucPaginaViewSoglie1.Translate(linguaManager);
            ucPaginaViewStat11.Translate(linguaManager);
            ucPaginaViewStat21.Translate(linguaManager);
            ucPaginaViewStat31.Translate(linguaManager);
            ucPaginaViewStat41.Translate(linguaManager);
        }

        private void DisplayPerc(Label label, double perc)
        {
            label.Text = string.Format("{0:0.00}%", perc);

            if (perc > impostazioni.SogliaPercScatoRosso)
                label.ForeColor = Color.Red;
            else if (perc > impostazioni.SogliaPercScatoGiallo)
                label.ForeColor = Color.Orange;
            else
                label.ForeColor = Color.Green;
        }

        public void UpdateScreen()
        {
            try
            {
                //TODO : vedere dove mettere
                this.appManager.GetContatori(out long foto, out long buoni, out long scarti);

                lblCntFoto.Text = foto.ToString();
                lblCntBuoni.Text = buoni.ToString();
                lblCntScarti.Text = scarti.ToString();

                //ucPaginaView.GetPercScarto(out double perScartoTurnoPrecedente, out double perScartoTurnoAttuale, out double perScartoUltimaOra);
                GetPercScarto(out double perScartoTurnoPrecedente, out double perScartoTurnoAttuale, out double perScartoUltimaOra);

                DisplayPerc(lblPercTurnoAttuale, perScartoTurnoAttuale);
                DisplayPerc(lblPercUltimaOra, perScartoUltimaOra);

                //bool errorePercentualeScarto = this.appManager.comunicazioneManager.ErrorePercentualeScarto;
                //ucNotificationPanel1.UpdateRitentivi(0, errorePercentualeScarto, this.linguaManager.GetTranslation("MSG_ALARM_PERC_SCARTI"));
            }
            catch (Exception) { }
        }

        private bool OnFineControlloNastro(bool ok)
        {
            bool ret = false;
            try
            {
                if (this.InvokeRequired)
                {
                    ret = (bool)this.Invoke(new Func<bool>(() => { return OnFineControlloNastro(ok); }));
                }
                else
                {
                    FormEsitoControlloNastro f = new FormEsitoControlloNastro(ok, this.linguaManager);
                    f.ShowDialog();
                    ret = f.retry;
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            return ret;
        }

        private void CaricaRicetta(bool fromEdit, bool doControlloNastro)
        {
            try
            {
                string idFormato = DBL.ImpostazioniManager.ReadFormatoCorrente();
                CaricaRicetta(idFormato, fromEdit, doControlloNastro);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                //this.appManager.Run();
            }
        }

        public void CaricaRicetta(string idFormato, bool fromEdit, bool doControlloNastro)
        {
            try
            {
                this.appManager.CaricaRicetta(idFormato);

                //ucPaginaView.CaricaRicetta(idFormato); 
                ucPaginaViewSoglie1.CaricaRicetta(idFormato);

                if (doControlloNastro)
                {
                    MessageBox.Show(linguaManager.GetTranslation("MSG_GO_CONTROLLO_NASTRO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Question);

                    ChangePage(Page.OnLine); 
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                //this.appManager.Run();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Home);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ChangePage(Page.OnLine);
        }

        private void btnEditRicetta_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    Utilities.WaitManager.OpenWaitForm("LBL_WAIT_CARICAMENTO");
                    ChangePage(Page.EditRicetta);
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
            finally
            {
                Utilities.WaitManager.CloseWaitForm();
            }
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    ChangePage(Page.Live);
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

        private void btnDiagnostica_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Diagnostica);
        }

        private void btnImpostazioni_Click(object sender, EventArgs e)
        {
            try
            {
                FormPassword frmPsw = new FormPassword(this.impostazioni);
                if (frmPsw.ShowDialog() == DialogResult.OK)
                {
                    using (FormImpostazioni frm = new FormImpostazioni())
                    {
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void pnlLogoQV_Click(object sender, System.EventArgs e)
        {
            try
            {
                FormInfo f = new FormInfo(this.linguaManager);
                f.ShowDialog();
            }
            catch { }
        }

        private void timerAggiornaStatistiche_Tick(object sender, System.EventArgs e)
        {
            timerAggiornaStatistiche.Enabled = false;
            try
            {
                ucPaginaViewStat11.RefreshGrafico();
                ucPaginaViewStat21.RefreshGrafico();
                ucPaginaViewStat31.RefreshGrafico();

#if !_Simulazione
                int[] numTout = this.appManager.GetNumeroTimeout();
                ucPaginaOnLine1.AggiornaTimeout(numTout);
#endif
            }
            catch (Exception ex) { }
            finally
            {
                timerAggiornaStatistiche.Enabled = true;
            }
        }

        public void GetPercScarto(out double perScartoTurnoPrecedente, out double perScartoTurnoAttuale, out double perScartoUltimaOra)
        {
            ucPaginaViewStat31.GetPercScarto(out perScartoTurnoPrecedente, out perScartoTurnoAttuale, out perScartoUltimaOra);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Log);
        }

        private void btnSoglie_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Soglie);
        }

        private void btnStatistiche1_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Statistiche1);
        }

        private void btnStatistiche2_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Statistiche2);
        }

        private void btnStatistiche3_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Statistiche3);
        }

        private void btnStatistiche4_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Statistiche4);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //ChangePage(Page.Help);
        }

        private void timerLampeggio_Tick(object sender, EventArgs e)
        {
            try
            {
                panelLampeggio.BackColor = Color.White;
                timerLampeggio.Stop();
                timerLampeggio.Enabled = false;
            }
            catch { }
            finally
            {
            }
        }

    }
}
