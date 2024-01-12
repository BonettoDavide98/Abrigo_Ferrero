using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat4 : UserControl
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        private UCPaginaViewStat4Dettaglio ucPaginaViewStatDettaglio = null;

        public UCPaginaViewStat4()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            try
            {
                this.appManager = appManager;
                this.impostazioni = impostazioni;
                this.linguaManager = linguaManager;

                int numCamere = this.appManager.GetNumCamere();
                int idStazione = this.appManager.GetIdStazione();

                ucPaginaViewStatDettaglio = InitPageStazioni(idStazione, linguaManager);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private UCPaginaViewStat4Dettaglio InitPageStazioni(int idStazione, DBL.LinguaManager linguaManager)
        {
            UCPaginaViewStat4Dettaglio ret = null;

            ret = new UCPaginaViewStat4Dettaglio();
            panelContainer.Controls.Add(ret);
            ret.Dock = DockStyle.Fill;
            ret.Init(idStazione, linguaManager);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_STATISTICHE_4");

            ucPaginaViewStatDettaglio?.Translate(linguaManager);
        }

    }
}