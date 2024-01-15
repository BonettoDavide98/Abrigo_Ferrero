using Cognex.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QVLEGSCOG2362.Class
{
    public class AppManager
    {

#if _Simulazione
        private const bool loadImgFromFile = true;
#else
        private const bool loadImgFromFile = false;
#endif

        private int numCamere = -1;

        private readonly int idStazione = -1;
        private readonly ComunicazioneManager comunicazioneManager = null;
        private readonly Manager.SchedaIO schedaIO = null;
        private readonly DataType.Impostazioni impostazioni;

        private readonly Core[] core = null;
        private readonly Algoritmi.AlgoritmoLavoro[] algoritmi = null;

        private Action<Utilities.ObjectToDisplay[], DataType.ElaborateResult[]> actionForDisplay = null;

        private readonly GestioneContatori contatori = null;

        private CancellationTokenSource cancelToken;
        private Thread mainTask;

        private bool isLive = false;

        private DateTime lastImage = DateTime.MinValue;


        private AutoResetEvent[] autoResetEvents = null;
        private Utilities.ObjectToDisplay[] iconicVarListTmp = null;
        private DataType.ElaborateResult[] resultTmp = null;


        public List<int> CamereId { get; set; } = null;
        private Dictionary<int, int> cameraIdIdx = new Dictionary<int, int>();
        public List<DataType.TipoCamera> CamereTipo { get; set; } = new List<DataType.TipoCamera>();


        public AppManager(int idStazione, ComunicazioneManager comunicazioneManager, Manager.SchedaIO schedaIO, Dictionary<string, ICogFrameGrabber> camereSN, DBL.LinguaManager linguaManager)
        {
            //IMPOSTAZIONI
            this.impostazioni = DBL.ImpostazioniManager.ReadImpostazioni();

            this.idStazione = idStazione;

            this.comunicazioneManager = comunicazioneManager;
            this.schedaIO = schedaIO;

            this.CamereId = GetCamereIdByIdStazione(idStazione, this.impostazioni);

            for (int i = 0; i < this.CamereId.Count; i++)
                this.cameraIdIdx.Add(this.CamereId[i], i);

            this.numCamere = this.CamereId.Count;

            this.autoResetEvents = new AutoResetEvent[numCamere];
            this.iconicVarListTmp = new Utilities.ObjectToDisplay[numCamere];
            this.resultTmp = new DataType.ElaborateResult[numCamere];

            this.contatori = new GestioneContatori(numCamere);

            this.core = new Core[numCamere];
            this.algoritmi = new Algoritmi.AlgoritmoLavoro[numCamere];

            this.cntMaxCtrl = this.impostazioni.NumeroErrori;

            this.iconicVarListAll = new List<Utilities.ObjectToDisplay[]>();
            this.resultAll = new List<DataType.ElaborateResult[]>();
            this.dateTimeAll = new List<DateTime>();

            InitAutoResetEvent();

            DBL.GestioneTurniManager.GetDatiTurnoCorrente(out DateTime dataRiferimentoTurno, out int nomeTurno);

            for (int i = 0; i < numCamere; i++)
            {
                IFrameGrabberManager frameGrabber = GetFrameGrabberManager(this.CamereId[i], loadImgFromFile, camereSN, this.impostazioni);

                this.core[i] = new Core(i, this.CamereId[i], idStazione, this.comunicazioneManager, this.schedaIO, this.contatori, this.impostazioni);
                this.core[i].SetFrameGrabberManager(frameGrabber);

                this.algoritmi[i] = new Algoritmi.AlgoritmoLavoro(this.CamereId[i], idStazione, this.impostazioni, linguaManager);
                this.algoritmi[i].SetDatiTurno(dataRiferimentoTurno, nomeTurno);

                this.core[i].SetAlgorithm(this.algoritmi[i].AlgoritmoLavoroFunction);
                this.core[i].SetPreNewImageEvent(OnPreNewImage);
                this.core[i].SetNewImageToDisplayEvent(OnNewImage);
            }


            cancelToken = new CancellationTokenSource();
            cancelToken.Cancel();//Ho bisogno di allocarlo ma non voglio partire bloccato


            RunMainTask();
        }

        public void Run()
        {
            for (int i = 0; i < numCamere; i++)
            {
                this.core[i]?.Run();
            }
        }

        public void Stop()
        {
            for (int i = 0; i < numCamere; i++)
            {
                this.core[i]?.StopAndWaitEnd(true);
            }
        }



        public void StartLive()
        {
            isLive = true;
            for (int i = 0; i < numCamere; i++)
            {
                this.core[i]?.SetAlgorithm(this.algoritmi[i].NOPAlgorithm);
                this.core[i]?.SetLive(true);
                this.core[i]?.SetFreeRun();
                this.core[i]?.Run();
            }
        }

        public void StopLive()
        {
            for (int i = 0; i < numCamere; i++)
            {
                this.core[i]?.StopAndWaitEnd(true);
                this.core[i].SetAlgorithm(this.algoritmi[i].AlgoritmoLavoroFunction);
                this.core[i].SetLive(false);
                this.core[i]?.SetTriggerLine1();
            }
            isLive = false;
        }



        public void SetNewImageToDisplayEvent(Action<Utilities.ObjectToDisplay[], DataType.ElaborateResult[]> del)
        {
            this.actionForDisplay = del;
        }


        private DataType.FrameGrabberConfig GetFrameGrabberConfig_FromCamera(string device, int numCam, DataType.ImpostazioniCamera impCam)
        {
            DataType.FrameGrabberConfig cameraConfig = new DataType.FrameGrabberConfig();

            cameraConfig.Name = "SaperaLT";
            cameraConfig.Horizzontal_resolution = 1;
            cameraConfig.Vertical_resolution = 1;
            cameraConfig.ImageWidth = 0;
            cameraConfig.ImageHeight = 0;
            cameraConfig.StartRow = 0;
            cameraConfig.StartColumn = 0;
            cameraConfig.Field = "default";
            cameraConfig.BitsPerChannel = -1;
            cameraConfig.ColorSpace = "default";
            cameraConfig.Generic = -1;
            cameraConfig.ExternalTrigger = "false";

            string fileCCF = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "CCF", string.Format("CAM_{0}.ccf", numCam + 1));
            if (System.IO.File.Exists(fileCCF))
                cameraConfig.CameraType = fileCCF;
            else
                cameraConfig.CameraType = "";

            cameraConfig.Device = device;
            cameraConfig.Port = -1;
            cameraConfig.LineIn = -1;

            cameraConfig.ParamList.Add(new DataType.FrameGrabberParam("Height", impCam.Height.ToString()));
            cameraConfig.ParamList.Add(new DataType.FrameGrabberParam("Width", impCam.Width.ToString()));
            cameraConfig.ParamList.Add(new DataType.FrameGrabberParam("OffsetX", impCam.OffsetX.ToString()));
            cameraConfig.ParamList.Add(new DataType.FrameGrabberParam("OffsetY", impCam.OffsetY.ToString()));

            return cameraConfig;
        }

        private DataType.FrameGrabberConfig GetFrameGrabberConfig_FromFile(string imgPath)
        {
            DataType.FrameGrabberConfig cameraConfig = new DataType.FrameGrabberConfig();

            cameraConfig.Name = "File";
            cameraConfig.Horizzontal_resolution = 1;
            cameraConfig.Vertical_resolution = 1;
            cameraConfig.ImageWidth = 0;
            cameraConfig.ImageHeight = 0;
            cameraConfig.StartRow = 0;
            cameraConfig.StartColumn = 0;
            cameraConfig.Field = "default";
            cameraConfig.BitsPerChannel = -1;
            cameraConfig.ColorSpace = "default";
            cameraConfig.Generic = -1;
            cameraConfig.ExternalTrigger = "false";
            cameraConfig.CameraType = imgPath;
            cameraConfig.Device = "default";
            cameraConfig.Port = 1;
            cameraConfig.LineIn = -1;

            return cameraConfig;
        }

        private IFrameGrabberManager GetFrameGrabberManager(int idCamera, bool isFromFile, Dictionary<string, ICogFrameGrabber> camereSN, DataType.Impostazioni impostazioni)
        {
            IFrameGrabberManager ret = null;
            try
            {
                DataType.ImpostazioniCamera impCam = null;
                switch (idCamera)
                {
                    case 0: impCam = impostazioni.ImpostazioniCamera1; break;
                    case 1: impCam = impostazioni.ImpostazioniCamera2; break;
                    case 2: impCam = impostazioni.ImpostazioniCamera3; break;
                    //case 3: impCam = impostazioni.ImpostazioniCamera4; break;
                    //case 4: impCam = impostazioni.ImpostazioniCamera5; break;
                    //case 5: impCam = impostazioni.ImpostazioniCamera6; break;
                    default: break;
                }

                if (impCam != null)
                {
                    string ipCamera = null;

                    if (camereSN?.ContainsKey(impCam.IpCamera) == true)
                    {
                        ipCamera = camereSN[impCam.IpCamera].OwnedGigEAccess.CurrentIPAddress;
                    }
                    else
                        ipCamera = impCam.IpCamera;

                    this.CamereTipo.Add(impCam.TipoCamera);

                    if (isFromFile)
                    {
                        ret = new FrameGrabberFileManager(GetFrameGrabberConfig_FromFile(impCam.PathImmaginiDaCamera));
                    }
                    else
                    {
                        ret = new FrameGrabberCameraManager(GetFrameGrabberConfig_FromCamera(ipCamera, idCamera, impCam));
                    }

                    //ret = new FrameGrabberCameraManager(isFromFile ? GetFrameGrabberConfig_FromFile(impCam.PathImmaginiDaCamera) : GetFrameGrabberConfig_FromCamera(ipCamera, idCamera, impCam));
                }
            }
            catch (Exception) { }

            return ret;
        }


        public CoreRegolazioni GetCoreRegolazioni(int idCamera)
        {
            return new CoreRegolazioni(this.cameraIdIdx[idCamera], idCamera, this.idStazione, core[this.cameraIdIdx[idCamera]], this.impostazioni);
        }


        public GraficiSoglieManager GetGraficiSoglieManager(int idCamera)
        {
            return core[this.cameraIdIdx[idCamera]].GetGraficiSoglieManager();
        }

        public Algoritmi.AlgoritmoLavoro GetAlgoritmo(int idCamera)
        {
            return this.algoritmi[this.cameraIdIdx[idCamera]];
        }


        public void CaricaRicetta(string idFormato)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(idFormato))
                {
                    for (int i = 0; i < numCamere; i++)
                    {
                        try
                        {
                            this.algoritmi[i].SetCaricamentoParametri(true);

                            this.algoritmi[i].LoadFiles(idFormato);

                            DataType.ParametriAlgoritmo p = DBL.FormatoManager.ReadParametriAlgoritmo(idFormato, this.CamereId[i]);

                            this.algoritmi[i].SetAlgoritmoParam(p);
                            IFrameGrabberManager fgm = this.core[i].GetFrameGrabberManager();
                            if (fgm != null)
                            {
                                fgm.SetExpo(p.Expo);
                                fgm.SetGain(p.Gain);
                            }
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                        finally
                        {
                            this.algoritmi[i].SetCaricamentoParametri(false);
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CaricaRicettaFromEdit(int idCamera, DataType.ParametriAlgoritmo param)
        {
            try
            {
                this.algoritmi[idCamera].SetCaricamentoParametri(true);

                this.algoritmi[idCamera].SetAlgoritmoParam(param);
                IFrameGrabberManager fgm = this.core[idCamera].GetFrameGrabberManager();
                if (fgm != null)
                {
                    fgm.SetExpo(param.Expo);
                    fgm.SetGain(param.Gain);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.algoritmi[idCamera].SetCaricamentoParametri(false);
            }
        }



        public void GetContatori(out long foto, out long buoni, out long scarti)
        {
            this.contatori.GetContatori(out foto, out buoni, out scarti);
        }


        private void InitAutoResetEvent()
        {
            for (int i = 0; i < numCamere; i++)
            {
                autoResetEvents[i] = new AutoResetEvent(false);
            }
        }

        public void OnPreNewImage(int numCamera)
        {
            try
            {
                iconicVarListTmp[numCamera] = null;
                resultTmp[numCamera] = null;

                autoResetEvents[numCamera].Reset();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OnNewImage(int numCamera, Utilities.ObjectToDisplay iconicVarList, DataType.ElaborateResult result)
        {
            try
            {
                lastImage = DateTime.Now;

                iconicVarListTmp[numCamera] = iconicVarList;
                resultTmp[numCamera] = result;

                autoResetEvents[numCamera].Set();

                if (numCamera == 0)
                {
                    AutoResetEvent.WaitAll(autoResetEvents, 100, true);


                    //Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " -----------------------------------------INVIO");

                    Utilities.ObjectToDisplay[] iconicVarListToSend = new Utilities.ObjectToDisplay[numCamere];
                    DataType.ElaborateResult[] resultToSend = new DataType.ElaborateResult[numCamere];

                    for (int i = 0; i < numCamere; i++)
                    {
                        iconicVarListToSend[i] = iconicVarListTmp[i];
                        resultToSend[i] = resultTmp[i];

                        iconicVarListTmp[i] = null;
                        resultTmp[i] = null;
                    }

                    //this.contatori.GestioneStatistiche(resultToSend);

                    bool esito = true;
                    if (!(resultToSend.Count(k => k == null || k.Success == false) == 0))
                    {
                        esito = false;
                    }


                    if (resultToSend.Count(k => k == null) > 0)
                    {
                        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " SMINCHIATO");
                    }

                    if (!isLive)
                    {
                        if (esito == false)
                        {
                            NewError(iconicVarListToSend, resultToSend);
                        }

                        this.comunicazioneManager?.SetBitEsito(this.idStazione, esito);
                    }

                    if (actionForDisplay == null)
                    {
                        for (int i = 0; i < numCamere; i++)
                        {
                            iconicVarListTmp[i]?.Dispose();

                            iconicVarListTmp[i] = null;
                            resultTmp[i] = null;
                        }
                    }
                    else
                        this.actionForDisplay?.Invoke(iconicVarListToSend, resultToSend);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambioTurno()
        {
            DBL.GestioneTurniManager.GetDatiTurnoCorrente(out DateTime dataRiferimentoTurno, out int nomeTurno);

            for (int i = 0; i < numCamere; i++)
            {
                if (this.algoritmi[i] != null)
                    this.algoritmi[i].SetDatiTurno(dataRiferimentoTurno, nomeTurno);
            }
        }



        public void Snap()
        {
            if ((DateTime.Now - lastImage).TotalSeconds < 1)
            {
                return;
            }

            try
            {
                //metto in stop
                Stop();

                // INPOSTO I CORE AL CONTROLLO
                for (int i = 0; i < numCamere; i++)
                {
                    this.core[i]?.SetTriggerSoftware();
                }

                Run();

                try
                {
                    for (int i = 0; i < numCamere; i++)
                        this.core[i]?.DoTriggerSoftware();

                    Thread.Sleep(400);

                    //metto in stop
                    Stop();

                    //setto algoritmo normale
                    for (int i = 0; i < numCamere; i++)
                    {
                        this.core[i]?.SetTriggerLine1();
                    }
                    Run();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            catch (Exception) { }
        }

        public int[] GetNumeroTimeout()
        {
            int[] ret = null;

            //try
            //{
            //    Fins fins = null;
            //    try
            //    {
            //        fins = new Fins(idStazione == 0 ? this.impostazioni.PLC_1_IP : this.impostazioni.PLC_2_IP, 9600);

            //        int[] lettura = fins.Read<int[]>(3, 5000, 82, true);

            //        ret = lettura;
            //    }
            //    finally
            //    {
            //        fins?.Disconnect();
            //    }
            //}
            //catch (Exception)
            //{
            //    ret = new int[] { -1, -1, -1 };
            //}

            return ret;
        }

        public void Close()
        {
            this.comunicazioneManager?.Close();

            StopMainTaskAndWaitEnd();
        }



        private bool saveEnable = false;

        public void SetSaveEnable(bool en, int maxSaveCnt)
        {
            saveEnable = en;
            for (int i = 0; i < numCamere; i++)
            {
                this.core[i]?.SetSaveEnable(en, maxSaveCnt);
            }
        }

        public bool GetSaveEnable()
        {
            return saveEnable;
        }


        //private bool[] bitEsito = new bool[100];
        //private int idx = 0;

        //private void IniBitEsito()
        //{
        //    for (int i = 0; i < bitEsito.Length; i++)
        //    {
        //        bitEsito[i] = true;
        //    }
        //}

        //private void SetBitEsito(bool esito)
        //{
        //    bitEsito[idx] = esito;

        //    idx++;
        //    if (idx >= bitEsito.Length)
        //        idx = 0;
        //}


        //private double GetPercentualeScatoBitEsito()
        //{
        //    int cntBad = bitEsito.Count(k => !k);

        //    return (double)cntBad / (double)bitEsito.Length * 100.0;
        //}






        private object objLockError = new object();

        private int cntMaxCtrl = 0;

        private List<Utilities.ObjectToDisplay[]> iconicVarListAll = null;
        private List<DataType.ElaborateResult[]> resultAll = null;
        private List<DateTime> dateTimeAll = null;

        private void NewError(Utilities.ObjectToDisplay[] iconicVarList, DataType.ElaborateResult[] result)
        {
            try
            {
                if (cntMaxCtrl == 0)
                    return;

                //TODO : Implement properly
                if (iconicVarList == null || iconicVarList.Count() < 1)
                    return;

                Utilities.ObjectToDisplay[] iconicVarListClone = iconicVarList.Select(k => k.Clone()).ToArray();
                this.iconicVarListAll.Add(iconicVarListClone);
                this.resultAll.Add(result);
                this.dateTimeAll.Add(DateTime.Now);

                if (iconicVarListAll.Count > cntMaxCtrl)
                {
                    Utilities.ObjectToDisplay[] tmp = iconicVarListAll[0];

                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] != null)
                            Utilities.CommonUtility.ClearArrayList(tmp[i]);
                    }

                    iconicVarListAll.RemoveAt(0);
                }

                if (resultAll.Count > cntMaxCtrl)
                {
                    resultAll.RemoveAt(0);
                }

                if (dateTimeAll.Count > cntMaxCtrl)
                {
                    dateTimeAll.RemoveAt(0);
                }
            }
            catch (Exception) { }
        }

        public void GetLastError(out List<Utilities.ObjectToDisplay[]> iconicVarError, out List<DataType.ElaborateResult[]> resultError, out List<DateTime> dateTimeError)
        {
            iconicVarError = new List<Utilities.ObjectToDisplay[]>();
            resultError = new List<DataType.ElaborateResult[]>();
            dateTimeError = new List<DateTime>();
            
            try
            {
                lock (objLockError)
                {
                    for (int i = 0; i < this.cntMaxCtrl; i++)
                    {
                        if (iconicVarListAll.Count > i && resultAll.Count > i)
                        {
                            iconicVarError.Add(iconicVarListAll[i].Select(k => k.Clone()).ToArray());
                            resultError.Add(resultAll[i]);
                            dateTimeError.Add(dateTimeAll[i]);
                        }

                    }
                }
            }
            catch (Exception) { }
        }

        public void GetLastError(int idCamera, out List<Utilities.ObjectToDisplay> iconicVarError, out List<DataType.ElaborateResult> resultError, out List<DateTime> dateTimeError)
        {
            iconicVarError = new List<Utilities.ObjectToDisplay>();
            resultError = new List<DataType.ElaborateResult>();
            dateTimeError = new List<DateTime>();
            
            try
            {
                lock (objLockError)
                {
                    for (int i = 0; i < this.cntMaxCtrl; i++)
                    {
                        if (iconicVarListAll.Count > i && resultAll.Count > i)
                        {
                            iconicVarError.Add(iconicVarListAll[i][this.cameraIdIdx[idCamera]].Clone());
                            resultError.Add(resultAll[i][this.cameraIdIdx[idCamera]]);
                            dateTimeError.Add(dateTimeAll[i]);
                        }

                    }
                }
            }
            catch (Exception) { }
        }


        public void RunMainTask()
        {
            try
            {
                if (mainTask != null && mainTask.IsAlive == true)
                    return;//test se già in run

                cancelToken = new CancellationTokenSource();

                mainTask = new Thread(new ThreadStart(RunFoo));
                mainTask.Priority = ThreadPriority.Normal;
                mainTask.Start();
            }
            catch (Exception ex)
            {
                ExceptionManager.AddException(ex);
            }
        }

        public void StopMainTaskAndWaitEnd()
        {
            try
            {
                if (mainTask != null && mainTask.IsAlive == true)
                {
                    cancelToken.Cancel();

                    mainTask.Join();
                }
            }
            catch (Exception) { }
        }

        private void RunFoo()
        {
            try
            {
                while (!cancelToken.Token.IsCancellationRequested)
                {
                    try
                    {
                        this.contatori.TryGestioneStatistiche();
                    }
                    catch (Exception ex)
                    {
                        if (!cancelToken.Token.IsCancellationRequested)
                        {
                            ExceptionManager.AddException(ex);
                        }
                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                if (!cancelToken.Token.IsCancellationRequested)
                {
                    ExceptionManager.AddException(ex);
                }
            }
        }






















        private List<int> GetCamereIdByIdStazione(int idStazione, DataType.Impostazioni impostazioni)
        {
            List<int> ret = new List<int>();

            if (impostazioni.ImpostazioniCamera1.Attiva)
                if (impostazioni.ImpostazioniCamera1.IdStazione == idStazione)
                    ret.Add(0);

            if (impostazioni.ImpostazioniCamera2.Attiva)
                if (impostazioni.ImpostazioniCamera2.IdStazione == idStazione)
                    ret.Add(1);

            if (impostazioni.ImpostazioniCamera3.Attiva)
                if (impostazioni.ImpostazioniCamera3.IdStazione == idStazione)
                    ret.Add(2);

            //if (impostazioni.ImpostazioniCamera4.Attiva)
            //    if (impostazioni.ImpostazioniCamera4.IdStazione == idStazione)
            //        ret.Add(3);

            //if (impostazioni.ImpostazioniCamera5.Attiva)
            //    if (impostazioni.ImpostazioniCamera5.IdStazione == idStazione)
            //        ret.Add(4);

            //if (impostazioni.ImpostazioniCamera6.Attiva)
            //    if (impostazioni.ImpostazioniCamera6.IdStazione == idStazione)
            //        ret.Add(5);

            return ret;
        }

        public int GetNumCamere()
        {
            return this.numCamere;
        }

        public int GetIdStazione()
        {
            return this.idStazione;
        }

    }
}
