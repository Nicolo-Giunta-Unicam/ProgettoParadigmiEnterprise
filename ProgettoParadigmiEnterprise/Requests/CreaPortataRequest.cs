using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Requests
{
    public class CreaPortataRequest
    {
        public string nome { get; set; }
        public decimal prezzo { get; set; }
        public TipologiaPortata tipologia { get; set; }
    }
}
