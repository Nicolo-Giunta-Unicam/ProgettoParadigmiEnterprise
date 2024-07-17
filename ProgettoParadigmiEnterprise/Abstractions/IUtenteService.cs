namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IUtenteService
    {
        public bool Registra(string _email,  string _password, string _nome, string _cognome);
        public string Accedi(string _email, string _password);
    }
}
