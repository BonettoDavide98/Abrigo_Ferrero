using System;
using System.Collections.Generic;
using System.Linq;

namespace QVLEGSCOG2362.DataType
{
    public class StatisticheObj
    {

        public class ObjMisura
        {
            public string Nome { get; set; }
            public double Valore { get; set; }

            public ObjMisura(string nome, double valore)
            {
                this.Nome = nome;
                this.Valore = valore;
            }
        }

        public class ObjContatore
        {
            public string Nome { get; set; }
            public bool Valore { get; set; }

            public ObjContatore(string nome, bool valore)
            {
                this.Nome = nome;
                this.Valore = valore;
            }
        }

        public int IdStazione { get; set; }
        public int IdCamera { get; set; }
        public DateTime DataRiferimentoTurno { get; set; }
        public int NomeTurno { get; set; }
        public string IdFormato { get; set; }
        public DateTime TimeStamp { get; set; }

        //public double? TEST_INTEGRITA_AREA { get; set; }
        //public double? TEST_INTEGRITA_DELTA { get; set; }
        //public double? TEST_DIMENSIONE_DIAMETRO { get; set; }
        //public double? TEST_DIMENSIONE_CIRCOLARITA { get; set; }
        //public double? TEST_DIMENSIONE_W { get; set; }
        //public double? TEST_DIMENSIONE_H { get; set; }
        //public double? TEST_CREPE_LEN { get; set; }
        //public double? TEST_DISEGNI_PRESENZA_AREA { get; set; }
        //public double? TEST_DISEGNI_MACCHIE_GROSSE_AREA_MAX { get; set; }
        //public double? TEST_COLORE_DIST { get; set; }
        //public double? TEST_COLORE_DIST_2 { get; set; }
        //public double? TEST_COLORE_2_AREA { get; set; }
        //public double? TEST_SBORDAMENTO_AREA_MAX { get; set; }
        //public double? TEST_DIMENSIONE_ALTEZZA { get; set; }
        //public double? TEST_DIMENSIONE_LATO_W { get; set; }
        //public double? TEST_DIMENSIONE_LATO_H { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_V_0 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_V_1 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_V_2 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_V_3 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_V_4 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_H_0 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_H_1 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_H_2 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_H_3 { get; set; }
        //public double? TEST_RAKE_DIMENSIONE_LATO_H_4 { get; set; }
        //public double? TEST_Acetato_LATO_3D_AREA_MAX { get; set; }

        public List<ObjMisura> Misure { get; set; }
        public void AddMisura(string nome, double valore)
        {
            this.Misure.Add(new ObjMisura(nome, valore));
        }

        //public bool ALG_OK { get; set; }
        //public bool? ALLINEAMENTO_OK { get; set; }
        //public bool? TEST_INTEGRITA_OK { get; set; }
        //public bool? TEST_DIMENSIONE_OK { get; set; }
        //public bool? TEST_CREPE_OK { get; set; }
        //public bool? TEST_DISEGNI_OK { get; set; }
        //public bool? TEST_COLORE_OK { get; set; }
        //public bool? TEST_COLORE_2_OK { get; set; }
        //public bool? TEST_SBORDAMENTO_OK { get; set; }
        //public bool? TEST_ALTEZZA_OK { get; set; }
        //public bool? TEST_DIMENSIONE_LATO_OK { get; set; }
        //public bool? TEST_RAKE_DIMENSIONE_LATO_OK { get; set; }
        //public bool? TEST_TOP_3D_OK { get; set; }
        //public bool? TEST_Acetato_LATO_3D_OK { get; set; }

        public List<ObjContatore> Contatori { get; set; }
        public void AddObjContatore(string nome, bool valore)
        {
            this.Contatori.Add(new ObjContatore(nome, valore));
        }


        public StatisticheObj()
        {
            this.Misure = new List<ObjMisura>();
            this.Contatori = new List<ObjContatore>();
        }

        //public static StatisticheObj Zip(StatisticheObj[] o)
        //{
        //    StatisticheObj ret = new StatisticheObj();

        //    ret.IdStazione = o[0].IdStazione;
        //    ret.DataRiferimentoTurno = o[0].DataRiferimentoTurno;
        //    ret.NomeTurno = o[0].NomeTurno;
        //    ret.IdFormato = o[0].IdFormato;
        //    ret.TimeStamp = o[0].TimeStamp;
        //    ret.ALG_OK = o.Count(k => k?.ALG_OK == false) == 0;
        //    ret.ALLINEAMENTO_OK = AndAll(o.Select(k => k.ALLINEAMENTO_OK).ToList());
        //    ret.TEST_INTEGRITA_OK = AndAll(o.Select(k => k.TEST_INTEGRITA_OK).ToList());
        //    ret.TEST_DIMENSIONE_OK = AndAll(o.Select(k => k.TEST_DIMENSIONE_OK).ToList());
        //    ret.TEST_CREPE_OK = AndAll(o.Select(k => k.TEST_CREPE_OK).ToList());
        //    ret.TEST_DISEGNI_OK = AndAll(o.Select(k => k.TEST_DISEGNI_OK).ToList());
        //    ret.TEST_COLORE_OK = AndAll(o.Select(k => k.TEST_COLORE_OK).ToList());
        //    ret.TEST_COLORE_2_OK = AndAll(o.Select(k => k.TEST_COLORE_2_OK).ToList());
        //    ret.TEST_SBORDAMENTO_OK = AndAll(o.Select(k => k.TEST_SBORDAMENTO_OK).ToList());
        //    ret.TEST_ALTEZZA_OK = AndAll(o.Select(k => k.TEST_ALTEZZA_OK).ToList());
        //    ret.TEST_DIMENSIONE_LATO_OK = AndAll(o.Select(k => k.TEST_DIMENSIONE_LATO_OK).ToList());
        //    ret.TEST_RAKE_DIMENSIONE_LATO_OK = AndAll(o.Select(k => k.TEST_RAKE_DIMENSIONE_LATO_OK).ToList());
        //    ret.TEST_TOP_3D_OK = AndAll(o.Select(k => k.TEST_TOP_3D_OK).ToList());
        //    ret.TEST_Acetato_LATO_3D_OK = AndAll(o.Select(k => k.TEST_Acetato_LATO_3D_OK).ToList());

        //    return ret;
        //}

        private static bool? AndAll(List<bool?> o)
        {
            int cntNull = o.Count(k => k == null);
            int cntTrue = o.Count(k => k == true);
            int cntFalse = o.Count(k => k == false);

            if (cntNull == o.Count)
            {
                return null;
            }
            else if (cntTrue > 0 && cntFalse == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
