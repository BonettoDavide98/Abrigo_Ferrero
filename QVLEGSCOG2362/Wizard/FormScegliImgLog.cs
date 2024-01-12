using Cognex.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Wizard
{
    public partial class FormScegliImgLog : Form
    {

        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;
        private object repaintLock = null;

        private UCLogSingolo selectedUC = null;

        public FormScegliImgLog(Class.AppManager appManager, int idCamera, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                this.impostazioni = impostazioni;
                this.linguaManager = linguaManager;
                this.repaintLock = repaintLock;

                btnConferma.Text = linguaManager.GetTranslation("BTN_CONFERMA");
                btnAnnulla.Text = linguaManager.GetTranslation("BTN_ANNULLA");
                lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_SCEGLI_LOG");


                appManager.GetLastError(idCamera, out List<Utilities.ObjectToDisplay> iconicVarError, out List<DataType.ElaborateResult> resultError, out List<DateTime> dateTimeError);
                ShowImage(iconicVarError, resultError, dateTimeError);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void ShowImage(List<Utilities.ObjectToDisplay> iconicVarError, List<DataType.ElaborateResult> resultError, List<DateTime> dateTimeError)
        {
            for (int i = iconicVarError.Count - 1; i >= 0; i--)
            {
                UCLogSingolo logCtrl = new UCLogSingolo();

                logCtrl.Init(impostazioni, this.repaintLock);
                logCtrl.SetData(iconicVarError[i], resultError[i], dateTimeError[i]);
                logCtrl.WasClicked += UsersGrid_WasClicked;

                flowLayoutPanel1.Controls.Add(logCtrl);
            }
        }

        public ICogImage GetImage()
        {
            ICogImage ret = null;
            if (selectedUC != null)
            {
                ret = selectedUC.GetImage();
            }
            //TODO:
            //else if (string.IsNullOrWhiteSpace(txtFileName.Text) == false)
            //{
            //    ret = new ICogImage();
            //    ret.ReadImage(txtFileName.Text);
            //}
            return ret;
        }

        // Event handler for when MouseClick is raised in a UserControl.
        private void UsersGrid_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is UCLogSingolo)
                {
                    ((UCLogSingolo)c).IsSelected = false;
                }
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            try
            {
                UCLogSingolo selectedUC = flowLayoutPanel1.Controls.Cast<UCLogSingolo>().FirstOrDefault(uc => uc.IsSelected);
                if (selectedUC != null)
                {
                    this.selectedUC = selectedUC;
                    this.DialogResult = DialogResult.OK;
                }
                else if (string.IsNullOrWhiteSpace(txtFileName.Text) == false)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_NO_IMG_SELECTED"), this.linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtFileName.Text = ofd.FileName;
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
