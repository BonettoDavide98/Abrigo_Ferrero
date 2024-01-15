using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaLive5Cam : UserControl, IUCPaginaLive
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera1 = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera2 = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera3 = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera4 = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera5 = null;

        public UCPaginaLive5Cam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int idStazione, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;
            this.idStazione = idStazione;
            this.repaintLock = repaintLock;

            this.hWndCtrlManagerCamera1 = new Utilities.CogWndCtrlManager(panelCamera1, impostazioni);

            this.hWndCtrlManagerCamera2 = new Utilities.CogWndCtrlManager(panelCamera2, impostazioni);

            this.hWndCtrlManagerCamera3 = new Utilities.CogWndCtrlManager(panelCamera3, impostazioni);

            this.hWndCtrlManagerCamera4 = new Utilities.CogWndCtrlManager(panelCamera4, impostazioni);

            this.hWndCtrlManagerCamera5 = new Utilities.CogWndCtrlManager(panelCamera5, impostazioni);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblCam1.Text = linguaManager.GetTranslation("BTN_CAM_1");
            lblCam2.Text = linguaManager.GetTranslation("BTN_CAM_2");
            lblCam3.Text = linguaManager.GetTranslation("BTN_CAM_3");
            lblCam4.Text = linguaManager.GetTranslation("BTN_CAM_4");
            lblCam5.Text = linguaManager.GetTranslation("BTN_CAM_5");
        }

        public void ActivateDisplay()
        {
            appManager.SetNewImageToDisplayEvent(OnNewImage);
        }

        private void OnNewImage(Utilities.ObjectToDisplay[] iconicVarList, DataType.ElaborateResult[] result)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() => { OnNewImage(iconicVarList, result); }));
                }
                else
                {
                    hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                    hWndCtrlManagerCamera2.DisplaySetupOutputCamera(iconicVarList[1], result[1]);
                    hWndCtrlManagerCamera3.DisplaySetupOutputCamera(iconicVarList[2], result[2]);
                    hWndCtrlManagerCamera4.DisplaySetupOutputCamera(iconicVarList[3], result[3]);
                    hWndCtrlManagerCamera5.DisplaySetupOutputCamera(iconicVarList[4], result[4]);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}