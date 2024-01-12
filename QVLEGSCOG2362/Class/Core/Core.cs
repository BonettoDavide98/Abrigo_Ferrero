using Cognex.VisionPro;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace QVLEGSCOG2362.Class
{
    public class Core : CoreBase
    {

        private const int DURATA_MINIMA_BUSY = 10;

        #region delegati

        public delegate void OnNewImageForRegolazioniDelegate(ICogImage image);
        private OnNewImageForRegolazioniDelegate OnNewImageForRegolazioni;

        #endregion

        #region Variabili Private

        private ComunicazioneManager comunicazioneManager = null;
        private Manager.SchedaIO schedaIO = null;
        private GestioneContatori contatori = null;

        private IFrameGrabberManager frameGrabberForThisObject = null;

        private CancellationTokenSource cancelToken;
        private Thread mainTask;

        private bool taskRunning = false;

        private object objLock = new object();

        private Task taskCoreOnNewImageForRegolazioni = null;

        private bool inRegolazione = false;

        private DataType.TipoAlgoritmo tipoAlgoritmo = DataType.TipoAlgoritmo.Normale;

        private GraficiSoglieManager graficiSoglieManager = new GraficiSoglieManager();

        private bool isLive = false;

        #endregion

        public Core(int numCamera, int idCamera, int idStazione, ComunicazioneManager comunicazioneManager, Manager.SchedaIO schedaIO, GestioneContatori contatori, DataType.Impostazioni config) : base(numCamera, idCamera, idStazione, config)
        {
            try
            {
                this.comunicazioneManager = comunicazioneManager;
                this.schedaIO = schedaIO;
                this.contatori = contatori;
            }
            catch (Exception)
            {
                throw;
            }
            cancelToken = new CancellationTokenSource();
            cancelToken.Cancel();//Ho bisogno di allocarlo ma non voglio partire bloccato
        }

        public void SetFrameGrabberManager(IFrameGrabberManager frameGrab)
        {
            this.frameGrabberForThisObject = frameGrab;

            if (base.numCamera == 0)
                SetOutput(true, false, false);
        }

        public IFrameGrabberManager GetFrameGrabberManager()
        {
            return this.frameGrabberForThisObject;
        }

        private void CoreOnNewImage(ICogImage hImage, long tPreElab)
        {
            if (base.numCamera == 0)
            {
                //SET BUSY OFF
                SetOutput(false, false, false);
            }

            RaisePreNewImageEvent();

            lock (onNewImageLock)
            {
                Stopwatch sw = Stopwatch.StartNew();

                Utilities.ObjectToDisplay iconicVarList = null;
                DataType.ElaborateResult result = null;
                ElaborateImage(hImage, out iconicVarList, out result);

                sw.Stop();
                double tAnalisi = sw.ElapsedMilliseconds + tPreElab;
                if (tAnalisi < DURATA_MINIMA_BUSY)
                    Thread.Sleep((int)(DURATA_MINIMA_BUSY - tAnalisi));

                if (!isLive)
                {
                    //CONTATORI
                    if (tipoAlgoritmo == DataType.TipoAlgoritmo.Normale)
                        RaiseContatori(result);

                    //COMUNICO IL RISULTATO DENTRO RaiseContatori
                    ////SET RISULTATO
                    //SetOutput(true, result == null ? false : result.Success);
                }

                result.ElapsedTime = tAnalisi;

                DoPostNewImage(iconicVarList, result, this.isLive);
                //Utilities.CommonUtility.ClearArrayList(iconicVarList);
                if (!isLive)
                {
                    if (tipoAlgoritmo == DataType.TipoAlgoritmo.Normale)
                        graficiSoglieManager.AddData(result.StatisticheObj.Misure);
                }
            }
        }

        private void CoreOnNewImageForRegolazioni(ICogImage image)
        {
            Action action = () =>
            {
                try
                {
                    OnNewImageForRegolazioniDelegate del = OnNewImageForRegolazioni;
                    if (del != null)
                    {
                        del(image);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.AddException(ex);
                }
            };

            if (this.taskCoreOnNewImageForRegolazioni == null)
                this.taskCoreOnNewImageForRegolazioni = Task.Run(action);   //Task.Factory.StartNew(action, TaskCreationOptions.PreferFairness);
            else
                this.taskCoreOnNewImageForRegolazioni = this.taskCoreOnNewImageForRegolazioni.ContinueWith(k => action());
        }

        public override void Run()
        {
            try
            {
                if (frameGrabberForThisObject == null)
                    return;

                if (taskRunning)
                    return;//test se già in run

                if (mainTask != null && mainTask.IsAlive == true)
                    return;//test se già in run

                cancelToken = new CancellationTokenSource();

                frameGrabberForThisObject.GrabImageStart();

                mainTask = new Thread(new ThreadStart(RunFoo));
                mainTask.Priority = ThreadPriority.AboveNormal;
                mainTask.Start();

                if (base.numCamera == 0)
                    SetOutput(true, false, false);

                this.IsRunning = true;

            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }
        }

        public override void StopAndWaitEnd(bool forceTrigger)
        {
            try
            {
                if (frameGrabberForThisObject == null)
                    return;

                if (this.IsRunning)
                {
                    if (forceTrigger)
                    {
                        frameGrabberForThisObject.ForceTrigger();
                    }

                    cancelToken.Cancel();

                    mainTask.Join();

                    if (base.numCamera == 0)
                        SetOutput(false, false, false);

                    this.IsRunning = false;
                }
            }
            catch (Exception) { }
        }

        public override void CloseFrameGrabber()
        {
            if (frameGrabberForThisObject != null)
            {
                if (frameGrabberForThisObject != null)
                    frameGrabberForThisObject.Dispose();
            }
        }

        public void SetOnNewImageForRegolazioni(OnNewImageForRegolazioniDelegate del)
        {
            lock (executeAlgorithmLock)
            {
                OnNewImageForRegolazioni = del;
                inRegolazione = del != null;
            }
        }

        private void RunFoo()
        {
            try
            {
                taskRunning = true;

                while (!cancelToken.Token.IsCancellationRequested)
                {
                    try
                    {
                        ICogImage imgGrabTmp = AcquisitionTask(out long tPreElab);

                        if (imgGrabTmp != null && imgGrabTmp.Allocated)
                        {
                            if (this.comunicazioneManager.IsEnable)
                            {
                                //DateTime dtTemp = DateTime.Now;
                                //double delta = (dtTemp - dtLast).TotalMilliseconds;
                                //if (delta > 50)
                                //{
                                //    Debug.WriteLine(delta);
                                //}
                                //dtLast = dtTemp;

                                //Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " CAMERA " + numCamera);

                                //TODO VEDERE QUESTE CLONE
                                //CoreOnNewImage(imgGrabTmp);

                                //ICogImage imageRotate = null;
                                //if (impCam.CorrezioneAngolo != 0)
                                //    imageRotate = imgGrabTmp.RotateImage(impCam.CorrezioneAngolo, "constant");
                                //else
                                //    imageRotate = imgGrabTmp;

                                //CoreOnNewImage(imageRotate.CopyImage(), tPreElab);
                                //OLD
                                //CoreOnNewImage(imgGrabTmp, tPreElab);
                                CoreOnNewImage(imgGrabTmp.CopyBase(CogImageCopyModeConstants.CopyPixels), tPreElab);

                                if (inRegolazione)
                                {
                                    //CoreOnNewImageForRegolazioni(imgGrabTmp);
                                    CoreOnNewImageForRegolazioni(imgGrabTmp.CopyBase(CogImageCopyModeConstants.CopyPixels));
                                }

                                //imgGrabTmp?.Dispose();
                                //if (impCam.CorrezioneAngolo != 0)
                                //    imageRotate?.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!cancelToken.Token.IsCancellationRequested)
                        {
                            ExceptionManager.AddException(ex);
                        }
                    }
                    finally
                    {
                        //GC.Collect();
                    }
#if _Simulazione
                    Thread.Sleep(400);
#endif
                    if (isLive)
                    {
                        Thread.Sleep(200);
                    }

                }

                taskRunning = false;
            }
            catch (Exception ex)
            {
                if (!cancelToken.Token.IsCancellationRequested)
                {
                    ExceptionManager.AddException(ex);
                }
            }
        }

        private ICogImage AcquisitionTask(out long tPreElab)
        {
            ICogImage imgGrabTmp = null;
            tPreElab = 0;
            try
            {
                imgGrabTmp = frameGrabberForThisObject.GrabASyncNoDelegate(out tPreElab);
            }
            catch (Exception ex)
            {
                //if (!(ex.GetErrorNumber() == 5322 || ex.GetErrorNumber() == 5306))
                //{
                //    //Non deve dare errori nel momento in cui ho appena dato ABORT all'acquisizione 
                //    if (!cancelToken.Token.IsCancellationRequested)
                //        ExceptionManager.AddException(ex);
                //}
                throw new Exception();
            }
            return imgGrabTmp;
        }



        private void SetOutput(bool ready, bool result, bool result2)
        {
            try
            {
#if !_Simulazione
                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                {
                    schedaIO.SetOutput(this.IdStazione, ready, result2, result);
                }
                else if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.Camera)
                {
                    if (this.frameGrabberForThisObject != null)
                    {
                        //SET RISULTATO
                        this.frameGrabberForThisObject.SetOutput("Line3", result);
                        //SET BUSY
                        this.frameGrabberForThisObject.SetOutput("Line4", ready);
                    }
                }
#endif
            }
            catch (Exception) { }
        }



        //private Task taskRaiseContatori = null;

        private void RaiseContatori(DataType.ElaborateResult result)
        {
            //Action action = () =>
            //{
            try
            {
                contatori.SetCam(base.numCamera, result);

                //GESTIONE CONTATORI
                if (base.numCamera == 0)
                {
                    //la camera 0 è qulla che dà il risultato
                    //aspetto tutte le camere
                    contatori.WaitAllCam();

                    //guardo se le altre sono buone, incremento contatori
                    bool ok = contatori.ControlloRisultati(out bool ok2);
                    //ok = true;
                    //SET RISULTATO
                    SetOutput(true, ok, ok2);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }
            //};

            //if (this.taskRaiseContatori == null)
            //    this.taskRaiseContatori = Task.Run(action);
            //else
            //    this.taskRaiseContatori = this.taskRaiseContatori.ContinueWith(k => action());
        }


        public void DoTriggerSoftware()
        {
            this.frameGrabberForThisObject?.TriggerSoftware();
        }

        public void SetTriggerSoftware()
        {
            this.frameGrabberForThisObject?.SetTrigger(true, true);
        }

        public void SetTriggerLine1()
        {
            this.frameGrabberForThisObject?.SetTrigger(true, false);
        }

        public void SetFreeRun()
        {
            this.frameGrabberForThisObject?.SetTrigger(false, false);
        }

        public void SetLive(bool live)
        {
            this.isLive = live;
        }


        public void SetTipoAlgoritmo(DataType.TipoAlgoritmo tipoAlgoritmo)
        {
            this.tipoAlgoritmo = tipoAlgoritmo;
        }

        public GraficiSoglieManager GetGraficiSoglieManager()
        {
            return this.graficiSoglieManager;
        }

    }
}