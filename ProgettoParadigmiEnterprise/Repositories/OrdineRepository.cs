using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Context;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Repositories
{
    public class OrdineRepository : GenericRepository<Ordine>
    {
        public OrdineRepository(DatabaseRistorante _context) : base(_context) { }
        public IEnumerable<Ordine> GetOrdiniByUtente(string _email) => CaricaPortatePerOrdini(context.ordini.Where(o => o.emailUtente == _email).ToList());
        public new IEnumerable<Ordine> GetAll() => CaricaPortatePerOrdini(context.ordini.ToList());

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

        List<Ordine> CaricaPortatePerOrdini(List<Ordine> _ordini)
        {
            foreach (var ordine in _ordini)
                ordine.portate = context.portate.FromSqlRaw($"SELECT p.* FROM PortateOrdine po LEFT JOIN Portate p ON po.idPortata = p.id WHERE po.numeroOrdine = {ordine.numero}").ToList();
            return _ordini;
        }
    }
}
