using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(DatabaseRistorante _context) : base(_context) { }
        /// <summary>
        /// Restituisce un utente data la sua email
        /// </summary>
        public Utente GetUtenteByEmail(string _email) 
            => context.Set<Utente>().Where(x => x.email.Equals(_email)).FirstOrDefault();
        /// <summary>
        /// Confronta la password in ingresso con la rispettiva password dell'utente
        /// </summary>
        /// <returns>true se corrispondono, false altrimenti</returns>
        public bool CheckPasswordCorretta(string _password, string _email) 
            => context.Set<Utente>().Where(x => x.email.Equals(_email) && x.password.Equals(_password)).Any();
    }
}
