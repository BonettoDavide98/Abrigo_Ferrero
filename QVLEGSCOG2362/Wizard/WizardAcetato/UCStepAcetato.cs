using Cognex.VisionPro;
using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Wizard
{
    public partial class UCStepAcetato : TSWizards.BaseExteriorStep
    {

        private const int ROI_TRAIN = 1;

        #region Variabili Private

        private readonly Class.AppManager appManager = null;
        private readonly int idCamera = -1;
        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly DataType.Impostazioni impostazioni = null;
        private readonly DBL.LinguaManager linguaManager = null;
        private readonly object repaintLock = null;
        private readonly Utilities.CogWndCtrlManager cogWndCtrlManager = null;

        private ICogImage lastTestImage = null;

        #endregion Variabili Private

        public UCStepAcetato(Class.AppManager appManager, int idCamera, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();
            try
            {
                this.appManager = appManager;
                this.idCamera = idCamera;
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.impostazioni = impostazioni;
                this.linguaManager = linguaManager;
                this.repaintLock = repaintLock;

                this.cogWndCtrlManager = new Utilities.CogWndCtrlManager(panelContainer, impostazioni);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                AddChangeEvent();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_Acetato");
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE_Acetato");
                btnTest.Text = linguaManager.GetTranslation("BTN_TEST");
                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                btnUltimaFoto.Text = linguaManager.GetTranslation("BTN_ULTIMA_FOTO");
                btnLog.Text = linguaManager.GetTranslation("BTN_LOG");

                lblDistanzaBordo.Text = linguaManager.GetTranslation("LBL_DISTANZA_BORDO");
                lblThreshold.Text = linguaManager.GetTranslation("LBL_THRESHOLD");
                lblAreaMinDifetto.Text = linguaManager.GetTranslation("LBL_AREA_MIN_DIFETTO");

                propertyGrid1.Visible = Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore && impostazioni.AbilitaVistaAvanzata;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnShowStep(TSWizards.ShowStepEventArgs e)
        {
            ICogImage image = null;
            try
            {
                image = this.algoritmoWizard.GetWizardImage();
                EseguiStep(image);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                ((IDisposable)image)?.Dispose();
            }
            base.OnShowStep(e);
        }

        protected override void OnValidateStep(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo paramAlg)
        {
            DataType.AcetatoParam param = paramAlg.AcetatoParam;
            nudDistanzaBordo.Value = (decimal)param.DistanzaBordo;
            nudThreshold.Value = (decimal)param.Threshold;
            nudAreaMinDifetto.Value = (decimal)param.AreaMinDifetto;

            propertyGrid1.SelectedObject = param;
        }

        private void AddChangeEvent()
        {
            nudDistanzaBordo.ValueChanged += nud_ValueChanged;
            nudThreshold.ValueChanged += nud_ValueChanged;
            nudAreaMinDifetto.ValueChanged += nud_ValueChanged;
        }

        private void RemoveChangeEvent()
        {
            nudDistanzaBordo.ValueChanged -= nud_ValueChanged;
            nudThreshold.ValueChanged -= nud_ValueChanged;
            nudAreaMinDifetto.ValueChanged -= nud_ValueChanged;
        }

        private void EseguiStep(ICogImage image)
        {
            if (image != null)
            {
                ((IDisposable)this.lastTestImage)?.Dispose();
                this.lastTestImage = image.CopyBase(CogImageCopyModeConstants.CopyPixels);

                Utilities.ObjectToDisplay otd = this.algoritmoWizard.TestWizardAcetato(image, out DataType.ElaborateResult res);
                this.cogWndCtrlManager.DisplaySetupOutputCamera(otd, res);
            }
        }

        #region Eventi form

        private void btnTest_Click(object sender, EventArgs e)
        {
            ICogImage image = null;
            try
            {
                if(this.lastTestImage != null)
                    image = this.lastTestImage.CopyBase(CogImageCopyModeConstants.CopyPixels);

                EseguiStep(image);

            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                ((IDisposable)image)?.Dispose();
            }
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            try
            {
                this.appManager?.Snap();
                btnUltimaFoto_Click(this, null);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnUltimaFoto_Click(object sender, EventArgs e)
        {
            ICogImage image = null;
            try
            {
                image = this.core.GetLastGrabImage();

                if (image != null)
                    EseguiStep(image);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                ((IDisposable)image)?.Dispose();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            ICogImage image = null;
            try
            {
                FormScegliImgLog f = new FormScegliImgLog(this.appManager, this.idCamera, this.impostazioni, this.linguaManager, this.repaintLock);
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    image = f.GetImage();
                    EseguiStep(image);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                ((IDisposable)image)?.Dispose();
            }
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.AcetatoParam param = this.algoritmoWizard.GetAlgoritmoParam().AcetatoParam;
                param.DistanzaBordo = (int)nudDistanzaBordo.Value;
                param.Threshold = (int)nudThreshold.Value;
                param.AreaMinDifetto = (int)nudAreaMinDifetto.Value;

                ICogImage image = null;
                try
                {
                    if(this.lastTestImage != null)
                        image = this.lastTestImage.CopyBase(CogImageCopyModeConstants.CopyPixels);
                    
                    EseguiStep(image);
                }
                catch (Exception ex)
                {
                    Class.ExceptionManager.AddException(ex);
                }
                finally
                {
                    ((IDisposable)image)?.Dispose();
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        #endregion Eventi form

    }
}