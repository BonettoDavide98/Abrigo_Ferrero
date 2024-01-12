using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaLive : UserControl
    {

        private Class.AppManager appManager = null;

        private IUCPaginaLive ucPaginaLiveStazioni = null;

        public UCPaginaLive()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;

            int numCamere = this.appManager.GetNumCamere();
            int idStazione = this.appManager.GetIdStazione();

            ucPaginaLiveStazioni = InitPageStazioni(idStazione, numCamere, impostazioni, repaintLock);
        }

        private IUCPaginaLive InitPageStazioni(int idStazione, int numCamere, DataType.Impostazioni impostazioni, object repaintLock)
        {
            IUCPaginaLive ret = null;

            if (numCamere == 1)
            {
                var uc = new UCPaginaLive1Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (numCamere == 2)
            {
                var uc = new UCPaginaLive2Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (numCamere == 3)
            {
                var uc = new UCPaginaLive3Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (numCamere == 5)
            {
                var uc = new UCPaginaLive5Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }

            ret.Init(appManager, idStazione, impostazioni, repaintLock);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_LIVE");

            ucPaginaLiveStazioni?.Translate(linguaManager);
        }

        public void ActivateDisplay()
        {
            ucPaginaLiveStazioni?.ActivateDisplay();
        }

    }
}