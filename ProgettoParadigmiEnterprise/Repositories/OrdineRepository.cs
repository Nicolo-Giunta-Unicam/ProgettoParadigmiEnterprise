using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class OrdineRepository : GenericRepository<Ordine>
    {
        public OrdineRepository(DatabaseRistorante _context) : base(_context) { }
        public IEnumerable<Ordine> GetOrdiniByUtente(string _email) => context.ordini.Where(o => o.emailUtente == _email).ToList();

    }
}
