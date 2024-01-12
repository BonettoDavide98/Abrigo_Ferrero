using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCNotificationPanel : UserControl
    {

        public event EventHandler OnReset = null;

        private object lockObj = new object();

        private string[] allarmiRitentivi = new string[100];
        private bool[] isOnAllarmiRitentivi = new bool[100];

        private int cntAllarmiAttuali = 0;

        public UCNotificationPanel()
        {
            InitializeComponent();
        }

        public void InsertIndependentMessage(String text)
        {
            try
            {

            }
            catch (Exception)
            {
                //Volutamente vuoto
            }
        }

        public void ClearMessages()
        {
            lock (lockObj)
            {
                listBoxMessages.BeginUpdate();
                try
                {
                    for (int i = listBoxMessages.Items.Count - 1; i >= this.cntAllarmiAttuali; i--)
                        listBoxMessages.Items.RemoveAt(i);
                }
                catch (Exception) { }
                finally
                {
                    listBoxMessages.EndUpdate();
                }
            }
        }

        public void UpdateRitentivi(int idAllarme, bool isOn, string messaggio)
        {
            if (isOnAllarmiRitentivi[idAllarme] != isOn)
            {
                allarmiRitentivi[idAllarme] = isOn ? messaggio : string.Empty;
                isOnAllarmiRitentivi[idAllarme] = isOn;

                RedrawAllarmiRitentivi();
            }
        }

        private void RedrawAllarmiRitentivi()
        {
            lock (lockObj)
            {
                listBoxMessages.BeginUpdate();
                try
                {
                    for (int i = this.cntAllarmiAttuali - 1; i >= 0; i--)
                        listBoxMessages.Items.RemoveAt(i);

                    this.cntAllarmiAttuali = 0;
                    foreach (string s in allarmiRitentivi)
                        if (s != null && s != string.Empty)
                        {
                            listBoxMessages.Items.Insert(0, s);
                            this.cntAllarmiAttuali++;
                        }
                }
                catch (Exception) { }
                finally
                {
                    listBoxMessages.EndUpdate();
                }
            }
        }

        private void timerAsyncOperations_Tick(object sender, EventArgs e)
        {
            lock (lockObj)
            {
                Exception ex = Class.ExceptionManager.GetException();
                if (ex != null)
                {
                    listBoxMessages.Items.Insert(this.cntAllarmiAttuali, DateTime.Now.ToString() + "  " + ex.Message);
                }
            }
        }

        private void buttonResetMessages_Click(object sender, EventArgs e)
        {
            ClearMessages();
            OnReset?.Invoke(this, new EventArgs());
        }

    }

}