namespace QVLEGSCOG2362.DataType
{
    public class Livello
    {

        public enum LivelloUtente
        {
            NotLogged = 10000,
            Amministratore = 1,
            Tecnico = 2,
            Operatore = 3
        }

        public int ID { get; set; }
        public string Descrizione { get; set; }

    }
}
