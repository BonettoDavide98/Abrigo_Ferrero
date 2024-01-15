using System;

namespace QVLEGSCOG2362.Wizard
{
    public partial class WizardAcetato : TSWizards.BaseWizard
    {

        #region Variabili Private

        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly UCStepAcetato step1 = null;

        #endregion Variabili Private

        public WizardAcetato(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();

            try
            {
                base.SetTextButtons(linguaManager.GetTranslation("BTN_WIZARD_BACK"), linguaManager.GetTranslation("BTN_WIZARD_NEXT"), linguaManager.GetTranslation("BTN_WIZARD_END"), linguaManager.GetTranslation("BTN_WIZARD_CANCEL"));

                this.algoritmoWizard = algoritmoWizard;

                this.FirstStepName = "Step1";

                step1 = new UCStepAcetato(appManager, idCamera, core, this.algoritmoWizard, impostazioni, modifica, linguaManager, repaintLock);
                step1.NextStep = "FINISHED";
                step1.PreviousStep = "";

                this.AddStep("Step1", step1);

                DataType.ParametriAlgoritmo parametri = this.algoritmoWizard.GetAlgoritmoParam();
                this.algoritmoWizard.SetWizardImage(parametri.ImageRef);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Utilities.WaitManager.CloseWaitForm();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnFinishClicked(EventArgs e)
        {
            base.OnFinishClicked(e);

            this.algoritmoWizard.SetWizardAcetatoComplete();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}