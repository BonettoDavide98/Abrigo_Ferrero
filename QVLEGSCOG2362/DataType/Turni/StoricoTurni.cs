using System;

namespace QVLEGSCOG2362.DataType
{
    public class StoricoTurni
    {

        public long Id { get; set; }
        public DateTime Data { get; set; }
        public short NomeTurno { get; set; } 

        public StoricoTurni() { }

        public StoricoTurni(long _id, DateTime _data, short _nomeTurno)
        {
            Id = _id;
            Data = _data;
            NomeTurno = _nomeTurno;
        }

    }
}