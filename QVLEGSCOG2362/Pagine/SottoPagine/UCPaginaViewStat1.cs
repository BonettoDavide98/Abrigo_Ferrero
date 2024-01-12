using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat1 : UserControl
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        private UCPaginaViewStat1Dettaglio ucPaginaViewStatDettaglio = null;

        public UCPaginaViewStat1()
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

                RefreshGrafico();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private UCPaginaViewStat1Dettaglio InitPageStazioni(int idStazione, DBL.LinguaManager linguaManager)
        {
            UCPaginaViewStat1Dettaglio ret = null;

            ret = new UCPaginaViewStat1Dettaglio();
            panelContainer.Controls.Add(ret);
            ret.Dock = DockStyle.Fill;
            ret.Init(idStazione, linguaManager);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_STATISTICHE_1");

            ucPaginaViewStatDettaglio?.Translate(linguaManager);
        }

        public void RefreshGrafico()
        {
            try
            {
                ucPaginaViewStatDettaglio?.RefreshGrafico();
            }
            catch (Exception) { }
        }

    }
}