using System;

namespace QVLEGSCOG2362.DataType
{
    public class StatisticheObjMisure
    {

        public DateTime DataRiferimentoTurno { get; set; }
        public int NomeTurno { get; set; }
        public string IdFormato { get; set; }
        public DateTime TimeStamp { get; set; }
        public int TOT { get; set; }
        public int ALG_KO { get; set; }
        public int ALLINEAMENTO_KO { get; set; }
        public int TEST_INTEGRITA_KO { get; set; }
        public int TEST_DIMENSIONE_KO { get; set; }
        public int TEST_CREPE_KO { get; set; }
        public int TEST_DISEGNI_KO { get; set; }
        public int TEST_COLORE_KO { get; set; }
        public int TEST_SBORDAMENTO_KO { get; set; }
        public int TEST_ALTEZZA_KO { get; set; }
        public int TEST_DIMENSIONE_LATO_KO { get; set; }
        public int CNT_KO_CAM1 { get; set; }
        public int CNT_KO_CAM2 { get; set; }
        public int CNT_KO_CAM3 { get; set; }
        public int CNT_KO_CAM4 { get; set; }
        public int CNT_KO_CAM5 { get; set; }

    }
}
