using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewSoglie : UserControl
    {

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        public UCPaginaViewSoglie()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            this.appManager = appManager;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_PAGINA_SOGLIE");

            btnCam1.Text = linguaManager.GetTranslation("BTN_CAM_1");
            btnCam2.Text = linguaManager.GetTranslation("BTN_CAM_2");
            btnCam3.Text = linguaManager.GetTranslation("BTN_CAM_3");
            btnCam4.Text = linguaManager.GetTranslation("BTN_CAM_4");
            btnCam5.Text = linguaManager.GetTranslation("BTN_CAM_5");
            btnCam6.Text = linguaManager.GetTranslation("BTN_CAM_6");

            btnSave.Text = linguaManager.GetTranslation("BTN_SALVA");
            btnAnnulla.Text = linguaManager.GetTranslation("BTN_ANNULLA");
            btnReset.Text = linguaManager.GetTranslation("BTN_RESET");

            ucPaginaViewSoglieCam1.Translate(linguaManager);

            int numCamere = this.appManager.GetNumCamere();
            if (numCamere > 1)
                ucPaginaViewSoglieCam2.Translate(linguaManager);
            if (numCamere > 2)
                ucPaginaViewSoglieCam3.Translate(linguaManager);
            if (numCamere > 3)
                ucPaginaViewSoglieCam4.Translate(linguaManager);
            if (numCamere > 4)
                ucPaginaViewSoglieCam5.Translate(linguaManager);
            if (numCamere > 5)
                ucPaginaViewSoglieCam6.Translate(linguaManager);

        }

        public void CaricaRicetta(string idFormato)
        {
            ucPaginaViewSoglieCam1.Init(appManager, this.impostazioni, appManager.CamereId[0], idFormato, linguaManager);

            int numCamere = this.appManager.GetNumCamere();
            if (numCamere > 1)
                ucPaginaViewSoglieCam2.Init(appManager, this.impostazioni, appManager.CamereId[1], idFormato, linguaManager);
            if (numCamere > 2)
                ucPaginaViewSoglieCam3.Init(appManager, this.impostazioni, appManager.CamereId[2], idFormato, linguaManager);
            if (numCamere > 3)
                ucPaginaViewSoglieCam4.Init(appManager, this.impostazioni, appManager.CamereId[3], idFormato, linguaManager);
            if (numCamere > 4)
                ucPaginaViewSoglieCam5.Init(appManager, this.impostazioni, appManager.CamereId[4], idFormato, linguaManager);
            if (numCamere > 5)
                ucPaginaViewSoglieCam6.Init(appManager, this.impostazioni, appManager.CamereId[5], idFormato, linguaManager);

            if (numCamere < 2)
            {
                tabControlMain.TabPages.Remove(tabPageCam2);
                btnCam2.Visible = false;
            }
            if (numCamere < 3)
            {
                tabControlMain.TabPages.Remove(tabPageCam3);
                btnCam3.Visible = false;
            }
            if (numCamere < 4)
            {
                tabControlMain.TabPages.Remove(tabPageCam4);
                btnCam4.Visible = false;
            }
            if (numCamere < 5)
            {
                tabControlMain.TabPages.Remove(tabPageCam5);
                btnCam5.Visible = false;
            }
            if (numCamere < 6)
            {
                tabControlMain.TabPages.Remove(tabPageCam6);
                btnCam6.Visible = false;
            }

            if (numCamere == 1)
                flowLayoutPanelBtnCam.Visible = false;
        }

        private void ResetBackColorBtnCam()
        {
            btnCam1.BackColor = System.Drawing.Color.Gainsboro;
            btnCam2.BackColor = System.Drawing.Color.Gainsboro;
            btnCam3.BackColor = System.Drawing.Color.Gainsboro;
            btnCam4.BackColor = System.Drawing.Color.Gainsboro;
            btnCam5.BackColor = System.Drawing.Color.Gainsboro;
            btnCam6.BackColor = System.Drawing.Color.Gainsboro;
        }

        public void StopUpdate()
        {
            ucPaginaViewSoglieCam1.StopUpdate();

            int numCamere = this.appManager.GetNumCamere();
            if (numCamere > 1)
                ucPaginaViewSoglieCam2.StopUpdate();
            if (numCamere > 2)
                ucPaginaViewSoglieCam3.StopUpdate();
            if (numCamere > 3)
                ucPaginaViewSoglieCam4.StopUpdate();
            if (numCamere > 4)
                ucPaginaViewSoglieCam5.StopUpdate();
            if (numCamere > 5)
                ucPaginaViewSoglieCam6.StopUpdate();
        }

        public void StartUpdate()
        {
            ucPaginaViewSoglieCam1.StartUpdate();

            int numCamere = this.appManager.GetNumCamere();
            if (numCamere > 1)
                ucPaginaViewSoglieCam2.StartUpdate();
            if (numCamere > 2)
                ucPaginaViewSoglieCam3.StartUpdate();
            if (numCamere > 3)
                ucPaginaViewSoglieCam4.StartUpdate();
            if (numCamere > 4)
                ucPaginaViewSoglieCam5.StartUpdate();
            if (numCamere > 5)
                ucPaginaViewSoglieCam6.StartUpdate();
        }


        private void btnCam1_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam1.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCam1;
        }

        private void btnCam2_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam2.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCam2;
        }

        private void btnCam3_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam3.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCam3;
        }

        private void btnCam4_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam4.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCam4;
        }

        private void btnCam5_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam5.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCam5;
        }

        private void btnCam6_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam6.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCam6;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    ucPaginaViewSoglieCam1.Save();

                    int numCamere = this.appManager.GetNumCamere();
                    if (numCamere > 1)
                        ucPaginaViewSoglieCam2.Save();
                    if (numCamere > 2)
                        ucPaginaViewSoglieCam3.Save();
                    if (numCamere > 3)
                        ucPaginaViewSoglieCam4.Save();
                    if (numCamere > 4)
                        ucPaginaViewSoglieCam5.Save();
                    if (numCamere > 5)
                        ucPaginaViewSoglieCam6.Save();
                }
                else
                {
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_LOGIN"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Tecnico)
                {
                    ucPaginaViewSoglieCam1.Reset();

                    int numCamere = this.appManager.GetNumCamere();
                    if (numCamere > 1)
                        ucPaginaViewSoglieCam2.Reset();
                    if (numCamere > 2)
                        ucPaginaViewSoglieCam3.Reset();
                    if (numCamere > 3)
                        ucPaginaViewSoglieCam4.Reset();
                    if (numCamere > 4)
                        ucPaginaViewSoglieCam5.Reset();
                    if (numCamere > 5)
                        ucPaginaViewSoglieCam6.Reset();
                }
                else
                {
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_LOGIN"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}