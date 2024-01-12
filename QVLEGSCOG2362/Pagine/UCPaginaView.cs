using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaView : UserControl
    {

        #region Pagine

        private enum Page
        {
            NN,
            OnLine,
            Log,
            Soglie,
            Statistiche1,
            Statistiche2,
            Statistiche3,
            Statistiche4,
        }

        private Page prevPage = Page.NN;

        #endregion

        public UCPaginaView()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            ucPaginaOnLine1.Init(appManager, impostazioni, repaintLock);
            ucPaginaViewLog1.Init(appManager, impostazioni, linguaManager, repaintLock);
            ucPaginaViewSoglie1.Init(appManager, impostazioni, linguaManager);
            ucPaginaViewStat11.Init(appManager, impostazioni, linguaManager);
            ucPaginaViewStat21.Init(appManager, impostazioni, linguaManager);
            ucPaginaViewStat31.Init(appManager, impostazioni, linguaManager);
            ucPaginaViewStat41.Init(appManager, impostazioni, linguaManager);

            timerAggiornaStatistiche.Enabled = true;
        }

        public void ActivateDisplay()
        {
            ucPaginaOnLine1.ActivateDisplay();
        }

        public void CaricaRicetta(string idFormato)
        {
            ucPaginaViewSoglie1.CaricaRicetta(idFormato);
        }


        public void Translate(DBL.LinguaManager linguaManager)
        {
            btnOnline.Text = linguaManager.GetTranslation("BTN_ONLINE");
            btnLog.Text = linguaManager.GetTranslation("BTN_LOG");
            btnSoglie.Text = linguaManager.GetTranslation("BTN_SOGLIE");
            btnStatistiche1.Text = linguaManager.GetTranslation("BTN_STATISTICHE_1");
            btnStatistiche2.Text = linguaManager.GetTranslation("BTN_STATISTICHE_2");
            btnStatistiche3.Text = linguaManager.GetTranslation("BTN_STATISTICHE_3");
            btnStatistiche4.Text = linguaManager.GetTranslation("BTN_STATISTICHE_4");

            ucPaginaOnLine1.Translate(linguaManager);
            ucPaginaViewLog1.Translate(linguaManager);
            ucPaginaViewSoglie1.Translate(linguaManager);
            ucPaginaViewStat11.Translate(linguaManager);
            ucPaginaViewStat21.Translate(linguaManager);
            ucPaginaViewStat31.Translate(linguaManager);
            ucPaginaViewStat41.Translate(linguaManager);
        }


        public void GetPercScarto(out double perScartoTurnoPrecedente, out double perScartoTurnoAttuale, out double perScartoUltimaOra)
        {
            ucPaginaViewStat31.GetPercScarto(out perScartoTurnoPrecedente, out perScartoTurnoAttuale, out perScartoUltimaOra);
        }

        private void ChangePage(Page page)
        {
            bool okChange = true;

            switch (prevPage)
            {
                case Page.OnLine:
                    break;
                case Page.Log:
                    break;
                case Page.Soglie:
                    break;
                case Page.Statistiche1:
                    break;
                case Page.Statistiche2:
                    break;
                case Page.Statistiche3:
                    break;
                case Page.Statistiche4:
                    break;
                case Page.NN:
                default:
                    okChange = true;
                    break;
            }

            if (okChange)
            {
                switch (page)
                {
                    case Page.OnLine:
                        tabControlMain.SelectedTab = tabPageOnLine;
                        break;
                    case Page.Log:
                        ucPaginaViewLog1.ShowErrors();
                        tabControlMain.SelectedTab = tabPageLog;
                        break;
                    case Page.Soglie:
                        tabControlMain.SelectedTab = tabPageSoglie;
                        break;
                    case Page.Statistiche1:
                        tabControlMain.SelectedTab = tabPageStatistiche1;
                        break;
                    case Page.Statistiche2:
                        tabControlMain.SelectedTab = tabPageStatistiche2;
                        break;
                    case Page.Statistiche3:
                        tabControlMain.SelectedTab = tabPageStatistiche3;
                        break;
                    case Page.Statistiche4:
                        tabControlMain.SelectedTab = tabPageStatistiche4;
                        break;
                }

                prevPage = page;
            }

        }

        private void btnOnline_Click(object sender, System.EventArgs e)
        {
            ChangePage(Page.OnLine);
        }

        private void btnLog_Click(object sender, System.EventArgs e)
        {
            ChangePage(Page.Log);
        }

        private void btnSoglie_Click(object sender, System.EventArgs e)
        {
            ChangePage(Page.Soglie);
        }

        private void btnStatistiche1_Click(object sender, System.EventArgs e)
        {
            ChangePage(Page.Statistiche1);
        }

        private void btnStatistiche2_Click(object sender, System.EventArgs e)
        {
            ChangePage(Page.Statistiche2);
        }

        private void btnStatistiche3_Click(object sender, System.EventArgs e)
        {
            ChangePage(Page.Statistiche3);
        }

        private void btnStatistiche4_Click(object sender, System.EventArgs e)
        {
            ChangePage(Page.Statistiche4);
        }

        private void timerAggiornaStatistiche_Tick(object sender, System.EventArgs e)
        {
            timerAggiornaStatistiche.Enabled = false;
            try
            {
                ucPaginaViewStat11.RefreshGrafico();
                ucPaginaViewStat21.RefreshGrafico();
                ucPaginaViewStat31.RefreshGrafico();
            }
            finally
            {
                timerAggiornaStatistiche.Enabled = true;
            }
        }

    }
}