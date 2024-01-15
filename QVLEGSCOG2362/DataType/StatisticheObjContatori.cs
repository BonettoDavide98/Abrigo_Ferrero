using System;
using System.Collections.Generic;
using System.Linq;

namespace QVLEGSCOG2362.DataType
{
    public class StatisticheObjContatori
    {

        public class ObjContatore
        {
            public string Nome { get; set; }
            public int Valore { get; set; }

            public ObjContatore(string nome, int valore)
            {
                this.Nome = nome;
                this.Valore = valore;
            }
        }

        public int IdStazione { get; set; }
        public DateTime DataRiferimentoTurno { get; set; }
        public int NomeTurno { get; set; }
        public string IdFormato { get; set; }
        public DateTime TimeStamp { get; set; }
        //public int TOT { get; set; }
        //public int ALG_KO { get; set; }
        //public int ALLINEAMENTO_KO { get; set; }
        //public int TEST_INTEGRITA_KO { get; set; }
        //public int TEST_DIMENSIONE_KO { get; set; }
        //public int TEST_CREPE_KO { get; set; }
        //public int TEST_DISEGNI_KO { get; set; }
        //public int TEST_COLORE_KO { get; set; }
        //public int TEST_COLORE_2_KO { get; set; }
        //public int TEST_SBORDAMENTO_KO { get; set; }
        //public int TEST_ALTEZZA_KO { get; set; }
        //public int TEST_DIMENSIONE_LATO_KO { get; set; }
        //public int TEST_RAKE_DIMENSIONE_LATO_KO { get; set; }
        //public int TEST_TOP_3D_KO { get; set; }
        //public int TEST_Acetato_LATO_3D_KO { get; set; }
        //public int CNT_KO_CAM1 { get; set; }
        //public int CNT_KO_CAM2 { get; set; }
        //public int CNT_KO_CAM3 { get; set; }
        //public int CNT_KO_CAM4 { get; set; }
        //public int CNT_KO_CAM5 { get; set; }
        //public int CNT_KO_CAM6 { get; set; }

        public List<ObjContatore> Contatori { get; set; }
        public void AddObjContatore(string nome, int valore)
        {
            this.Contatori.Add(new ObjContatore(nome, valore));
        }

        public StatisticheObjContatori()
        {
            this.Contatori = new List<ObjContatore>();
        }

        //public static implicit operator StatisticheObjContatori(StatisticheObj a)
        //{
        //    StatisticheObjContatori ret = new StatisticheObjContatori();

        //    ret.IdStazione = a.IdStazione;
        //    ret.DataRiferimentoTurno = a.DataRiferimentoTurno;
        //    ret.NomeTurno = a.NomeTurno;
        //    ret.IdFormato = a.IdFormato;
        //    ret.TimeStamp = new DateTime(a.TimeStamp.Year, a.TimeStamp.Month, a.TimeStamp.Day, a.TimeStamp.Hour, a.TimeStamp.Minute, 0);
        //    //ret.TOT = 1;
        //    //ret.ALG_KO = a.ALG_OK == false ? 1 : 0;
        //    //ret.ALLINEAMENTO_KO = a.ALLINEAMENTO_OK == false ? 1 : 0;
        //    //ret.TEST_INTEGRITA_KO = a.TEST_INTEGRITA_OK == false ? 1 : 0;
        //    //ret.TEST_DIMENSIONE_KO = a.TEST_DIMENSIONE_OK == false ? 1 : 0;
        //    //ret.TEST_CREPE_KO = a.TEST_CREPE_OK == false ? 1 : 0;
        //    //ret.TEST_DISEGNI_KO = a.TEST_DISEGNI_OK == false ? 1 : 0;
        //    //ret.TEST_COLORE_KO = a.TEST_COLORE_OK == false ? 1 : 0;
        //    //ret.TEST_COLORE_2_KO = a.TEST_COLORE_2_OK == false ? 1 : 0;
        //    //ret.TEST_SBORDAMENTO_KO = a.TEST_SBORDAMENTO_OK == false ? 1 : 0;
        //    //ret.TEST_ALTEZZA_KO = a.TEST_ALTEZZA_OK == false ? 1 : 0;
        //    //ret.TEST_DIMENSIONE_LATO_KO = a.TEST_DIMENSIONE_LATO_OK == false ? 1 : 0;
        //    //ret.TEST_RAKE_DIMENSIONE_LATO_KO = a.TEST_RAKE_DIMENSIONE_LATO_OK == false ? 1 : 0;
        //    //ret.TEST_TOP_3D_KO = a.TEST_TOP_3D_OK == false ? 1 : 0;
        //    //ret.TEST_Acetato_LATO_3D_KO = a.TEST_Acetato_LATO_3D_OK == false ? 1 : 0;

