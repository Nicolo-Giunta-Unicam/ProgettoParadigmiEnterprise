using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(DatabaseRistorante _context) : base(_context) { }
    }
}
