using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class NotificationPanelDgv : UserControl
    {
        private List<MessaggioDgv> listaMessaggi = null;

        private object lockObj = new object();

        public event EventHandler OnReset = null;
        public event EventHandler OnNewLog = null;

        private string[] allarmiRitentivi = new string[100];
        private bool[] isOnAllarmiRitentivi = new bool[100];

        private int cntAllarmiAttuali = 0;

        public NotificationPanelDgv()
        {
            InitializeComponent();

            listaMessaggi = new List<MessaggioDgv>();
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
                listaMessaggi.Clear();
                //refreshDgv();

                RedrawAllarmiRitentivi();
            }
        }

        public void UpdateRitentivi(int idAllarme, bool isOn, string messaggio)
        {
            if (isOnAllarmiRitentivi[idAllarme] != isOn)
            {
                allarmiRitentivi[idAllarme] = isOn ? messaggio : string.Empty;
                isOnAllarmiRitentivi[idAllarme] = isOn;

                RedrawAllarmiRitentivi();

                if (isOn)
                {
                    if (OnNewLog != null)
                        OnNewLog.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void RedrawAllarmiRitentivi()
        {
            lock (lockObj)
            {
                try
                {
                    for (int i = this.cntAllarmiAttuali - 1; i >= 0; i--)
                        listaMessaggi.RemoveAt(i);

                    this.cntAllarmiAttuali = 0;
                    foreach (string s in allarmiRitentivi)
                        if (s != null && s != string.Empty)
                        {
                            listaMessaggi.Insert(0, new MessaggioDgv() { Messaggio = s });
                            this.cntAllarmiAttuali++;
                        }
                }
                catch (Exception) { }
                finally
                {
                    refreshDgv();
                }
            }
        }

        private void refreshDgv()
        {
            try
            {
                messaggiBindingSource.DataSource = listaMessaggi;
                messaggiBindingSource.ResetBindings(true);

                dgvMessaggi.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Non posso fare l'add del messaggio alla lista, visto che sono già nell'Add...
            }
        }


        private void timerAsyncOperations_Tick(object sender, EventArgs e)
        {
            lock (lockObj)
            {
                Exception ex = Class.ExceptionManager.GetException();
                if (ex != null)
                {
                    listaMessaggi.Insert(this.cntAllarmiAttuali, new MessaggioDgv() { Messaggio = DateTime.Now.ToString() + "  " + ex.ToString() });

                    refreshDgv();
                    //listBoxMessages.Items.Insert(this.cntAllarmiAttuali, DateTime.Now.ToString() + "  " + ex.Message);

                    if (OnNewLog != null)
                        OnNewLog.Invoke(this, EventArgs.Empty);
                }
            }
        }


        private void buttonResetMessages_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearMessages();
                OnReset?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvMessaggi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var messageSelected = (MessaggioDgv)messaggiBindingSource.Current;

                if (messageSelected != null)
                    MessageBox.Show(messageSelected.Messaggio);
            }
            catch (Exception ex)
            {
            }
        }

        public void Reset()
        {
            try
            {
                this.ClearMessages();
                OnReset?.Invoke(this, new EventArgs());
            }
            catch (Exception ex)
            {
            }
        }

        public class MessaggioDgv
        {
            public string Messaggio { get; set; }
        }
    }
}
