using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IOrdineService
    {
        public Ordine CreaOrdine(string _emailUtente, string _indirizzo, List<Portata> _portate);
        public List<Ordine> GetAllOrdini();
        public List<Ordine> GetOrdiniByUtente(string _emailUtente);
    }
}
