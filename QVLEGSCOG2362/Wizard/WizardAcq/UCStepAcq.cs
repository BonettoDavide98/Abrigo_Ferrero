using Cognex.VisionPro;
using System;
using System.Collections;

namespace QVLEGSCOG2362.Wizard
{
    public partial class UCStepAcq : TSWizards.BaseExteriorStep
    {

        #region Variabili Private

        private readonly Class.AppManager appManager = null;
        private readonly Class.CoreRegolazioni core = null;
        private readonly Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private readonly object repaintLock = null;
        private readonly Utilities.CogWndCtrlManager hWndCtrlManager = null;

        private bool modifica = false;

        #endregion Variabili Private

        public UCStepAcq(Class.AppManager appManager, Class.CoreRegolazioni core, Algoritmi.AlgoritmoWizard algoritmoWizard, DataType.Impostazioni impostazioni, bool modifica, DBL.LinguaManager linguaManager, object repaintLock)
        {
            InitializeComponent();
            try
            {
                this.appManager = appManager;
                this.core = core;
                this.algoritmoWizard = algoritmoWizard;
                this.repaintLock = repaintLock;
                this.modifica = modifica;

                this.hWndCtrlManager = new Utilities.CogWndCtrlManager(panelContainer);

                Object2Form(this.algoritmoWizard.GetAlgoritmoParam());

                if (!modifica)
                {
                    try
                    {
                        nudExpo.Value = (decimal)this.core.GetFrameGrabberManager().GetExpo();
                        nudGain.Value = (decimal)this.core.GetFrameGrabberManager().GetGain();
                    }
                    catch (Exception) { }
                }

                AddChangeEvent();

                Description.Text = linguaManager.GetTranslation("LBL_STEP_ACQ");
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE_ACQ");

                btnSnap.Text = linguaManager.GetTranslation("BTN_SNAP");
                lblExpo.Text = linguaManager.GetTranslation("LBL_EXPO");
                lblGain.Text = linguaManager.GetTranslation("LBL_GAIN");

                propertyGrid1.Visible = Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore && impostazioni.AbilitaVistaAvanzata;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        protected override void OnShowStep(TSWizards.ShowStepEventArgs e)
        {
            this.core.SetAlgorithm(this.algoritmoWizard.NOPAlgorithm);
            this.core.SetNewImageToDisplayEvent(OnNewImage);

            this.core.Run();

            EseguiStepImgWizard();

            base.OnShowStep(e);
        }

        protected override void OnValidateStep(System.ComponentModel.CancelEventArgs e)
        {
            this.core.StopAndWaitEnd(true);

            if (!modifica)
            {
                ICogImage image = null;
                try
                {
                    image = this.core.GetLastGrabImage();
                    if (image != null)
                    {
                        this.algoritmoWizard.SetWizardImage(image);
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

            base.OnValidateStep(e);
        }

        private void Object2Form(DataType.ParametriAlgoritmo param)
        {
            nudExpo.Value = (decimal)param.Expo;
            nudGain.Value = (decimal)param.Gain;

            propertyGrid1.SelectedObject = param;
        }

        public void OnNewImage(int numCamera, Utilities.ObjectToDisplay iconicVarList, DataType.ElaborateResult result)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() => { OnNewImage(numCamera, iconicVarList, result); }));
                }
                else
                {
                    this.hWndCtrlManager.DisplaySetupOutputCamera(iconicVarList, null);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void AddChangeEvent()
        {
            nudExpo.ValueChanged += NudExpo_ValueChanged;
            nudGain.ValueChanged += NudGain_ValueChanged;
        }

        private void RemoveChangeEvent()
        {
            nudExpo.ValueChanged -= NudExpo_ValueChanged;
            nudGain.ValueChanged -= NudGain_ValueChanged;
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
                    this.algoritmoWizard.SetWizardImage(image);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                //image?.Dispose();
            }
        }

        #region Eventi form

        private void btnSnap_Click(object sender, EventArgs e)
        {
            try
            {
                this.appManager?.Snap();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void NudExpo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.ParametriAlgoritmo param = this.algoritmoWizard.GetAlgoritmoParam();
                param.Expo = (double)nudExpo.Value;

                this.core.GetFrameGrabberManager().SetExpo((double)nudExpo.Value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void NudGain_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataType.ParametriAlgoritmo param = this.algoritmoWizard.GetAlgoritmoParam();
                param.Gain = (double)nudGain.Value;

                this.core.GetFrameGrabberManager().SetGain((double)nudGain.Value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Eventi form

    }
}