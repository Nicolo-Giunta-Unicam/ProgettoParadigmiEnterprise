using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Requests
{
    public class CreaOrdineRequest
    {
        public string indirizzo { get; set; }
        public List<Portata> portate { get; set; }
    }
}
