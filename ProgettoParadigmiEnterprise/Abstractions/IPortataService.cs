using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IPortataService
    {
        public Portata CreaPortata(string _nome, decimal _prezzo, TipologiaPortata _tipologia);
        public List<Portata> GetAllPortate();
        public List<Portata> GetPortateById(List<int> _portate);
    }
}
