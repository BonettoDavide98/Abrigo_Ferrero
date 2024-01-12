using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaOnLine1Cam : UserControl, IUCPaginaOnLine
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.CogWndCtrlManager hWndCtrlManagerCamera1 = null;

        private UCPaginaOnLine.ShowMode showMode = UCPaginaOnLine.ShowMode.Show1_N;
        private int cnt = 0;

        public UCPaginaOnLine1Cam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int idStazione, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;
            this.idStazione = idStazione;
            this.repaintLock = repaintLock;

            this.hWndCtrlManagerCamera1 = new Utilities.CogWndCtrlManager(panelCamera1, false, false);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
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

                    if (this.showMode == UCPaginaOnLine.ShowMode.ShowBad && result[0].Success == false)
                        show = true;
                    else if (this.showMode == UCPaginaOnLine.ShowMode.Show1_N && ++cnt >= 1)
                    {
                        cnt = 0;
                        show = true;
                    }

                    if (show)
                    {
                        this.hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                    }
                    else
                    {
                        for (int i = 0; i < iconicVarList.Length; i++)
                            Utilities.CommonUtility.ClearArrayList(iconicVarList[0]);
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