namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IUtenteService
    {
        /// <summary>
        /// Effettua la registrazione
        /// </summary>
        public bool Registra(string _email,  string _password, string _nome, string _cognome);
        /// <summary>
        /// Effettua l'accesso tramite le credenziali richieste e restituisce il token JWT per la sessione
        /// </summary>
        public string Accedi(string _email, string _password);
    }
}
