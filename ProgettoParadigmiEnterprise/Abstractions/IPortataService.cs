using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IPortataService
    {
        /// <summary>
        /// Crea e restituisce una portata dati i parametri necessari
        /// </summary>
        public Portata CreaPortata(string _nome, decimal _prezzo, TipologiaPortata _tipologia);
        /// <summary>
        /// Restituisce tutte le portate ordinabili
        /// </summary>
        public List<Portata> GetAllPortate();
        /// <summary>
        /// Restituisce una o più portate in base agli id forniti
        /// </summary>
        public List<Portata> GetPortateById(List<int> _portate);
    }
}
