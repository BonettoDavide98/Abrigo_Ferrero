using System.Collections.Generic;

namespace QVLEGSCOG2362.Class
{
    public class GraficiSoglieManager
    {

        private object objLock = new object();

        private Dictionary<string, Dictionary<int, int>> valori = new Dictionary<string, Dictionary<int, int>>();

        public void AddData(List<DataType.StatisticheObj.ObjMisura> val)
        {
            lock (objLock)
            {
                foreach (var item in val)
                {
                    double b = Algoritmi.AlgoritmoLavoro.GetBucketByKey(item.Nome);

                    int x = (int)((item.Valore / b));

                    if (!valori.ContainsKey(item.Nome))
                    {
                        valori.Add(item.Nome, new Dictionary<int, int>());
                    }

                    if (!valori[item.Nome].ContainsKey(x))
                    {
                        valori[item.Nome].Add(x, 0);
                    }

                    valori[item.Nome][x] += 1;
                }
            }
        }

        public Dictionary<string, Dictionary<int, int>> GetData()
        {
            lock (objLock)
            {
                return valori;
            }
        }

        public void ClearData()
        {
            lock (objLock)
            {
                valori.Clear();
            }
        }

    }
}