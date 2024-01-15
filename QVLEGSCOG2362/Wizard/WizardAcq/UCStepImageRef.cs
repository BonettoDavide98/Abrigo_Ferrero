using Cognex.VisionPro;
using System;

namespace QVLEGSCOG2362.Wizard
{
    public partial class UCStepImageRef : TSWizards.BaseExteriorStep
    {

        private const int ROI_TRAIN = 1;

        #region Variabili Private

        private readonly Class.AppManager appManager = null;
        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly object repaintLock = null;
        private readonly Utilities.CogWndCtrlManager hWndCtrlManager = null;

        private bool modifica = false;

        #endregion Variabili Private

        public UCStepImageRef(Class.AppManager appManager, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();
            try
            {
                this.appManager = appManager;
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.repaintLock = repaintLock;
                this.modifica = modifica;

                this.hWndCtrlManager = new Utilities.CogWndCtrlManager(panelContainer, impostazioni);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                Description.Text = linguaManager.GetTranslation("LBL_STEP_IMAGE_REF");
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE_IMAGE_REF");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnUltimaFoto.Text = linguaManager.GetTranslation("BTN_ULTIMA_FOTO");
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnShowStep(TSWizards.ShowStepEventArgs e)
        {
            if (!modifica)
                EseguiStep();

            this.core.Run();

            EseguiStepImgWizard();

            base.OnShowStep(e);
        }

        protected override void OnValidateStep(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo param)
        {

        }

        private void EseguiStep()
        {
            ICogImage image = null;
            try
            {
                image = this.core.GetLastGrabImage();
                if (image != null)
                {
                    this.hWndCtrlManager.DisplayModelGraphics(image.CopyBase(CogImageCopyModeConstants.CopyPixels));
                    this.algoritmoWizard.SetWizardImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                //??
                ((IDisposable)image).Dispose();
            }
        }

        private void EseguiStepImgWizard()
        {
            ICogImage image = null;
            try
            {
                image = this.algoritmoWizard.GetWizardImage();
                if (image != null)
                {
                    this.hWndCtrlManager.DisplayModelGraphics(image.CopyBase(CogImageCopyModeConstants.CopyPixels));
                    this.algoritmoWizard.SetWizardImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                //??
                ((IDisposable)image).Dispose();
            }
        }

        #region Eventi form

        private void btnSnap_Click(object sender, EventArgs e)
        {
            try
            {
                this.appManager?.Snap();
                EseguiStep();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnUltimaFoto_Click(object sender, EventArgs e)
        {
            EseguiStep();
        }

        #endregion Eventi form

    }
}