using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Model;
using ProgettoParadigmiEnterprise.Repositories;

namespace ProgettoParadigmiEnterprise.Services
{
    public class OrdineService : IOrdineService
    {
        private readonly OrdineRepository ordineRepository;
        public OrdineService(OrdineRepository _ordineRepository)
        {
            ordineRepository = _ordineRepository;
        }

        public Ordine CreaOrdine(string _emailUtente, string _indirizzo, List<Portata> _portate)
        {
            Ordine ordine = new Ordine(_emailUtente, DateTime.Now, _indirizzo, _portate);
            ordineRepository.Add(ordine);
            ordineRepository.Save();
            return ordine;
        }

        public List<Ordine> GetAllOrdini() => (List<Ordine>)ordineRepository.GetAll();

        public List<Ordine> GetOrdiniByUtente(string _emailUtente) => (List<Ordine>)ordineRepository.GetOrdiniByUtente(_emailUtente);
        
    }
}
