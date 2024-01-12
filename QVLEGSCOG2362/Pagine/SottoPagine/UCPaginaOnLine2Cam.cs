using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaOnLine2Cam : UserControl, IUCPaginaOnLine
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera1 = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera2 = null;

        private UCPaginaOnLine.ShowMode showMode = UCPaginaOnLine.ShowMode.Show1_N;
        private int cnt = 0;

        public UCPaginaOnLine2Cam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int idStazione, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;
            this.idStazione = idStazione;
            this.repaintLock = repaintLock;

            this.hWndCtrlManagerCamera1 = new Utilities.CogWndCtrlManager(panelCamera1, false, false);

            this.hWndCtrlManagerCamera2 = new Utilities.CogWndCtrlManager(panelCamera2, false, false);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblCam1.Text = linguaManager.GetTranslation("BTN_CAM_1");
            lblCam2.Text = linguaManager.GetTranslation("BTN_CAM_2");
        }

        public void ActivateDisplay()
        {
            appManager.SetNewImageToDisplayEvent(OnNewImage);
        }

        public void SetShowMode(UCPaginaOnLine.ShowMode showMode)
        {
            this.showMode = showMode;
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
                    bool show = false;

                    //if (this.showMode == ShowMode.ShowBad && result.Count(k => k == null || k.Success == false) > 0)
                    if (this.showMode == UCPaginaOnLine.ShowMode.ShowBad && result.Count(k => k != null && k.Success == false) > 0)
                        show = true;
                    else if (this.showMode == UCPaginaOnLine.ShowMode.Show1_N && ++cnt >= 1)
                    {
                        cnt = 0;
                        show = true;
                    }

                    if (show)
                    {
                        hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                        hWndCtrlManagerCamera2.DisplaySetupOutputCamera(iconicVarList[1], result[1]);
                    }
                    else
                    {
                        for (int i = 0; i < iconicVarList.Length; i++)
                            Utilities.CommonUtility.ClearArrayList(iconicVarList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}