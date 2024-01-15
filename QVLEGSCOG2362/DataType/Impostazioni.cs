using System;
using System.ComponentModel;

namespace QVLEGSCOG2362.DataType
{
    [Serializable]
    public class Impostazioni
    {

        public enum DispositiviScarto { NN, Omron, Gardasoft, Fins }
        public enum TipoComunizazioneRisultato { Camera, SchedaIO }
        public enum TipoLogin { NN, Modbus, Form }


        [Category("Percorsi")]
        public string PathDatiBase { get; set; }
        //[Category("Percorsi")]
        //public string PathImmaginiDaCamera { get; set; }


        [Category("Gestione Utenti")]
        [Browsable(false)]
        public string Password { get; set; }


        [Category("PLC")]
        public string PLC_1_IP { get; set; }
        [Category("PLC")]
        public string PLC_2_IP { get; set; }
        [Category("PLC")]
        [Browsable(false)]
        public int PLC_Rack { get; set; }
        [Category("PLC")]
        [Browsable(false)]
        public int PLC_Slot { get; set; }


        [Category("Log Errori")]
        public int NumeroErrori { get; set; }
        [Category("Log Errori")]
        public int NumeroErroriSuDisco { get; set; }
        [Category("Log Errori")]
        public bool ErroriSuDisco { get; set; }
        [Category("Log Errori")]
        public string PathErrori { get; set; }


        [Category("Camera")]
        public ImpostazioniCamera ImpostazioniCamera1 { get; set; }
        [Category("Camera")]
        public ImpostazioniCamera ImpostazioniCamera2 { get; set; }
        [Category("Camera")]
        public ImpostazioniCamera ImpostazioniCamera3 { get; set; }
        [Category("Camera")]
        //public ImpostazioniCamera ImpostazioniCamera4 { get; set; }
        //[Category("Camera")]
        //public ImpostazioniCamera ImpostazioniCamera5 { get; set; }
        //[Category("Camera")]
        //public ImpostazioniCamera ImpostazioniCamera6 { get; set; }
        //[Category("Camera")]
        public string IpGocator { get; set; }


        [Category("Scarto")]
        public DispositiviScarto TipologiaDispositivoScarto { get; set; }
        [Category("Scarto")]
        public TipoComunizazioneRisultato TipologiaComunizazioneRisultato { get; set; }
        [Category("Scarto")]
        public double KConv_mm_enc { get; set; }
        [Category("Scarto")]
        public string IpGardasoft { get; set; }
        [Category("Scarto")]
        public int PortaGardasoft { get; set; }


        [Category("Utenti")]
        public int LoginTimeout { get; set; }
        [Category("Utenti")]
        [Browsable(false)]
        public bool BypassLogin { get; set; }
        [Category("Utenti")]
        public TipoLogin TipologiaLogin { get; set; }

        [Category("Scheda IO")]
        public int IdxOutReady { get; set; }
        [Category("Scheda IO")]
        public int IdxOutResult { get; set; }
        [Category("Scheda IO")]
        public int IdxOutResult_2 { get; set; }

        [Category("Scheda IO")]
        public int IdxOutReady2 { get; set; }
        [Category("Scheda IO")]
        public int IdxOutResult2 { get; set; }
        [Category("Scheda IO")]
        public int IdxOutResult2_2 { get; set; }

        [Category("Scheda IO")]
        public int IdxOutSirena { get; set; }
        [Category("Scheda IO")]
        public int IdxOutLedRosso { get; set; }
        [Category("Scheda IO")]
        public int IdxOutLedVerde { get; set; }
        [Category("Scheda IO")]
        public int IdxOutLedGiallo { get; set; }
        [Category("Scheda IO")]
        public int IdxOutLifeBit { get; set; }
        [Category("Scheda IO")]
        public int IdxInEnable { get; set; }
        [Category("Scheda IO")]
        public int IdxInSelettoreSoffio { get; set; }


        [Category("Controlli")]
        public bool ControlloNastro { get; set; }
        [Category("Controlli")]
        public int TempoControlloNastro { get; set; }


        [Category("Allarmi")]
        public int MaxPercentualeScarto { get; set; }
        [Category("Allarmi")]
        public int NumPezziCalcoloPercentualeScarto { get; set; }
        [Category("Allarmi")]
        public int TimeoutSirena { get; set; }


        [Category("Lingua")]
        public string Lingua1 { get; set; }
        [Category("Lingua")]
        public string Lingua2 { get; set; }
        [Category("Lingua")]
        public string Lingua3 { get; set; }

        [Category("Statistiche")]
        public double SogliaPercScatoRosso { get; set; }
        [Category("Statistiche")]
        public double SogliaPercScatoGiallo { get; set; }

        [Category("Wizard")]
        public bool AbilitaVistaAvanzata { get; set; }
        [Category("Wizard")]
        public double AreaMinimaSegmentazione2 { get; set; }


        [Category("Ricette")]
        public bool AbilitaSceltaModo { get; set; }


        [Category("3D")]
        public double BucketSize_3D { get; set; }
        [Category("3D")]
        public int OffsetX_3D { get; set; }
        [Category("3D")]
        public int OffsetZ_3D { get; set; }
        [Category("3D")]
        public int ImageW_3DTop { get; set; }
        [Category("3D")]
        public int ImageH_3DTop { get; set; }
        [Category("3D")]
        public double ScaleW_3DTop { get; set; }
        [Category("3D")]
        public double ScaleH_3DTop { get; set; }
        [Category("3D")]
        public int ImageW_3DLato { get; set; }
        [Category("3D")]
        public int ImageH_3DLato { get; set; }
        [Category("3D")]
        public double ScaleW_3DLato { get; set; }
        [Category("3D")]
        public double ScaleH_3DLato { get; set; }


        [Category("Abilitazione Algoritmi")]
        public bool AbilitaIntegrita2 { get; set; }
        [Category("Abilitazione Algoritmi")]
        public bool AbilitaIntegrita3 { get; set; }
        [Category("Abilitazione Algoritmi")]
        public bool AbilitaIntegrita4 { get; set; }


        [Category("Algoritmi")]
        public double PercentualeTolleranzaAlgoritmi { get; set; }

        public Impostazioni()
        {
            //this.FiltroMinArea = 200;
            this.IdxOutResult_2 = -1;
            this.IdxOutResult2_2 = -1;

            this.ImpostazioniCamera1 = new ImpostazioniCamera();
            this.ImpostazioniCamera2 = new ImpostazioniCamera();
            this.ImpostazioniCamera3 = new ImpostazioniCamera();
            //this.ImpostazioniCamera4 = new ImpostazioniCamera();
            //this.ImpostazioniCamera5 = new ImpostazioniCamera();
            //this.ImpostazioniCamera6 = new ImpostazioniCamera();            
        }

    }
}