using ProgettoParadigmiEnterprise.Abstractions;
using ProgettoParadigmiEnterprise.Model;
using ProgettoParadigmiEnterprise.Repositories;

namespace ProgettoParadigmiEnterprise.Services
{
    public class PortataService : IPortataService
    {
        private readonly PortataRepository portataRepository;
        public PortataService(PortataRepository _portataRepository)
        {
            portataRepository = _portataRepository;
        }
        public Portata CreaPortata(string _nome, decimal _prezzo, TipologiaPortata _tipologia)
        {
            Portata portata = new Portata(_nome, _prezzo, _tipologia);
            portataRepository.Add(portata);
            portataRepository.Save();
            return portata;
        }
        public List<Portata> GetAllPortate() => (List<Portata>)portataRepository.GetAll();
    }
}
