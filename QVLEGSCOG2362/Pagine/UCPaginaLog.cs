using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaLog : UserControl
    {
        private List<Class.AppManager> appManager = null;
        private object lockObj = new object();
        public event EventHandler OnBackHome = null;
        public event EventHandler OnNewLog = null;

        private DBL.LinguaManager linguaManager = null;

        private bool[] allarmiPLC_OLD = null;

        public UCPaginaLog()
        {
            InitializeComponent();
        }

        public void Init(List<Class.AppManager> appManager)
        {
            this.appManager = appManager;
            this.ucNotificationPanel1.OnNewLog += UcNotificationPanel1_OnNewLog;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            this.linguaManager = linguaManager;

            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_LOG");
        }

        private void ucNotificationPanel1_OnReset(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnBackHome != null)
                    OnBackHome.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void UcNotificationPanel1_OnNewLog(object sender, EventArgs e)
        {
            try
            {
                if (OnNewLog != null)
                    OnNewLog.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnResetAllarmi_Click(object sender, EventArgs e)
        {
            try
            {
                this.ucNotificationPanel1.Reset();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void SetAllarmiAttivi(bool[] allarmiPLC)
        {
            try
            {
                if (this.allarmiPLC_OLD == null)
                {
                    this.allarmiPLC_OLD = new bool[16];
                }

                for (int i = 0; i < allarmiPLC.Length; i++)
                {
                    string mex = this.linguaManager.GetTranslation("MSG_ALLARMI_PLC_" + i.ToString());

                    if (allarmiPLC[i] && this.allarmiPLC_OLD[i] != allarmiPLC[i])
                    {
                        this.ucNotificationPanel1.UpdateRitentivi(i, true, mex);
                    }
                    else if (!allarmiPLC[i])
                    {
                        this.ucNotificationPanel1.UpdateRitentivi(i, false, mex);
                    }

                    //faccio la copia
                    this.allarmiPLC_OLD[i] = allarmiPLC[i];
                }
            }
            catch (Exception ex)
            {
                //Class.ExceptionManager.AddException(ex);
            }
        }
    }
}