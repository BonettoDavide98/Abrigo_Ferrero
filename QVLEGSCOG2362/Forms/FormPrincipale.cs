using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormPrincipale : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse
         );

        private object repaintLock = new object();

        private DBL.LinguaManager linguaManager = null;

        private List<Class.AppManager> appManager = new List<Class.AppManager>();

        private DataType.Impostazioni impostazioni = null;

        private Bitmap flag1, flag2, flag3;

        private List<Pagine.UCPaginaMain> pagineMain = new List<Pagine.UCPaginaMain>();

        private System.Timers.Timer timerTurni = null;

        private Class.ComunicazioneManager comunicazioneManager = null;

        private bool lampeggioLogAttivo = false;
        private bool lampeggioRosso = false;

        #region Pagine

        private enum Page
        {
            NN,
            Ricette,
            Stazione1,
            Stazione2,
            Stazione3,
            Log,
            Home,
        }

        private Page prevPage = Page.NN;

        #endregion

        public FormPrincipale()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 25, 25));

            //btnHome.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(btnHome.Location.X, btnHome.Location.Y, btnHome.Location.X + btnHome.Width, btnHome.Location.Y + btnHome.Height, 10, 10));
            //btnHome.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnHome.Location.X + btnHome.Width, btnHome.Location.Y + btnHome.Height, 10, 10));

            try
            {
                this.impostazioni = DBL.ImpostazioniManager.ReadImpostazioni();

                Class.LoginLogoutManager.Init(this.impostazioni.TipologiaLogin == DataType.Impostazioni.TipoLogin.NN);

                this.linguaManager = new DBL.LinguaManager(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "lng"));
                this.linguaManager.ChangeLanguage(impostazioni.Lingua1);

                Utilities.WaitManager.SetLinguaManager(this.linguaManager);

                //**********************************************************************************

                Class.Manager.SchedaIO schedaIO = new Class.Manager.SchedaIO();
                schedaIO.Init(this.impostazioni);

                this.comunicazioneManager = new Class.ComunicazioneManager(schedaIO, this.impostazioni);

                int numStazioni = GetNumStazioni(this.impostazioni);
                //int numStazioni = 1;
                int numCamere = GetNumCamereTot(this.impostazioni);
                //int numCamere = 1;

                Dictionary<string, ICogFrameGrabber> camereSN = null;

#if !_Simulazione
                camereSN = GetSerialNumberCamere();
