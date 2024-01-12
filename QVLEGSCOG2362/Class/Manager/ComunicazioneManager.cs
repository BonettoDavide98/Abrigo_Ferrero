using ClientEEIP.ClassiMie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;

namespace QVLEGSCOG2362.Class
{
    public class ComunicazioneManager
    {

        public bool ErrorePercentualeScarto = false;


        public bool IsEnable { get; set; } = true;





        private DataType.Impostazioni impostazioni = null;
        private ClientEEIP.ClientEEIPManager ClientEEIPManager = null;

        private Manager.SchedaIO schedaIO = null;
        private EasyModbus.ModbusClient modbusClient = null;
        //Coil 	            Read-write 	1 bit
        //Discrete input 	Read-only 	1 bit
        //Input register 	Read-only 	16 bits
        //Holding register 	Read-write 	16 bits

        private CancellationTokenSource cancelToken = null;
        private Thread mainTask = null;

        public bool EEIPOnline { get; private set; } = false;

        public MyStructScriviPlcOmron structScriviPlcOmron = null;
        public MyStructLeggiPlcOmron structLeggiPlcOmron = null;

        #region VARIABILI APPOGGIO
        private MyTimer timerSirena = null;

        private DateTime tsLastUpdateScarti = DateTime.MinValue;
        private MyTimer timerTriggerScarti = null;

        private bool watchDog = false;
        private Stopwatch swWatchDog = Stopwatch.StartNew();

        #endregion

        public ComunicazioneManager(Manager.SchedaIO schedaIO, DataType.Impostazioni impostazioni)
        {
            this.schedaIO = schedaIO;
            this.impostazioni = impostazioni;

            IniBitEsito();

            if (impostazioni.TipologiaDispositivoScarto == DataType.Impostazioni.DispositiviScarto.Omron)
            {
                this.structScriviPlcOmron = new MyStructScriviPlcOmron();
                this.structLeggiPlcOmron = new MyStructLeggiPlcOmron();

                this.ClientEEIPManager = new ClientEEIP.ClientEEIPManager(EEIPManagerAction);
                this.ClientEEIPManager.Start(IPAddress.Parse("0.0.0.0"));
            }

            if (impostazioni.TipologiaLogin == DataType.Impostazioni.TipoLogin.Modbus)
            {
                modbusClient = new EasyModbus.ModbusClient();
                //modbusServer.HoldingRegistersChanged += new EasyModbus.ModbusServer.HoldingRegistersChangedHandler(holdingRegistersChanged);
                //modbusServer.CoilsChanged += new EasyModbus.ModbusServer.CoilsChangedHandler(coilsChanged);

            }

            this.cancelToken = new CancellationTokenSource();

            this.mainTask = new Thread(new ThreadStart(PollingFoo));
            this.mainTask.Priority = ThreadPriority.Highest;
            this.mainTask.Start();
        }

        public void ResetAllarmi()
        {
            IniBitEsito();
            ErrorePercentualeScarto = false;
        }

