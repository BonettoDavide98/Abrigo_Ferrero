using Cognex.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QVLEGSCOG2362.Class
{
    public abstract class CoreBase
    {

        #region delegati

        public delegate void OnExecuteDelegate(ICogImage image, out Utilities.ObjectToDisplay objectTodisplay, out DataType.ElaborateResult result);
        private OnExecuteDelegate OnExecute;

        public delegate void OnNewImageToDisplayDelegate(int numCamera, Utilities.ObjectToDisplay iconicVar, DataType.ElaborateResult result);
        protected OnNewImageToDisplayDelegate OnNewImageToDisplay;


        public delegate void OnPreNewImageDelegate(int numCamera);
        protected OnPreNewImageDelegate OnPreNewImage;


        //public delegate void OnFineElaborazioneDelegate(DataType.ElaborateResult result);
        //public event OnFineElaborazioneDelegate OnFineElaborazione;

        //public delegate void OnNewErrorDelegate(ArrayList iconicVar, DataType.ElaborateResult result);
        //protected OnNewErrorDelegate OnNewError;

        #endregion

        #region Variabili Private

        protected int numCamera = -1;
        protected int idCamera = -1;
        public int IdStazione { get; set; } = -1;

        protected readonly object onNewImageLock = new object();
        protected readonly object executeAlgorithmLock = new object();
        protected readonly object newImageEventLock = new object();
        protected readonly object fineElaborazioneEventLock = new object();
        protected readonly object newErrorEventLock = new object();
        protected readonly object preNewImageEventLock = new object();

        //private List<Utilities.CacheErrorObject> LastErrors = new List<Utilities.CacheErrorObject>();
        private readonly object lastErrorsLock = new object();

        protected int timeout = 0;

        private Task task = null;

        private string description;

        protected DataType.Impostazioni config = null;
        protected DataType.ImpostazioniCamera impCam = null;

        #endregion

        public bool IsRunning { get; protected set; }

        public CoreBase(int numCamera, int idCamera, int idStazione, DataType.Impostazioni config)
        {
            this.numCamera = numCamera;
            this.idCamera = idCamera;
            this.IdStazione = idStazione;
            this.IsRunning = false;
            this.config = config;

            switch (this.idCamera)
            {
                case 0: this.impCam = this.config.ImpostazioniCamera1; break;
                case 1: this.impCam = this.config.ImpostazioniCamera2; break;
                case 2: this.impCam = this.config.ImpostazioniCamera3; break;
                //case 3: this.impCam = this.config.ImpostazioniCamera4; break;
                //case 4: this.impCam = this.config.ImpostazioniCamera5; break;
                //case 5: this.impCam = this.config.ImpostazioniCamera6; break;
                default: break;
            }
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public void SetAlgorithm(OnExecuteDelegate del)
        {
            lock (executeAlgorithmLock)
            {
                OnExecute = del;
            }
        }

        protected void ElaborateImage(ICogImage hImage, out Utilities.ObjectToDisplay iconicVar, out DataType.ElaborateResult oResult)
        {
            OnExecuteDelegate del;

            Utilities.ObjectToDisplay retValue = null;
            DataType.ElaborateResult result = null;

            lock (executeAlgorithmLock)
            {
                del = OnExecute;
            }

            if (del != null)
            {
                del(hImage, out retValue, out result);
            }

            iconicVar = retValue;
            oResult = result;
        }

        #region FrameGrabber

        #endregion

        protected void DoPostNewImage(Utilities.ObjectToDisplay iconicVarList, DataType.ElaborateResult result, bool isLive)
        {
            Action action = () =>
            {
                try
                {
                    //RaiseFineElaborazioneEvent(result);

                    if (!isLive)
                    {
                        ManageErrorImage(iconicVarList, result);

                        SaveImageDiagnostics(iconicVarList, result);
                    }

                    RaiseNewImageToDisplayEvent(iconicVarList, result);
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
            };

            if (this.task == null)
                this.task = Task.Factory.StartNew(action);   //Task.Factory.StartNew(action, TaskCreationOptions.PreferFairness);
            else
                this.task = this.task.ContinueWith(k => action());
        }

        #region ErrorImage

        protected void ManageErrorImage(Utilities.ObjectToDisplay iconicVarList, DataType.ElaborateResult result)
        {
            try
            {
                if (this.config.ErroriSuDisco && result.Success == false && this.config.NumeroErroriSuDisco > 0 && this.cntErroriSalati < this.config.NumeroErroriSuDisco)
                {
                    lock (lastErrorsLock)
                    {
                        Utilities.CacheErrorObject ceo = new Utilities.CacheErrorObject(iconicVarList, result);

                        WriteErrorImageToDisk(ceo);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }
        }

        private void WriteErrorImageToDisk_OLD(Utilities.CacheErrorObject ceo)
        {
            DateTime d = DateTime.Now;

            string path = System.IO.Path.Combine(this.config.PathDatiBase, "ERRORI", (numCamera + 1).ToString());

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            string fileName = System.IO.Path.Combine(path, string.Format("{0}.tif", d.ToString("yyyyMMdd HH mm ss.fff")));

            if (ceo != null && ceo.IconicVar != null && ceo.IconicVar.GetImage() != null)
            {
                ceo.IconicVar.GetImage().ToBitmap().Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);

                /* cancello le immagini più vecchie oltre il numero di immagini da tenere*/
                string[] filesInError = System.IO.Directory.GetFiles(path);

                if (filesInError.Length > this.config.NumeroErroriSuDisco)
                {
                    filesInError = filesInError.OrderByDescending(k => k).Skip(this.config.NumeroErroriSuDisco).ToArray();
                    try
                    {
                        foreach (var file in filesInError)
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                    catch (Exception)
                    {
                        // Volutamente vuoto
                    }
                }
            }
        }

        private int cntErroriSalati = 0;

        private void WriteErrorImageToDisk(Utilities.CacheErrorObject ceo)
        {
            DateTime d = DateTime.Now;

            string path = System.IO.Path.Combine(this.config.PathErrori, d.ToString("yyyyMMdd"), (idCamera + 1).ToString());

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            string fileName = System.IO.Path.Combine(path, string.Format("{0}.tif", d.ToString("HH mm ss.fff")));

            if (ceo != null && ceo.IconicVar != null && ceo.IconicVar.GetImage() != null)
            {
                ceo.IconicVar.GetImage().ToBitmap().Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);

                this.cntErroriSalati++;
            }
        }

        //public List<Utilities.CacheErrorObject> GetLastErrorsClone()
        //{
        //    lock (lastErrorsLock)
        //    {
        //        return this.LastErrors.Select(k => new Utilities.CacheErrorObject(k.IconicVar, k.ElaborateResult, k.TimeStamp)).ToList();
        //    }
        //}

        #endregion

        #region Salva immagini

        private int cntSave = 0;
        private int maxSaveCnt = 0;
        private bool saveEnable = false;

        public void SetSaveEnable(bool en, int maxSaveCnt)
        {
            cntSave = 0;
            this.saveEnable = en;
            this.maxSaveCnt = maxSaveCnt;
        }

        protected void SaveImageDiagnostics(Utilities.ObjectToDisplay iconicVarList, DataType.ElaborateResult result)
        {
            try
            {
#if !_Simulazione
                if (this.saveEnable && cntSave < maxSaveCnt)
                {
                    Utilities.CacheErrorObject ceo2 = new Utilities.CacheErrorObject(iconicVarList, result);
                    Write_N_ToDisk(ceo2);

                    cntSave++;
                }
#endif
            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }
        }

        private void Write_N_ToDisk(Utilities.CacheErrorObject ceo)
        {
            DateTime d = DateTime.Now;

            string path = System.IO.Path.Combine(this.config.PathDatiBase, "IMG_SAVE", (numCamera + 1).ToString());

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            string fileName = System.IO.Path.Combine(path, string.Format("{0}.tif", d.ToString("yyyyMMdd HH mm ss.fff")));

            if (ceo != null && ceo.IconicVar != null && ceo.IconicVar.GetImage() != null)
            {
                ceo.IconicVar.GetImage().ToBitmap().Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
            }
        }

        #endregion Salva immagini

        #region Gestione Delegate

        protected void RaiseNewImageToDisplayEvent(Utilities.ObjectToDisplay iconicVarList, DataType.ElaborateResult result)
        {
            try
            {
                OnNewImageToDisplayDelegate del;

                lock (newImageEventLock)
                {
                    del = OnNewImageToDisplay;
                }

                if (del != null)
                {
                    del(this.numCamera, iconicVarList, result);
                }
                else
                {
                    if (iconicVarList != null)
                    {
                        iconicVarList.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }

        }

        public void SetNewImageToDisplayEvent(OnNewImageToDisplayDelegate del)
        {
            lock (newImageEventLock)
            {
                OnNewImageToDisplay = del;
            }
        }

        //protected void RaiseFineElaborazioneEvent(DataType.ElaborateResult result)
        //{
        //    try
        //    {
        //        OnFineElaborazioneDelegate del;

        //        lock (fineElaborazioneEventLock)
        //        {
        //            del = OnFineElaborazione;
        //        }

        //        if (del != null)
        //        {
        //            del(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionManager.AddException(ex);
        //    }
        //}

        //public void SetFineElaborazioneEvent(OnFineElaborazioneDelegate del)
        //{
        //    lock (fineElaborazioneEventLock)
        //    {
        //        OnFineElaborazione = del;
        //    }
        //}

        //protected void RaiseNewErrorEvent(ArrayList iconicVarList, DataType.ElaborateResult result)
        //{
        //    try
        //    {
        //        OnNewErrorDelegate del;

        //        lock (newErrorEventLock)
        //        {
        //            del = OnNewError;
        //        }

        //        if (del != null)
        //        {
        //            del(iconicVarList, result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionManager.AddException(ex);
        //    }
        //}

        //public void SetNewErrorEvent(OnNewErrorDelegate del)
        //{
        //    lock (newErrorEventLock)
        //    {
        //        OnNewError = del;
        //    }
        //}

        protected void RaisePreNewImageEvent()
        {
            try
            {
                OnPreNewImageDelegate del;

                lock (preNewImageEventLock)
                {
                    del = OnPreNewImage;
                }

                if (del != null)
                {
                    del(this.numCamera);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }

        }

        public void SetPreNewImageEvent(OnPreNewImageDelegate del)
        {
            lock (preNewImageEventLock)
            {
                OnPreNewImage = del;
            }
        }

        #endregion

        public abstract void Run();

        public abstract void StopAndWaitEnd(bool forceTrigger);

        public abstract void CloseFrameGrabber();

    }
}