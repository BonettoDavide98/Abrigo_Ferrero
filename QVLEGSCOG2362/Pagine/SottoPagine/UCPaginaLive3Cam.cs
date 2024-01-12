using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaLive3Cam : UserControl, IUCPaginaLive
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera1 = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera2 = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera3 = null;

        public UCPaginaLive3Cam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int idStazione, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;
            this.idStazione = idStazione;
            this.repaintLock = repaintLock;

            this.hWndCtrlManagerCamera1 = new Utilities.CogWndCtrlManager(panelCamera1);

            this.hWndCtrlManagerCamera2 = new Utilities.CogWndCtrlManager(panelCamera2);

            this.hWndCtrlManagerCamera3 = new Utilities.CogWndCtrlManager(panelCamera3);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblCam1.Text = linguaManager.GetTranslation("BTN_CAM_" + (this.idStazione * 3 + 1).ToString());
            lblCam2.Text = linguaManager.GetTranslation("BTN_CAM_" + (this.idStazione * 3 + 2).ToString());
            lblCam3.Text = linguaManager.GetTranslation("BTN_CAM_" + (this.idStazione * 3 + 3).ToString());
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
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}