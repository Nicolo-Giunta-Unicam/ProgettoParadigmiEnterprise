using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class OrdineRepository : GenericRepository<Ordine>
    {
        public OrdineRepository(DatabaseRistorante _context) : base(_context) { }

    }
}
