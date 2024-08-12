using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Requests
{
    public class CreaOrdineRequest
    {
        public string indirizzo { get; set; }
        public List<int> portate { get; set; }
    }
}
