using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaDiagnostica : UserControl
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;
        private object repaintLock = null;

        public UCPaginaDiagnostica()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.appManager = appManager;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;
            this.repaintLock = repaintLock;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_DIAGNOSTICA");
            btnAbilitaSalvataggioFoto.Text = linguaManager.GetTranslation("BTN_ABILITA_SALVATAGGIO");
        }

        private void btnAbilitaSalvataggioFoto_Click(object sender, EventArgs e)
        {
            bool saveEnable = this.appManager.GetSaveEnable();
            this.appManager.
                SetSaveEnable(!saveEnable, 100);

            saveEnable = this.appManager.GetSaveEnable();
            panelStatoSalvataggio.BackColor = saveEnable ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

    }
}