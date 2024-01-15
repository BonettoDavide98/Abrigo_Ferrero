using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.UCEditAlgoritmo
{
    public partial class UCEditAlgAcetato : UserControl
    {

        private int idCamera = -1;
        private DataType.Impostazioni impostazioni = null;
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;
        private Class.AppManager appManager = null;
        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private DBL.LinguaManager linguaManager = null;
        private object repaintLock = null;

        private bool completo = false;

        public UCEditAlgAcetato()
        {
            InitializeComponent();
        }

        public void Init(int num, Class.AppManager appManager, int idCamera, DataType.Impostazioni impostazioni, Utilities.SimpleDirtyTracker simpleDirtyTracker, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.idCamera = idCamera;
            this.impostazioni = impostazioni;
            this.simpleDirtyTracker = simpleDirtyTracker;
            this.appManager = appManager;
            this.linguaManager = linguaManager;
            this.repaintLock = repaintLock;

            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_ACETATO");
            lblNum.Text = num.ToString();
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_ACETATO");

            if (completo)
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
            else
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
        }

        public void SetAlgoritmo(Algoritmi.AlgoritmoWizard algoritmoWizard)
        {
            chbEnable.CheckedChanged -= chbEnable_CheckedChanged;
            try
            {
                this.algoritmoWizard = algoritmoWizard;
                CheckForComplete();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                chbEnable.CheckedChanged += chbEnable_CheckedChanged;
            }
        }

        public void CheckForComplete()
        {
            if (this.algoritmoWizard != null)
            {
                DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();

                //Se non ho fatto il wizard acq e quello di allineamento non sono abilitato
                //this.Enabled = parametri.WizardAcqCompleto && parametri.AllineamentoParam.WizardCompleto;

                btnNew.Enabled = true;
                if (parametri.AcetatoParam.WizardCompleto)
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
                    completo = true;

                    btnEdit.Enabled = true;
                    panelComplete.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
                    completo = false;

                    btnEdit.Enabled = false;
                    panelComplete.BackColor = System.Drawing.Color.Red;
                }

                chbEnable.Checked = parametri.AcetatoParam.AbilitaControllo;

                if (chbEnable.Checked == false)
                {
                    btnNew.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }
        }

        private void OpenWizard(bool modifica)
        {
            Class.CoreRegolazioni core = null;
            try
            {
                core = this.appManager.GetCoreRegolazioni(this.idCamera);
                core.Run();

                DataType.ParametriAlgoritmo pAlg = this.algoritmoWizard.GetAlgoritmoParam();
                string parXml = DataType.Extension.SerializeAsString(pAlg);

                if (!modifica)
                {
                    pAlg.AcetatoParam?.Dispose();
                    pAlg.AcetatoParam = new DataType.AcetatoParam();
                    pAlg.AcetatoParam.AbilitaControllo = true;
                }

                Wizard.WizardAcetato wizard = new Wizard.WizardAcetato(this.appManager, this.idCamera, core, this.algoritmoWizard, this.impostazioni, modifica, this.linguaManager, this.repaintLock);
                if (wizard.ShowDialog() == DialogResult.OK)
                {
                    this.simpleDirtyTracker.SetAsDirty();
                }
                else
                {
                    this.algoritmoWizard.SetAlgoritmoParam(DataType.Extension.DeSerializeStringAsT<DataType.ParametriAlgoritmo>(parXml));
                }
                CheckForComplete();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                core?.StopAndWaitEnd(true);
                core?.CloseFrameGrabber();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenWizard(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenWizard(true);
        }

        private void chbEnable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.simpleDirtyTracker.SetAsDirty();
                this.algoritmoWizard.SetAlgAcetatoEnable(chbEnable.Checked);
                CheckForComplete();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}