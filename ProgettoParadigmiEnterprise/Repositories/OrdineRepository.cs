using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class OrdineRepository : GenericRepository<Ordine>
    {
        public OrdineRepository(DatabaseRistorante _context) : base(_context) { }
        public IEnumerable<Ordine> GetOrdiniByUtente(string _email) => context.ordini.Include(o => o.portate).Where(o => o.emailUtente == _email).ToList();
        public new IEnumerable<Ordine> GetAll() => context.ordini.Include(o => o.portate).ToList();
        
        public new void Add(Ordine _ordine)
        {
            base.Add(_ordine);
            context.SaveChanges();
            // Aggiungo le portate duplicate nella tabella di Join "PortateOrdine"
            var ordineSalvato = Get(_ordine.numero);
            var portateAggiunte = new List<Portata>();
            foreach (var portata in _ordine.portate)
            {
                if (!portateAggiunte.Contains(portata)) portateAggiunte.Add(portata);
                else
                {
                    var portateOrdine = new Dictionary<string, object>
                    {
                        { "numeroOrdine", ordineSalvato.numero },
                        { "idPortata", portata.id }
                    };
                    context.Set<Dictionary<string, object>>("PortateOrdine").Add(portateOrdine);
                }
            }
        }
    }
}
