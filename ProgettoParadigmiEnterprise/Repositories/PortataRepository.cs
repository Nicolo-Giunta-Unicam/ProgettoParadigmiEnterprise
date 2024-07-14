using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class PortataRepository : GenericRepository<Portata>
    {
        public PortataRepository(DatabaseRistorante _context) : base(_context) { }
    }
}
