using Cognex.VisionPro;
using System;

namespace QVLEGSCOG2362.Algoritmi
{
    public class AlgoritmoWizard : Algoritmo, IDisposable
    {

        #region Variabili Private

        private bool disposed = false;

        private ICogImage imgWizard = null;

        #endregion Variabili Private

        public AlgoritmoWizard(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {
        }


        public void LoadFiles(string idFormato)
        {
        }

        public void SaveFiles(string idFormato)
        {
        }

        public void SetAlgoritmoParam(DataType.ParametriAlgoritmo param)
        {
            SetParametri(param);

            if (this.parametri != null)
            {
                this.parametri.Template = DataType.TemplateFormato.GetTemplateByName(param.TemplateName);
            }
        }

        public DataType.ParametriAlgoritmo GetAlgoritmoParam()
        {
            return this.parametri;
        }
        
        public void ResetWizardImage()
        {
            ((IDisposable)this.imgWizard)?.Dispose();
            this.imgWizard = null;
        }

        public void SetWizardImage(ICogImage image)
        {
            if (image != null)
            {
                this.imgWizard = image.CopyBase(CogImageCopyModeConstants.CopyPixels);
            }
                
            ((IDisposable)image)?.Dispose();
        }

        public ICogImage GetWizardImage()
        {
            if (this.imgWizard == null)
                return null;
            else
                return this.imgWizard.CopyBase(CogImageCopyModeConstants.CopyPixels);
        }


        public void SetRoiMain(int[] data)
        {
            //if (parametri.RoiMain == null)
            //    parametri.RoiMain = new DataType.Rectangle1Param();
            //parametri.RoiMain.Row1 = data[0];
            //parametri.RoiMain.Column1 = data[1];
            //parametri.RoiMain.Row2 = data[2];
            //parametri.RoiMain.Column2 = data[3];
        }

        public void SetImageRefMain(ICogImage image)
        {
            if(image != null)
            {
                this.parametri.ImageRef = image.CopyBase(CogImageCopyModeConstants.CopyPixels);
            }
                
            ((IDisposable)image)?.Dispose();
        }

        public void SetWizardAcqComplete()
        {
            this.parametri.WizardAcqCompleto = true;
        }


        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    base.DisposeBase();

                    ((IDisposable)this.imgWizard)?.Dispose();
                    this.imgWizard = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~AlgoritmoWizard()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}