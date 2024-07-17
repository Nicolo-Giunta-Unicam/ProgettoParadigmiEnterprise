using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(DatabaseRistorante _context) : base(_context) { }

        public Utente GetUtenteByEmail(string _email) 
            => context.Set<Utente>().Where(x => x.email.Equals(_email)).FirstOrDefault();
        public bool CheckPasswordCorretta(string _password, string _email) 
            => context.Set<Utente>().Where(x => x.email.Equals(_email) && x.password.Equals(_password)).Any();
    }
}
