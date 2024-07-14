namespace ProgettoParadigmiEnterprise.Model
{
    public class Utente
    {
        public string email { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string password { get; set; }
        public Ruolo ruolo { get; set; }

    }

    public enum Ruolo
    {
        Cliente, Amministratore
    }
}