        //    return ret;
        //}

        public static StatisticheObjContatori operator +(StatisticheObjContatori a, StatisticheObjContatori b)
        {
            StatisticheObjContatori ret = new StatisticheObjContatori();

            ret.IdStazione = a.IdStazione;
            ret.DataRiferimentoTurno = a.DataRiferimentoTurno;
            ret.NomeTurno = a.NomeTurno;
            ret.IdFormato = a.IdFormato;
            ret.TimeStamp = a.TimeStamp;

            string[] chiaviA = a.Contatori.Select(k => k.Nome).Distinct().ToArray();
            string[] chiaviB = b.Contatori.Select(k => k.Nome).Distinct().ToArray();

            string[] chiaviAll = chiaviA.Union(chiaviB).Distinct().ToArray();

            foreach (var item in chiaviAll)
            {
                int valA = a.Contatori.Where(k => k.Nome == item).Sum(x => x.Valore);
                int valB = b.Contatori.Where(k => k.Nome == item).Sum(x => x.Valore);

                ret.AddObjContatore(item, valA + valB);
            }

            //ret.TOT = a.TOT + b.TOT;
            //ret.ALG_KO = a.ALG_KO + b.ALG_KO;
            //ret.ALLINEAMENTO_KO = a.ALLINEAMENTO_KO + b.ALLINEAMENTO_KO;
            //ret.TEST_INTEGRITA_KO = a.TEST_INTEGRITA_KO + b.TEST_INTEGRITA_KO;
            //ret.TEST_DIMENSIONE_KO = a.TEST_DIMENSIONE_KO + b.TEST_DIMENSIONE_KO;
            //ret.TEST_CREPE_KO = a.TEST_CREPE_KO + b.TEST_CREPE_KO;
            //ret.TEST_DISEGNI_KO = a.TEST_DISEGNI_KO + b.TEST_DISEGNI_KO;
            //ret.TEST_COLORE_KO = a.TEST_COLORE_KO + b.TEST_COLORE_KO;
            //ret.TEST_COLORE_2_KO = a.TEST_COLORE_2_KO + b.TEST_COLORE_2_KO;
            //ret.TEST_SBORDAMENTO_KO = a.TEST_SBORDAMENTO_KO + b.TEST_SBORDAMENTO_KO;
            //ret.TEST_ALTEZZA_KO = a.TEST_ALTEZZA_KO + b.TEST_ALTEZZA_KO;
            //ret.TEST_DIMENSIONE_LATO_KO = a.TEST_DIMENSIONE_LATO_KO + b.TEST_DIMENSIONE_LATO_KO;
            //ret.TEST_RAKE_DIMENSIONE_LATO_KO = a.TEST_RAKE_DIMENSIONE_LATO_KO + b.TEST_RAKE_DIMENSIONE_LATO_KO;
            //ret.TEST_TOP_3D_KO = a.TEST_TOP_3D_KO + b.TEST_TOP_3D_KO;
            //ret.TEST_Acetato_LATO_3D_KO = a.TEST_Acetato_LATO_3D_KO + b.TEST_Acetato_LATO_3D_KO;
            //ret.CNT_KO_CAM1 = a.CNT_KO_CAM1 + b.CNT_KO_CAM1;
            //ret.CNT_KO_CAM2 = a.CNT_KO_CAM2 + b.CNT_KO_CAM2;
            //ret.CNT_KO_CAM3 = a.CNT_KO_CAM3 + b.CNT_KO_CAM3;
            //ret.CNT_KO_CAM4 = a.CNT_KO_CAM4 + b.CNT_KO_CAM4;
            //ret.CNT_KO_CAM5 = a.CNT_KO_CAM5 + b.CNT_KO_CAM5;
            //ret.CNT_KO_CAM6 = a.CNT_KO_CAM6 + b.CNT_KO_CAM6;

            return ret;
        }

        public static bool operator ==(StatisticheObjContatori a, StatisticheObjContatori b)
        {
            if (Object.ReferenceEquals(a, null))
            {
                if (Object.ReferenceEquals(b, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            else if (Object.ReferenceEquals(b, null))
            {
                return false;
            }

            return a.IdStazione == b.IdStazione
                && a.DataRiferimentoTurno == b.DataRiferimentoTurno
                && a.NomeTurno == b.NomeTurno
                && a.IdFormato == b.IdFormato
                && a.TimeStamp == b.TimeStamp;
        }

        public static bool operator !=(StatisticheObjContatori a, StatisticheObjContatori b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