#endif

                if (numStazioni > 0)
                {
                    Class.AppManager appManager0 = new Class.AppManager(0, this.comunicazioneManager, schedaIO, camereSN, this.linguaManager);
                    this.appManager.Add(appManager0);
                    ucPaginaMain1.Init(appManager0, this.comunicazioneManager, this.impostazioni, this.linguaManager, this.repaintLock);
                    pagineMain.Add(ucPaginaMain1);
                }

                if (numStazioni > 1)
                {
                    Class.AppManager appManager1 = new Class.AppManager(1, this.comunicazioneManager, schedaIO, camereSN, this.linguaManager);
                    this.appManager.Add(appManager1);
                    ucPaginaMain2.Init(appManager1, this.comunicazioneManager, this.impostazioni, this.linguaManager, this.repaintLock);
                    pagineMain.Add(ucPaginaMain2);
                }

                if (numStazioni > 2)
                {
                    Class.AppManager appManager2 = new Class.AppManager(2, this.comunicazioneManager, schedaIO, camereSN, this.linguaManager);
                    this.appManager.Add(appManager2);
                    ucPaginaMain3.Init(appManager2, this.comunicazioneManager, this.impostazioni, this.linguaManager, this.repaintLock);
                    pagineMain.Add(ucPaginaMain3);
                }

                ucPaginaLog1.Init(this.appManager);
                ucPaginaLog1.OnBackHome += UcPaginaLog1_OnBackHome;
                ucPaginaLog1.OnNewLog += UcPaginaLog1_OnNewLog;

                //TODO : mettere a posto
                ucPaginaRicette.Init(numCamere, this.CaricaRicetta, this.impostazioni, this.linguaManager);

                ChangePage(Page.Stazione1);

                TraduciControlli();

                InitTurniManager();

                Class.LoginLogoutManager.OnLogin += LoginLogoutManager_OnLogin;
                Class.LoginLogoutManager.OnLogout += LoginLogoutManager_OnLogout;

                CambiaUtente();

                if (this.impostazioni.TipologiaLogin == DataType.Impostazioni.TipoLogin.NN || this.impostazioni.TipologiaLogin == DataType.Impostazioni.TipoLogin.Modbus)
                {
                    btnLogin.Visible = false;
                }

                CaricaRicetta(false, false);

                btnLingua1.BackColor = Color.Transparent;

                string fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", string.Format("{0}.png", impostazioni.Lingua1));
                if (System.IO.File.Exists(fileName))
                {
                    flag1 = new Bitmap(fileName);
                    btnLingua1.BackgroundImage = flag1;
                }

                fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", string.Format("{0}.png", impostazioni.Lingua2));
                if (System.IO.File.Exists(fileName))
                {
                    //btnLingua2.BackgroundImage = new Bitmap(fileName);
                    flag2 = new Bitmap(fileName);
                }

                fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", string.Format("{0}.png", impostazioni.Lingua3));
                if (System.IO.File.Exists(fileName))
                {
                    //btnLingua2.BackgroundImage = new Bitmap(fileName);
                    flag3 = new Bitmap(fileName);
                }

                this.BringToFront();

                for (int i = 0; i < this.appManager.Count; i++)
                {
                    this.appManager[i].Run();
                }

            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            timerUpdateScreen.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            timerUpdateScreen.Stop();

            timerUpdateScreen.Enabled = false;

            for (int i = 0; i < this.appManager.Count; i++)
            {
                this.appManager[i].Stop();
                this.appManager[i].Close();
            }
        }

        Page pageBeforeLog = Page.Stazione1;

        private void ChangePage(Page nextPage)
        {
            bool okChange = true;
            bool isHome = false;

            //CONTROLLO SU PAGINA ATTUALE
            switch (prevPage)
            {
                case Page.Ricette:
                    if (nextPage == Page.Home)
                        nextPage = pageBeforeLog; //Imposto la schermata visualizzata al click del pulsante
                    break;
                case Page.Stazione1:
                    break;
                case Page.Stazione2:
                    break;
                case Page.Stazione3:
                    break;
                case Page.Log:
                    if (nextPage == Page.Home)
                        nextPage = pageBeforeLog; //Imposto la schermata visualizzata al click del pulsante
                    break;

                case Page.NN:
                default:
                    okChange = true;
                    break;
            }

            //CONTROLLO SU PAGINA PROSSIMA
            switch (nextPage)
            {
                case Page.Ricette:
                    //pageBeforeLog = prevPage;
                    break;
                case Page.Stazione1:
                    break;
                case Page.Stazione2:
                    break;
                case Page.Stazione3:
                    break;

                case Page.Home:
                    nextPage = prevPage;
                    isHome = true;
                    break;

                case Page.Log:
                    //pageBeforeLog = prevPage;
                    break;
            }

            if (okChange)
            {
                switch (nextPage)
                {
                    case Page.Ricette:
                        ucTabControlPagine.SelectedTab = tabPageRicette;
                        break;
                    case Page.Stazione1:
                        if (isHome)
                            this.pagineMain[0].GoHome();
                        ucTabControlPagine.SelectedTab = tabPageStazione1;
                        ResetBackColorBtnCam();
                        btnStazione1.BackColor = Color.DarkGray;
                        this.pagineMain[0].SetFocus();
                        break;
                    case Page.Stazione2:
                        if (isHome)
                            this.pagineMain[1].GoHome();
                        ucTabControlPagine.SelectedTab = tabPageStazione2;
                        ResetBackColorBtnCam();
                        btnStazione2.BackColor = Color.DarkGray;
                        this.pagineMain[1].SetFocus();
                        break;
                    case Page.Stazione3:
                        if (isHome)
                            this.pagineMain[2].GoHome();
                        ucTabControlPagine.SelectedTab = tabPageStazione3;
                        ResetBackColorBtnCam();
                        btnStazione3.BackColor = Color.DarkGray;
                        this.pagineMain[2].SetFocus();
                        break;
                    case Page.Log:
                        ucTabControlPagine.SelectedTab = tabPageLog;
                        break;

                    default:
                        if (isHome)
                            this.pagineMain[0].GoHome();
                        ucTabControlPagine.SelectedTab = tabPageStazione1;
                        ResetBackColorBtnCam();
                        btnStazione1.BackColor = Color.DarkGray;
                        this.pagineMain[0].SetFocus();
                        break;
                }

                prevPage = nextPage;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < this.pagineMain.Count; i++)
            //{
            //    this.pagineMain[i].GoHome();
            //}

            ChangePage(Page.Home);
        }

        private void TraduciControlli()
        {
            lblTurnoText.Text = linguaManager.GetTranslation("LBL_TURNO");
            lblUserText.Text = linguaManager.GetTranslation("LBL_USER");
            lblRicetta.Text = linguaManager.GetTranslation("LBL_RICETTA");

            //btnStazione1.Text = linguaManager.GetTranslation("LBL_STAZIONE_0");
            //btnStazione2.Text = linguaManager.GetTranslation("LBL_STAZIONE_1");
            //btnStazione3.Text = linguaManager.GetTranslation("LBL_STAZIONE_2");

            btnStazione1.Text = "1";
            btnStazione2.Text = "2";
            btnStazione3.Text = "3";

            btnAllCamere.Text = linguaManager.GetTranslation("LBL_ALL_CAMERE");

            lblDataOra.Text = linguaManager.GetTranslation("LBL_DATA_ORA");

            ucPaginaRicette.Translate(linguaManager);

            for (int i = 0; i < this.pagineMain.Count; i++)
            {
                this.pagineMain[i].Translate();
            }

            ucPaginaLog1.Translate(linguaManager);
        }

        private void ResetBackColorBtnCam()
        {
            btnStazione1.BackColor = Color.Gainsboro;
            btnStazione2.BackColor = Color.Gainsboro;
            btnStazione3.BackColor = Color.Gainsboro;
            btnAllCamere.BackColor = Color.Gainsboro;
        }

        private int GetNumStazioni(DataType.Impostazioni impostazioni)
        {
            Dictionary<int, int> tmp = new Dictionary<int, int>();

            if (impostazioni.ImpostazioniCamera1.Attiva) tmp.Add(0, impostazioni.ImpostazioniCamera1.IdStazione);
            if (impostazioni.ImpostazioniCamera2.Attiva) tmp.Add(1, impostazioni.ImpostazioniCamera2.IdStazione);
            if (impostazioni.ImpostazioniCamera3.Attiva) tmp.Add(2, impostazioni.ImpostazioniCamera3.IdStazione);
            //if (impostazioni.ImpostazioniCamera4.Attiva) tmp.Add(3, impostazioni.ImpostazioniCamera4.IdStazione);
            //if (impostazioni.ImpostazioniCamera5.Attiva) tmp.Add(4, impostazioni.ImpostazioniCamera5.IdStazione);
            //if (impostazioni.ImpostazioniCamera6.Attiva) tmp.Add(5, impostazioni.ImpostazioniCamera6.IdStazione);

            return tmp.Select(k => k.Value).Distinct().Count();
        }

        private int GetNumCamereTot(DataType.Impostazioni impostazioni)
        {
            Dictionary<int, int> tmp = new Dictionary<int, int>();

            if (impostazioni.ImpostazioniCamera1.Attiva) tmp.Add(0, impostazioni.ImpostazioniCamera1.IdStazione);
            if (impostazioni.ImpostazioniCamera2.Attiva) tmp.Add(1, impostazioni.ImpostazioniCamera2.IdStazione);
            if (impostazioni.ImpostazioniCamera3.Attiva) tmp.Add(2, impostazioni.ImpostazioniCamera3.IdStazione);
            //if (impostazioni.ImpostazioniCamera4.Attiva) tmp.Add(3, impostazioni.ImpostazioniCamera4.IdStazione);
            //if (impostazioni.ImpostazioniCamera5.Attiva) tmp.Add(4, impostazioni.ImpostazioniCamera5.IdStazione);
            //if (impostazioni.ImpostazioniCamera6.Attiva) tmp.Add(5, impostazioni.ImpostazioniCamera6.IdStazione);

            return tmp.Count();
        }

        private void CaricaRicetta(bool fromEdit, bool doControlloNastro)
        {
            try
            {
                string idFormato = DBL.ImpostazioniManager.ReadFormatoCorrente();
                DataType.Formato formato = DBL.FormatoManager.ReadFormatiHeader(idFormato);
                if (formato != null)
                    lblFormatoCorrente.Text = string.Format("{0} - {1}", formato.IdFormato, formato.DescrizioneFormato);
                else
                    lblFormatoCorrente.Text = "------------------------------------------------------";

                for (int i = 0; i < this.pagineMain.Count; i++)
                {
                    this.pagineMain[i].CaricaRicetta(idFormato, fromEdit, doControlloNastro);
                }

                ChangePage(Page.Home);
                //for (int i = 0; i < this.pagineMain.Count; i++)
                //{
                //    this.pagineMain[i].GoHome();
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        private void btnMinimizza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(linguaManager.GetTranslation("MSG_SHUTDOWN"),
                linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataType.Impostazioni impostazioni = DBL.ImpostazioniManager.ReadImpostazioni();

                FrmLogin frm = new FrmLogin(impostazioni, this.linguaManager);
                frm.ShowDialog();

                DataType.Utente user = new DataType.Utente();
                user = Class.LoginLogoutManager.GetUserLogged();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnRicette_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Ricette);

            //try
            //{
            //    if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Operatore)
            //    {
            //        int numCamere = GetNumCamereTot(this.impostazioni);
            //        FormRicette f = new FormRicette(numCamere, this.CaricaRicetta, this.impostazioni, this.linguaManager);
            //        f.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show(this.linguaManager.GetTranslation("MSG_LOGIN"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Class.ExceptionManager.AddException(ex);
            //}
        }

        private void timerUpdateScreen_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.pagineMain.Count; i++)
                {
                    this.pagineMain[i].UpdateScreen();
                }

                DataType.Definizione_Turni defTurno = DBL.GestioneTurniManager.Select_TurnoAttuale(DateTime.Now);
                if (defTurno != null)
                    lblTurno.Text = defTurno.NomeTurno.ToString();
                else
                    lblTurno.Text = "--------";

                if (this.lampeggioLogAttivo)
                {
                    lampeggioRosso = !lampeggioRosso;
                    btnLog.BackgroundImage = lampeggioRosso ? Properties.Resources.alarm_OFF : Properties.Resources.alarm_ON;
                }
                else
                    btnLog.BackgroundImage = Properties.Resources.alarm_OFF;

                lblDataOraAtt.Text = DateTime.Now.ToString("dd/MM/yyyy\n\rHH:mm:ss");
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void ucNotificationPanel1_OnReset(object sender, EventArgs e)
        {
            try
            {
                this.comunicazioneManager.ResetAllarmi();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnLingua1_Click(object sender, EventArgs e)
        {
            if (btnLingua1.BackgroundImage == flag1)
            {
                btnLingua1.BackgroundImage = flag2;
                this.linguaManager.ChangeLanguage(impostazioni.Lingua2);
            }
            else if (btnLingua1.BackgroundImage == flag2)
            {
                btnLingua1.BackgroundImage = flag1;
                this.linguaManager.ChangeLanguage(impostazioni.Lingua1);
            }

            //if (btnLingua1.BackgroundImage == flag3)
            //{
            //    btnLingua1.BackgroundImage = flag1;
            //    this.linguaManager.ChangeLanguage(impostazioni.Lingua1);
            //}
            //else if (btnLingua1.BackgroundImage == flag1)
            //{
            //    btnLingua1.BackgroundImage = flag2;
            //    this.linguaManager.ChangeLanguage(impostazioni.Lingua2);
            //}
            //else
            //{
            //    btnLingua1.BackgroundImage = flag3;
            //    this.linguaManager.ChangeLanguage(impostazioni.Lingua3);
            //}
            TraduciControlli();
        }

        #region GESTIONE UTENTI

        private void LoginLogoutManager_OnLogin(object sender, DataType.Utente e)
        {
            try
            {
                CambiaUtente();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void LoginLogoutManager_OnLogout(object sender, Class.LoginLogoutManager.LogoutParams e)
        {
            try
            {
                CambiaUtente();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void CambiaUtente()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { CambiaUtente(); }));
                }
                else
                {
                    DataType.Livello.LivelloUtente l = Class.LoginLogoutManager.GetUserLoggedStato();
                    lblUser.Text = l.ToString();
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion GESTIONE UTENTI

        #region GESTIONE TURNI

        private void InitTurniManager()
        {
            //GESTIONE TURNI
            timerTurni = new System.Timers.Timer(1000);
            timerTurni.Elapsed += OnTimedTurniEvent;
            timerTurni.Enabled = true;
        }

        private void OnTimedTurniEvent(object sender, EventArgs e)
        {
            timerTurni.Stop();
            try
            {
                DataType.Impostazioni impostazioni = DBL.ImpostazioniManager.ReadImpostazioni();

                DateTime? fineTurno = null;
                DateTime oraAttuale = DateTime.Now;

                //query x sapere giorno attuale (storico.Data) e ora fine turno (DefTurno)  
                long idTurnoAttuale = DBL.GestioneTurniManager.ReadID_TurnoAttuale();
                if (idTurnoAttuale > 0)
                {
                    DataType.StoricoTurni giornoAttuale = DBL.GestioneTurniManager.Select_StoricoTurni(idTurnoAttuale);
                    DataType.Definizione_Turni defTurno = DBL.GestioneTurniManager.Select_NomeTurno(giornoAttuale.NomeTurno);

                    //creo DateTime fine turno da confrontare con NOW
                    fineTurno = new DateTime(giornoAttuale.Data.Year, giornoAttuale.Data.Month, giornoAttuale.Data.Day, defTurno.OraFineTurno.Hours, defTurno.OraFineTurno.Minutes, defTurno.OraFineTurno.Seconds);
                    //se sono nel turno a cavallo di un giorno (leggo un valore da DB-->defTurno.Giorno) aggiungo un giorno 
                    fineTurno = fineTurno.Value.AddDays(defTurno.Giorno);
                }
                else
                {
                    // se non ho mai salvato uno storico imposto la data fi fine turno a quella di inizio di quello corrente
                    // in modo da far partire il cambio qui sotto
                    DataType.Definizione_Turni defTurno = DBL.GestioneTurniManager.Select_TurnoAttuale(DateTime.Now);
                    if (defTurno.Giorno == 1 && oraAttuale.TimeOfDay < new TimeSpan(14, 0, 0))
                    {
                        //se sono in un turno a cavallo di due giorni e sono al secondo giorno torno al giorno prima
                        DateTime giornoPrima = oraAttuale.AddDays(-1);
                        fineTurno = new DateTime(giornoPrima.Year, giornoPrima.Month, giornoPrima.Day, defTurno.OraInizioTurno.Hours, defTurno.OraInizioTurno.Minutes, defTurno.OraInizioTurno.Seconds);
                    }
                    else
                    {
                        fineTurno = new DateTime(oraAttuale.Year, oraAttuale.Month, oraAttuale.Day, defTurno.OraInizioTurno.Hours, defTurno.OraInizioTurno.Minutes, defTurno.OraInizioTurno.Seconds);
                    }
                }

                fineTurno = fineTurno.Value.AddSeconds(1);

                if (fineTurno != null)
                {
                    if (oraAttuale > fineTurno)
                    {
                        for (int i = 0; i < this.appManager.Count; i++)
                        {
                            this.appManager[i].CambioTurno();
                        }

                        //CAMBIO TURNO
                        short nomeTurno = CambioTurno(ref oraAttuale);

                        //if (InvokeRequired)
                        //    this.BeginInvoke(new MethodInvoker(() => { CenterLabel(lblTurno, "TURNO " + nomeTurno.ToString()); }));
                        //else
                        //    CenterLabel(lblTurno, "TURNO " + nomeTurno.ToString());

                        //data-->oraAttuale-->salvare in una new riga STORICO TURNI INSERT, turno-->Update id identico storico turni
                        idTurnoAttuale = DBL.GestioneTurniManager.MaxIndex_StoricoTurni();
                        if (idTurnoAttuale < 0)
                            idTurnoAttuale = 0;

                        ResetContatori();

                        idTurnoAttuale++;
                        //NEW Riga per Turno nuovo 
                        DBL.GestioneTurniManager.InsertNewStoricoTurni(new DataType.StoricoTurni(idTurnoAttuale, oraAttuale, nomeTurno));
                        //aggiorno il turno Attuale 
                        DBL.GestioneTurniManager.AggiornoTurnoAttuale(new DataType.Turno_Attuale() { Id = idTurnoAttuale });

                        //RESETTO LE SOGLIE 
                        for (int j = 0; j < this.appManager.Count; j++)
                        {
                            for (int i = 0; i < this.appManager[j].GetNumCamere(); i++)
                            {
                                Class.GraficiSoglieManager graficiSoglieManager = this.appManager[j].GetGraficiSoglieManager(this.appManager[j].CamereId[i]);
                                graficiSoglieManager?.ClearData();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                timerTurni.Start();
            }
        }

        private void ResetContatori()
        {
        }

        private short CambioTurno(ref DateTime oraAttuale)
        {
            short numTurno = -1;

            //lista di tutti i fine turni
            List<DataType.Definizione_Turni> durataTurni = DBL.GestioneTurniManager.Select_DefinizioneTurni();

            durataTurni = durataTurni.OrderBy(o => o.OraFineTurno).ToList();

            bool trovato = false;

            for (int i = 0; i < durataTurni.Count; i++)
            {
                DateTime tmp = Convert.ToDateTime(durataTurni[i].OraFineTurno.ToString());
                if (oraAttuale < tmp)
                {
                    if (durataTurni[i].Giorno == 1)//turno a cavallo-->dopo la mezzanotte
                    {
                        oraAttuale = oraAttuale.AddDays(-1);
                        numTurno = durataTurni[i].NomeTurno;
                        trovato = true;
                        break;
                    }
                    else
                    {
                        numTurno = durataTurni[i].NomeTurno;
                        trovato = true;
                        break;
                    }
                }
            }
            if (!trovato)//turno a cavallo--> prima della mezzanotte
            {
                numTurno = (short)durataTurni.Count;
            }
            return numTurno;
        }

        #endregion GESTIONE TURNI

        private void btnStazione1_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Stazione1);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            this.lampeggioLogAttivo = false;
            btnLog.BackgroundImage = Properties.Resources.alarm_OFF;
            ChangePage(Page.Log);
        }

        private void btnStazione2_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Stazione2);
        }

        private void btnStazione3_Click(object sender, EventArgs e)
        {
            ChangePage(Page.Stazione3);
        }

        private void UcPaginaLog1_OnNewLog(object sender, EventArgs e)
        {
            this.lampeggioLogAttivo = true;
        }

        private void btnAllCamere_Click(object sender, EventArgs e)
        {

        }

        private void UcPaginaLog1_OnBackHome(object sender, EventArgs e)
        {
            ChangePage(Page.Home);
        }

        private void UcPaginaViewComplete3_OnBackHome(object sender, EventArgs e)
        {
            ChangePage(Page.Home);
        }

        private Dictionary<string, ICogFrameGrabber> GetSerialNumberCamere()
        {
            CogFrameGrabbers cfg = new CogFrameGrabbers();

            Dictionary<string, ICogFrameGrabber> dict = new Dictionary<string, ICogFrameGrabber>();

            foreach(ICogFrameGrabber icfg in cfg)
            {
                dict.Add(icfg.OwnedGigEAccess.CurrentIPAddress, icfg);
            }

            foreach (KeyValuePair<string, ICogFrameGrabber> kvp in dict)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
            }
            return dict;
        }

    }
}