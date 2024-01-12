using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace QVLEGSCOG2362.Class
{
    public class GestioneContatori
    {

        private static object objLockUpdateDB = new object();

        private int cntCamere = -1;
        private DataType.ElaborateResult[] risultati = null;
        private AutoResetEvent[] segnali = null;
        private long foto, buoni, scarti;

        private List<DataType.StatisticheObj> listStatisticheTmpAll = null;
        private DataType.StatisticheObjContatori statisticheObj2 = null;

        private System.Collections.Concurrent.ConcurrentQueue<DataType.ElaborateResult[]> risultatiQueue = null;

        public GestioneContatori(int cntCamere)
        {
            this.cntCamere = cntCamere;
            this.risultati = new DataType.ElaborateResult[cntCamere];
            this.segnali = new AutoResetEvent[cntCamere];
            this.listStatisticheTmpAll = new List<DataType.StatisticheObj>();
            this.statisticheObj2 = null;
            this.risultatiQueue = new System.Collections.Concurrent.ConcurrentQueue<DataType.ElaborateResult[]>();

            for (int i = 0; i < cntCamere; i++)
            {
                this.segnali[i] = new AutoResetEvent(false);
                this.risultati[i] = null;
            }
        }

        public void WaitCam(int numCam)
        {
            try
            {
                segnali[numCam].WaitOne(40, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void WaitAllCam()
        {
            AutoResetEvent.WaitAll(segnali, 100, true);
        }

        public void SetCam(int numCam, DataType.ElaborateResult result)
        {
            try
            {
                risultati[numCam] = result;
                segnali[numCam].Set();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ControlloRisultati(out bool ret2)
        {
            bool ret = false;
            ret2 = false;

            foto++;

            //per lo scarto 1 devo avere tutte le camere in scarto
            if (risultati.Count(k => k != null && k.Result1 == false) == 3)
                ret = false;
            else
                ret = true;

            if (risultati.Count(k => k == null || k.Result2 == false) == 0)
                ret2 = true;
            else
                ret2 = false;

            if (ret && ret2)
                buoni++;
            else
                scarti++;

            //GestioneStatistiche(risultati);
            risultatiQueue.Enqueue(risultati);

            risultati = new DataType.ElaborateResult[cntCamere];
            for (int i = 0; i < risultati.Length; i++)
            {
                risultati[i] = null;
            }

            //se ho uno scarto1 non dò lo scarto 2
            if (!ret)
            {
                ret2 = true;
            }

            if (ret == false && ret2 == false)
            {
                ret = true;
            }

            return ret;
        }

        public void ResetContatori()
        {
            foto = 0;
            buoni = 0;
            scarti = 0;
        }

        public void GetContatori(out long foto, out long buoni, out long scarti)
        {
            foto = this.foto;
            buoni = this.buoni;
            scarti = this.scarti;
        }

        private bool AndAll(List<bool> o)
        {
            int cntTrue = o.Count(k => k == true);
            int cntFalse = o.Count(k => k == false);

            if (cntTrue > 0 && cntFalse == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GestioneStatistiche(DataType.ElaborateResult[] risultati)
        {
            try
            {
                DataType.StatisticheObj[] o = risultati.Where(k => k != null).Select(k => k.StatisticheObj).ToArray();

                if (o.Length > 0)
                {
                    DataType.StatisticheObjContatori tmp = new DataType.StatisticheObjContatori();
                    tmp.IdStazione = o[0].IdStazione;
                    tmp.DataRiferimentoTurno = o[0].DataRiferimentoTurno;
                    tmp.NomeTurno = o[0].NomeTurno;
                    tmp.IdFormato = o[0].IdFormato;
                    tmp.TimeStamp = o[0].TimeStamp;

                    List<DataType.StatisticheObj.ObjContatore> c = new List<DataType.StatisticheObj.ObjContatore>();
                    for (int i = 0; i < o.Length; i++)
                    {
                        if (o[i].Contatori != null)
                            c.AddRange(o[i].Contatori);
                    }

                    string[] chiavi = c.Select(k => k.Nome).Distinct().ToArray();

                    tmp.AddObjContatore("TOT", 1);

                    foreach (var item in chiavi)
                    {
                        List<bool> val = c.Where(k => k.Nome == item).Select(x => x.Valore).ToList();

                        if (item == "ALG_OK")
                        {
                            int cntKo = val.Count(k => k == false);
                            tmp.AddObjContatore("ALG_KO", cntKo == 0 ? 0 : 1);
                        }
                        else if (item.StartsWith("CNT_KO_CAM"))
                        {
                            bool andAll = AndAll(val);
                            tmp.AddObjContatore(item, andAll ? 1 : 0);
                        }
                        else
                        {
                            bool andAll = AndAll(val);
                            string newKey = item.Replace("OK", "KO");
                            tmp.AddObjContatore(newKey, andAll ? 0 : 1);
                        }
                    }

                    //tmp.ALG_OK = o.Count(k => k?.ALG_OK == false) == 0;
                    //tmp.ALLINEAMENTO_OK = AndAll(o.Select(k => k.ALLINEAMENTO_OK).ToList());
                    //tmp.TEST_INTEGRITA_OK = AndAll(o.Select(k => k.TEST_INTEGRITA_OK).ToList());
                    //tmp.TEST_DIMENSIONE_OK = AndAll(o.Select(k => k.TEST_DIMENSIONE_OK).ToList());
                    //tmp.TEST_CREPE_OK = AndAll(o.Select(k => k.TEST_CREPE_OK).ToList());
                    //tmp.TEST_DISEGNI_OK = AndAll(o.Select(k => k.TEST_DISEGNI_OK).ToList());
                    //tmp.TEST_COLORE_OK = AndAll(o.Select(k => k.TEST_COLORE_OK).ToList());
                    //tmp.TEST_COLORE_2_OK = AndAll(o.Select(k => k.TEST_COLORE_2_OK).ToList());
                    //tmp.TEST_SBORDAMENTO_OK = AndAll(o.Select(k => k.TEST_SBORDAMENTO_OK).ToList());
                    //tmp.TEST_ALTEZZA_OK = AndAll(o.Select(k => k.TEST_ALTEZZA_OK).ToList());
                    //tmp.TEST_DIMENSIONE_LATO_OK = AndAll(o.Select(k => k.TEST_DIMENSIONE_LATO_OK).ToList());
                    //tmp.TEST_RAKE_DIMENSIONE_LATO_OK = AndAll(o.Select(k => k.TEST_RAKE_DIMENSIONE_LATO_OK).ToList());
                    //tmp.TEST_TOP_3D_OK = AndAll(o.Select(k => k.TEST_TOP_3D_OK).ToList());
                    //tmp.TEST_BUCHI_LATO_3D_OK = AndAll(o.Select(k => k.TEST_BUCHI_LATO_3D_OK).ToList());

                    DataType.StatisticheObjContatori s = tmp;

                    //for (int i = 0; i < risultati.Length; i++)
                    //{
                    //    if (!(risultati[i] != null && risultati[i].StatisticheObj != null && risultati[i].StatisticheObj.ALG_OK))
                    //    {
                    //        switch (i)
                    //        {
                    //            case 0: s.CNT_KO_CAM1++; break;
                    //            case 1: s.CNT_KO_CAM2++; break;
                    //            case 2: s.CNT_KO_CAM3++; break;
                    //            case 3: s.CNT_KO_CAM4++; break;
                    //            case 4: s.CNT_KO_CAM5++; break;
                    //            case 5: s.CNT_KO_CAM6++; break;
                    //            default:
                    //                break;
                    //        }
                    //    }
                    //}

                    if (statisticheObj2 == null)
                    {
                        statisticheObj2 = s;
                    }
                    //else if (statisticheObj2 != s)
                    //{
                    //    //se è cambiato qualcosa salvo
                    //    DBL.StatisticheManager.AggiornaTabStoricoStatisticheContatori(statisticheObj2);

                    //    //poi setto i nuovo dati
                    //    statisticheObj2 = s;
                    //}
                    else
                    {
                        statisticheObj2 += s;
                    }

                    for (int i = 0; i < risultati.Length; i++)
                    {
                        if (risultati[i] != null)
                            listStatisticheTmpAll.Add(risultati[i].StatisticheObj);
                    }

                    if (listStatisticheTmpAll.Count >= 100)
                    {
                        lock (objLockUpdateDB)
                        {
                            DBL.StatisticheManager.InserisciTabStatisticheMisureTmp(listStatisticheTmpAll);
                            listStatisticheTmpAll.Clear();

                            DBL.StatisticheManager.InserisciTabStatisticheContatoriTmp(statisticheObj2);
                            statisticheObj2 = null;

                            DBL.StatisticheManager.AggiornaTabStoricoStatisticheMisure();
                            DBL.StatisticheManager.AggiornaTabStoricoStatisticheContatori();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void TryGestioneStatistiche()
        {
            if (risultatiQueue.TryDequeue(out DataType.ElaborateResult[] risultati))
            {
                GestioneStatistiche(risultati);
            }
        }

    }
}