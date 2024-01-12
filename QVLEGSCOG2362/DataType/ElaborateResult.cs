using Cognex.VisionPro;
using System;
using System.Collections.Generic;

namespace QVLEGSCOG2362.DataType
{
    public class ElaborateResult
    {

        public bool Success { get; set; }

        public bool Result1 { get; set; }
        public bool Result2 { get; set; }

        public double ElapsedTime { get; set; }
        public bool InTimeout { get; set; }

        public string DescrizioneTempi { get; set; }

        public bool IsCircle { get; set; }

        public StatisticheObj StatisticheObj { get; set; }

        public List<Tuple<string, CogColorConstants>> TestiOutAlgoritmi { get; set; }
        public List<string> TestiRagioneScarto { get; set; }

        public ElaborateResult(bool? isCircle)
        {
            this.Success = false;
            this.Result1 = false;
            this.Result2 = false;
            this.ElapsedTime = 0;
            this.InTimeout = false;
            this.IsCircle = isCircle == true;

            this.StatisticheObj = new StatisticheObj() { TimeStamp = DateTime.Now };

            this.TestiOutAlgoritmi = new List<Tuple<string, CogColorConstants>>();
            this.TestiRagioneScarto = new List<string>();
        }

    }
}