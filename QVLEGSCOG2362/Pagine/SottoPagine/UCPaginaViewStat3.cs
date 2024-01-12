using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat3 : UserControl
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        private UCPaginaViewStat3Dettaglio ucPaginaViewStatDettaglio = null;

        public UCPaginaViewStat3()
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

                RefreshGrafico();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private UCPaginaViewStat3Dettaglio InitPageStazioni(int idStazione, int numCamere, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            UCPaginaViewStat3Dettaglio ret = null;

            ret = new UCPaginaViewStat3Dettaglio();
            panelContainer.Controls.Add(ret);
            ret.Dock = DockStyle.Fill;
            ret.Init(idStazione, impostazioni);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_STATISTICHE_3");

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

        public void GetPercScarto(out double perScartoTurnoPrecedente, out double perScartoTurnoAttuale, out double perScartoUltimaOra)
        {
            ucPaginaViewStatDettaglio.GetPercScarto(out perScartoTurnoPrecedente, out perScartoTurnoAttuale, out perScartoUltimaOra);
        }

    }
}
