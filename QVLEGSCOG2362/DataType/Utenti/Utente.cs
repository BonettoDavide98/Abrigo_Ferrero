namespace QVLEGSCOG2362.DataType
{
    public class Utente
    {

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Operatore { get; set; }
        public Livello.LivelloUtente LivelloUtente { get; set; }

    }
}
