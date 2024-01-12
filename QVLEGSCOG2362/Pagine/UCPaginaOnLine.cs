using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaOnLine : UserControl
    {

        public enum ShowMode { Show1_N, ShowBad, ShowLock, ShowLong, }

        private Class.AppManager appManager = null;
        private ShowMode showMode = ShowMode.Show1_N;

        private IUCPaginaOnLine ucPaginaOnLineStazioni = null;

        public UCPaginaOnLine()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;

            int numCamere = this.appManager.GetNumCamere();
            int idStazione = this.appManager.GetIdStazione();

            ucPaginaOnLineStazioni = InitPageStazioni(idStazione, numCamere, impostazioni, repaintLock);
        }

        private IUCPaginaOnLine InitPageStazioni(int idStazione, int numCamere, DataType.Impostazioni impostazioni, object repaintLock)
        {
            IUCPaginaOnLine ret = null;

            if (numCamere == 1)
            {
                var uc = new UCPaginaOnLine1Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (numCamere == 2)
            {
                var uc = new UCPaginaOnLine2Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (numCamere == 3)
            {
                var uc = new UCPaginaOnLine3Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }
            else if (numCamere == 5)
            {
                var uc = new UCPaginaOnLine5Cam();
                panelContainer.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                ret = uc;
            }

            ret.Init(appManager, idStazione, impostazioni, repaintLock);

            return ret;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_ONLINE");
            rbShowBad.Text = linguaManager.GetTranslation("LBL_SHOW_BAD");
            rbShowLock.Text = linguaManager.GetTranslation("LBL_SHOW_LOCK");
            rbShow1N.Text = linguaManager.GetTranslation("LBL_SHOW_1_N");
            //rbShowLong.Text = linguaManager.GetTranslation("LBL_SHOW_LONG");

            ucPaginaOnLineStazioni?.Translate(linguaManager);
        }

        public void ActivateDisplay()
        {
            ucPaginaOnLineStazioni?.ActivateDisplay();
        }

        private void rbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShow1N.Checked)
            {
                this.showMode = ShowMode.Show1_N;
            }
            else if (rbShowBad.Checked)
            {
                this.showMode = ShowMode.ShowBad;
            }
            else if (rbShowLock.Checked)
            {
                this.showMode = ShowMode.ShowLock;
            }
            else if (rbShowLong.Checked)
            {
                this.showMode = ShowMode.ShowLong;
            }

            ucPaginaOnLineStazioni?.SetShowMode(this.showMode);
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            this.appManager?.Snap();
        }

        public void AggiornaTimeout(int[] num)
        {
            try
            {
                //lblCntTout.Text = string.Format("{0} {1} {2}", num[0], num[1], num[2]);
            }
            catch (Exception) { }
        }

    }
}