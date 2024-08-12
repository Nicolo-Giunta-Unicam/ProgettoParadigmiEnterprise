using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Abstractions
{
    public interface IOrdineService
    {
        /// <summary>
        /// Crea e restituisce un ordine secondo i parametri richiesti
        /// </summary>
        public Ordine CreaOrdine(string _emailUtente, string _indirizzo, List<Portata> _portate);
        /// <summary>
        /// Restituisce la lista di tutti gli ordini effettuati tramite l'API
        /// </summary>
        public List<Ordine> GetAllOrdini();
        /// <summary>
        /// Restituisce tutti gli ordini effettuati da un dato utente
        /// </summary>
        public List<Ordine> GetOrdiniByUtente(string _emailUtente);
    }
}
