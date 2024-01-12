using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat2 : UserControl
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        private UCPaginaViewStat2Dettaglio ucPaginaViewStatDettaglio = null;

        public UCPaginaViewStat2()
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

                ucPaginaViewStatDettaglio = InitPageStazioni(idStazione, numCamere, impostazioni, linguaManager);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private UCPaginaViewStat2Dettaglio InitPageStazioni(int idStazione, int numCamere, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            UCPaginaViewStat2Dettaglio ret = null;

            ret = new UCPaginaViewStat2Dettaglio();
            panelContainer.Controls.Add(ret);
            ret.Dock = DockStyle.Fill;
            ret.Init(idStazione, linguaManager);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_STATISTICHE_2");

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