using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.UCEditAlgoritmo
{
    public partial class UCEditExpoGain : UserControl
    {

        public event EventHandler OnComplete = null;

        private int idCamera = -1;
        private string idFormato = string.Empty;
        private DataType.Impostazioni impostazioni = null;
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;
        private Class.AppManager appManager = null;
        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private DBL.LinguaManager linguaManager = null;
        private object repaintLock = null;

        private bool completo = false;

        public UCEditExpoGain()
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

            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_IMMAGINE");
            lblNum.Text = num.ToString();
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_UC_PARAM_IMMAGINE");

            if (completo)
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
            else
                lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
        }

        public void SetAlgoritmo(string idFormato, Algoritmi.AlgoritmoWizard algoritmoWizard)
        {
            try
            {
                this.idFormato = idFormato;
                this.algoritmoWizard = algoritmoWizard;
                CheckForComplete();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        private void CheckForComplete()
        {
            if (this.algoritmoWizard != null)
            {
                DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();
                if (parametri.WizardAcqCompleto)
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_COMPLETO");
                    completo = true;

                    btnEdit.Enabled = true;
                    panelComplete.BackColor = System.Drawing.Color.Green;

                    OnComplete?.Invoke(this, null);
                }
                else
                {
                    lblParametri.Text = linguaManager.GetTranslation("MSG_WIZARD_NON_COMPLETO");
                    completo = false;

                    btnEdit.Enabled = false;
                    panelComplete.BackColor = System.Drawing.Color.Red;
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

                Wizard.WizardAcq wizard = new Wizard.WizardAcq(this.appManager, this.idCamera, this.idFormato, core, this.algoritmoWizard, this.impostazioni, modifica, this.linguaManager, this.repaintLock);
                if (wizard.ShowDialog() == DialogResult.OK)
                {
                    wizard.Salva();
                    this.simpleDirtyTracker.SetAsDirty();
                }
                else
                {
                    this.algoritmoWizard.SetAlgoritmoParam(DataType.Extension.DeSerializeStringAsT<DataType.ParametriAlgoritmo>(parXml));

                    DataType.ParametriAlgoritmo param = this.algoritmoWizard.GetAlgoritmoParam();
                    core.GetFrameGrabberManager().SetExpo(param.Expo);
                    core.GetFrameGrabberManager().SetGain(param.Gain);
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

    }
}