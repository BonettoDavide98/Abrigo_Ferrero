using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewLogDettaglio : UserControl
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private int numCamere = -1;
        private DataType.Impostazioni impostazioni = null;
        private object repaintLock = null;

        private Utilities.CogWndCtrlManager hWndCtrlManager = null;

        private int cntMaxCtrl = 0;

        private UCLogSingolo[] logCtrlSingolo = null;
        private UCLogMulti3[] logCtrlMulti3 = null;
        private UCLogMulti5[] logCtrlMulti5 = null;

        public UCPaginaViewLogDettaglio()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int idStazione, int numCamere, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.appManager = appManager;
            this.idStazione = idStazione;
            this.numCamere = numCamere;
            this.impostazioni = impostazioni;
            this.repaintLock = repaintLock;

            this.cntMaxCtrl = this.impostazioni.NumeroErrori;

            this.hWndCtrlManager = new Utilities.CogWndCtrlManager(panelImage, true, true);

            this.logCtrlSingolo = new UCLogSingolo[this.cntMaxCtrl];
            this.logCtrlMulti3 = new UCLogMulti3[this.cntMaxCtrl];
            this.logCtrlMulti5 = new UCLogMulti5[this.cntMaxCtrl];

            for (int i = this.cntMaxCtrl - 1; i >= 0; i--)
            {
                if (numCamere == 1)
                {
                    UCLogSingolo logCtrl = new UCLogSingolo();
                    logCtrl.Init(impostazioni, this.repaintLock);
                    flowLayoutPanel1.Controls.Add(logCtrl);
                    logCtrl.CanSelect = false;

                    this.logCtrlSingolo[i] = logCtrl;
                }
                else if (numCamere == 3)
                {
                    UCLogMulti3 logCtrl = new UCLogMulti3();
                    logCtrl.Init(impostazioni, linguaManager, this.repaintLock);
                    flowLayoutPanel1.Controls.Add(logCtrl);

                    this.logCtrlMulti3[i] = logCtrl;

                    logCtrl.OnOpenDettaglio += LogCtrl_OnOpenDettaglio;
                }
                else
                {
                    UCLogMulti5 logCtrl = new UCLogMulti5();
                    logCtrl.Init(impostazioni, linguaManager, this.repaintLock);
                    flowLayoutPanel1.Controls.Add(logCtrl);

                    this.logCtrlMulti5[i] = logCtrl;

                    logCtrl.OnOpenDettaglio += LogCtrl_OnOpenDettaglio;
                }
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {

        }

        public void ShowErrors()
        {
            try
            {
                if (cntMaxCtrl == 0)
                    return;

                this.appManager.GetLastError(out List<Utilities.ObjectToDisplay[]> iconicVarError, out List<DataType.ElaborateResult[]> resultError, out List<DateTime> dateTimeError);

                if (this.numCamere == 1)
                    ShowErrorsSingolo(iconicVarError, resultError, dateTimeError);
                else if (this.numCamere == 3)
                    ShowErrorsMulti3(iconicVarError, resultError, dateTimeError);
                else
                    ShowErrorsMulti5(iconicVarError, resultError, dateTimeError);
            }
            catch (Exception) { }
        }

        public void ShowErrorsSingolo(List<Utilities.ObjectToDisplay[]> iconicVarError, List<DataType.ElaborateResult[]> resultError, List<DateTime> dateTimeError)
        {
            for (int i = this.cntMaxCtrl - 1; i >= 0; i--)
            {
                if (iconicVarError.Count > i && resultError.Count > i)
                {
                    this.flowLayoutPanel1.Controls.SetChildIndex(logCtrlSingolo[i], this.cntMaxCtrl - i - 1);
                    logCtrlSingolo[i].SetData(iconicVarError[i][0].Clone(), resultError[i][0], dateTimeError[i]);
                    logCtrlSingolo[i].Visible = true;
                }
                else
                    logCtrlSingolo[i].Visible = false;
            }
        }

        public void ShowErrorsMulti3(List<Utilities.ObjectToDisplay[]> iconicVarError, List<DataType.ElaborateResult[]> resultError, List<DateTime> dateTimeError)
        {
            for (int i = this.cntMaxCtrl - 1; i >= 0; i--)
            {
                if (iconicVarError.Count > i && resultError.Count > i)
                {
                    this.flowLayoutPanel1.Controls.SetChildIndex(logCtrlMulti3[i], this.cntMaxCtrl - i - 1);
                    Utilities.ObjectToDisplay[] arrayLists = iconicVarError[i].Select(k => k.Clone()).ToArray();
                    logCtrlMulti3[i].SetData(arrayLists, resultError[i], dateTimeError[i]);
                    logCtrlMulti3[i].Visible = true;
                }
                else
                    logCtrlMulti3[i].Visible = false;
            }
        }

        public void ShowErrorsMulti5(List<Utilities.ObjectToDisplay[]> iconicVarError, List<DataType.ElaborateResult[]> resultError, List<DateTime> dateTimeError)
        {
            for (int i = this.cntMaxCtrl - 1; i >= 0; i--)
            {
                if (iconicVarError.Count > i && resultError.Count > i)
                {
                    this.flowLayoutPanel1.Controls.SetChildIndex(logCtrlMulti5[i], this.cntMaxCtrl - i - 1);
                    Utilities.ObjectToDisplay[] arrayLists = iconicVarError[i].Select(k => k.Clone()).ToArray();
                    logCtrlMulti5[i].SetData(arrayLists, resultError[i], dateTimeError[i]);
                    logCtrlMulti5[i].Visible = true;
                }
                else
                    logCtrlMulti5[i].Visible = false;
            }
        }

        private void VisualizzaTesti(RichTextBox lbl, DataType.ElaborateResult res)
        {
            try
            {
                lbl.Text = string.Empty;

                if (res != null)
                {
                    for (int i = 0; i < res.TestiRagioneScarto.Count; i++)
                    {
                        AppendText(lbl, res.TestiRagioneScarto[i] + "\n\r", System.Drawing.Color.Red);
                    }

                    lbl.Text += Environment.NewLine;

                    for (int i = 0; i < res.TestiOutAlgoritmi.Count; i++)
                    {
                        AppendText(lbl, res.TestiOutAlgoritmi[i].Item1 + "\n\r", res.TestiOutAlgoritmi[i].Item2 == Cognex.VisionPro.CogColorConstants.Red? System.Drawing.Color.Red : System.Drawing.Color.Green);
                    }
                }
            }
            catch (Exception) { }
        }


        private void AppendText(RichTextBox rtb, string text, System.Drawing.Color color)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = color;
            rtb.AppendText(text);
            rtb.SelectionColor = rtb.ForeColor;
        }

        private void LogCtrl_OnOpenDettaglio(Utilities.ObjectToDisplay objectTodisplay, DataType.ElaborateResult result)
        {
            ucTabControl1.SelectedTab = tabPageDettaglio;
            hWndCtrlManager.DisplaySetupOutputCamera(objectTodisplay, result);
            VisualizzaTesti(richTextBox1, result);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageMain;
        }

    }
}