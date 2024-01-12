using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewLog : UserControl
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private object repaintLock = null;

        private int cntMaxCtrl = 0;

        private UCPaginaViewLogDettaglio ucPaginaViewLogDettaglio = null;

        public UCPaginaViewLog()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.appManager = appManager;
            this.impostazioni = impostazioni;
            this.repaintLock = repaintLock;

            this.cntMaxCtrl = this.impostazioni.NumeroErrori;

            int numCamere = this.appManager.GetNumCamere();
            int idStazione = this.appManager.GetIdStazione();

            ucPaginaViewLogDettaglio = InitPageStazioni(idStazione, numCamere, impostazioni, linguaManager, repaintLock);
        }

        private UCPaginaViewLogDettaglio InitPageStazioni(int idStazione, int numCamere, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            UCPaginaViewLogDettaglio ret = null;

            ret = new UCPaginaViewLogDettaglio();
            panelContainer.Controls.Add(ret);
            ret.Dock = DockStyle.Fill;
            ret.Init(appManager, idStazione, numCamere, impostazioni, linguaManager, repaintLock);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_PAGINA_LOG");

            ucPaginaViewLogDettaglio?.Translate(linguaManager);
        }

        public void ShowErrors()
        {
            ucPaginaViewLogDettaglio?.ShowErrors();
        }

    }
}