        private void PollingFoo()
        {
            timerSirena = new MyTimer(1000 * impostazioni.TimeoutSirena);
            timerTriggerScarti = new MyTimer(1000);

            while (!cancelToken.Token.IsCancellationRequested)
            {
                try
                {
                    if (this.impostazioni.TipologiaDispositivoScarto == DataType.Impostazioni.DispositiviScarto.Omron)
                        PollingFooPlcOmron();

                    if (this.impostazioni.TipologiaLogin == DataType.Impostazioni.TipoLogin.Modbus)
                        PollingFooScambioUtente();

                    if (this.impostazioni.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                    {
                        double percScarto = GetPercentualeScatoBitEsito();

                        if (!ErrorePercentualeScarto)
                        {
                            if (percScarto > impostazioni.MaxPercentualeScarto)
                            {
                                ErrorePercentualeScarto = true;
                                timerSirena.Start();
                            }
                        }

                        bool giallo = false;
                        //bool rosso = ErrorePercentualeScarto;
                        bool rosso = !schedaIO.GetSoffioEnable();
                        bool sirena = timerSirena.Active;
                        bool verde = !rosso;

                        SetTorretta(verde, rosso, giallo, sirena);

                        //this.IsEnable = schedaIO.GetEnable();

                        //if (swWatchDog.ElapsedMilliseconds > 500)
                        //{
                        //    watchDog = !watchDog;
                        //    swWatchDog.Restart();

                        //    schedaIO.SetLifeBit(watchDog);
                        //}
                    }
                }
                catch (Exception ex)
                {
                    if (!cancelToken.Token.IsCancellationRequested)
                    {
                        //ExceptionManager.AddException(ex);
                    }
                }
                finally
                {
                    Thread.Sleep(10);
                }
            }
        }

        private void PollingFooPlcOmron()
        {
            if (structLeggiPlcOmron.CmdLoadDataOK == true)
            {
                structScriviPlcOmron.CmdLoadData = false;
            }

            if (structLeggiPlcOmron.CmdResetOK == true)
            {
                structScriviPlcOmron.CmdReset = false;
            }

            if (swWatchDog.ElapsedMilliseconds > 500)
            {
                watchDog = !watchDog;
                swWatchDog.Restart();
            }
            structScriviPlcOmron.LifeBit = watchDog;
        }

        private void PollingFooScambioUtente()
        {
            try
            {
                if (!modbusClient.Connected)
                {
                    modbusClient.Connect("172.20.32.41", 502);
                }

                int idxCodUtente = 0;

                int idxNumScartiD = 10;
                int idxTriggerScartiD = 10;
                int idxWatchDogD = 11;

                int idxNumScartiS = 0;
                int idxTriggerScartiS = 0;
                int idxWatchDogS = 1;

                int[] letture = modbusClient.ReadInputRegisters(0, 10);

                int liv = letture[idxCodUtente];

                DataType.Livello.LivelloUtente livelloFromModbus = DataType.Livello.LivelloUtente.NotLogged;

                if (liv == 1)
                {
                    livelloFromModbus = DataType.Livello.LivelloUtente.Operatore;
                }
                else if (liv == 2)
                {
                    livelloFromModbus = DataType.Livello.LivelloUtente.Tecnico;
                }
                if (liv == 3)
                {
                    livelloFromModbus = DataType.Livello.LivelloUtente.Amministratore;
                }

                if (LoginLogoutManager.GetUserLoggedStato() != livelloFromModbus)
                {
                    LoginLogoutManager.Login(new DataType.Utente() { LivelloUtente = livelloFromModbus }, int.MaxValue);
                }

                if (DateTime.Now.Subtract(tsLastUpdateScarti).TotalMilliseconds > 5000)
                {
                    tsLastUpdateScarti = DateTime.Now;
                    modbusClient.WriteSingleRegister(idxNumScartiD, cntScartiD);
                    modbusClient.WriteSingleRegister(idxNumScartiS, cntScartiS);
                    cntScartiD = 0;
                    cntScartiS = 0;
                    timerTriggerScarti.Start();
                }
                modbusClient.WriteSingleCoil(idxTriggerScartiD, timerTriggerScarti.Active);
                modbusClient.WriteSingleCoil(idxTriggerScartiS, timerTriggerScarti.Active);

                if (swWatchDog.ElapsedMilliseconds > 500)
                {
                    watchDog = !watchDog;
                    swWatchDog.Restart();
                }
                modbusClient.WriteSingleCoil(idxWatchDogD, watchDog);
                modbusClient.WriteSingleCoil(idxWatchDogS, watchDog);
            }
            catch (Exception) { }
        }

        private void EEIPManagerAction(byte[] arrayLettura, byte[] arrayScrittura, bool onLine)
        {
            if (impostazioni.TipologiaDispositivoScarto == DataType.Impostazioni.DispositiviScarto.Omron)
                EEIPManagerActionPlcOmron(arrayLettura, arrayScrittura, onLine);
        }

        private void EEIPManagerActionPlcOmron(byte[] arrayLettura, byte[] arrayScrittura, bool onLine)
        {
            this.EEIPOnline = onLine;

            if (onLine)
            {
                try
                {
                    int offset = 0;

                    structLeggiPlcOmron.Bits_Byte0 = UtilityClass.Leggi<bool[]>(arrayLettura, ref offset);
                    //structLeggi.Bits_Byte0 = UtilityClass.Leggi<bool[]>(arrayLettura, ref offset);
                    //structLeggi.Bits_Byte1 = UtilityClass.Leggi<bool[]>(arrayLettura, ref offset);
                    //structLeggi.Bits_Byte2 = UtilityClass.Leggi<bool[]>(arrayLettura, ref offset);
                    //structLeggi.ConfocaleMisura = UtilityClass.Leggi<int>(arrayLettura, ref offset);
                    //structLeggi.SensoreTop = UtilityClass.Leggi<int>(arrayLettura, ref offset);
                    //structLeggi.SensoreDx = UtilityClass.Leggi<int>(arrayLettura, ref offset);
                    //structLeggi.SensoreSx = UtilityClass.Leggi<int>(arrayLettura, ref offset);
                    //structLeggi.Bits_Byte13 = UtilityClass.Leggi<bool[]>(arrayLettura, ref offset);
                    //structLeggi.Motore60Position = UtilityClass.Leggi<float>(arrayLettura, ref offset);
                    //structLeggi.Motore70Position = UtilityClass.Leggi<float>(arrayLettura, ref offset);
                    //structLeggi.Motore80Position = UtilityClass.Leggi<float>(arrayLettura, ref offset);
                    //structLeggi.Bits_Byte32 = UtilityClass.Leggi<bool[]>(arrayLettura, ref offset);
                }
                catch (Exception ex)
                {
                    //ExceptionHandler.HandleException(ex);
                }

                try
                {
                    int offset = 0;

                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.Bits_Byte0);
                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.Bits_Byte1);
                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.DeltaFtcFoto);
                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.DeltaFtcResult);
                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.DeltaFtcSoffio);
                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.TempoSoffio);
                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.FiltroIngresso);
                    offset += UtilityClass.Scrivi(ref arrayScrittura, offset, structScriviPlcOmron.Bits_Byte22);
                }
                catch (Exception ex)
                {
                    //ExceptionHandler.HandleException(ex);
                }
            }
        }






        public void SetTorretta(bool verde, bool rosso, bool giallo, bool sirena)
        {
            try
            {
#if !_Simulazione
                Fins fins1 = null;
                Fins fins2 = null;
                try
                {
                    fins1 = new Fins(this.impostazioni.PLC_2_IP, 9600);
                    List<int> valoriWriteDWord1 = new List<int>();
                    valoriWriteDWord1.Add(verde ? 1 : 0);
                    valoriWriteDWord1.Add(giallo ? 1 : 0);
                    valoriWriteDWord1.Add(rosso ? 1 : 0);
                    fins1.Write(valoriWriteDWord1, valoriWriteDWord1.Count, 50, 82, false);


                    fins2 = new Fins(this.impostazioni.PLC_1_IP, 9600);
                    List<int> valoriWriteDWord2 = new List<int>();
                    valoriWriteDWord2.Add(sirena ? 1 : 0);
                    fins2.Write(valoriWriteDWord2, valoriWriteDWord2.Count, 50, 82, false);
                }
                finally
                {
                    fins1?.Disconnect();
                    fins2?.Disconnect();
                }
#endif
            }
            catch (Exception) { }
        }





        private bool[] bitEsito = null;
        private int idx = 0;

        private short cntScartiD = 0;
        private short cntScartiS = 0;

        private void IniBitEsito()
        {
            int cnt = this.impostazioni.NumPezziCalcoloPercentualeScarto;
            if (cnt == 0)
                cnt = 100;

            bitEsito = new bool[cnt];
            for (int i = 0; i < bitEsito.Length; i++)
            {
                bitEsito[i] = true;
            }
        }

        public void SetBitEsito(int idStazione, bool esito)
        {
            bitEsito[idx] = esito;

            if (!esito)
            {
                if (idStazione == 0)
                    cntScartiD++;
                else
                    cntScartiS++;
            }

            idx++;
            if (idx >= bitEsito.Length)
                idx = 0;
        }


        private double GetPercentualeScatoBitEsito()
        {
            int cntBad = bitEsito.Count(k => !k);

            return (double)cntBad / (double)bitEsito.Length * 100.0;
        }










        public void Close()
        {
            try
            {
                this.cancelToken?.Cancel();

                this.mainTask?.Join();

                this.ClientEEIPManager?.Stop();

                this.modbusClient?.Disconnect();
            }
            catch (Exception) { }
        }



        public class MyStructScriviPlcOmron
        {

            public bool CmdLoadData { get; set; }
            public bool CmdReset { get; set; }
            public bool LifeBit { get; set; }

            [Browsable(false)]
            public bool[] Bits_Byte0
            {
                get
                {
                    return new bool[] { CmdLoadData, CmdReset, LifeBit };
                }

                set
                {
                    CmdLoadData = value[0];
                    CmdReset = value[1];
                    LifeBit = value[2];
                }
            }

            public bool Error0 { get; set; }
            public bool Error1 { get; set; }

            [Browsable(false)]
            public bool[] Bits_Byte1
            {
                get
                {
                    return new bool[] { Error0, Error1 };
                }

                set
                {
                    Error0 = value[0];
                    Error1 = value[1];
                }
            }

            public int DeltaFtcFoto { get; set; }
            public int DeltaFtcResult { get; set; }
            public int DeltaFtcSoffio { get; set; }
            public int TempoSoffio { get; set; }
            public int FiltroIngresso { get; set; }

            public bool InFiltroScarta { get; set; }

            [Browsable(false)]
            public bool[] Bits_Byte22
            {
                get
                {
                    return new bool[] { InFiltroScarta };
                }

                set
                {
                    InFiltroScarta = value[0];
                }
            }

        }

        public class MyStructLeggiPlcOmron
        {

            public bool CmdLoadDataOK { get; set; }
            public bool CmdResetOK { get; set; }

            [Browsable(false)]
            public bool[] Bits_Byte0
            {
                get
                {
                    return new bool[] { CmdLoadDataOK, CmdResetOK };
                }

                set
                {
                    CmdLoadDataOK = value[0];
                    CmdResetOK = value[1];
                }
            }

        }

        private class MyTimer
        {
            public bool Active
            {
                get
                {
                    return DateTime.Now.Subtract(startTime).TotalMilliseconds < maxTime;
                }
            }

            private DateTime startTime = DateTime.MinValue;
            private int maxTime = 0;

            public MyTimer(int maxTime)
            {
                this.maxTime = maxTime;
            }

            public void Start()
            {
                if (!Active)
                    startTime = DateTime.Now;
            }

        }


    }
}