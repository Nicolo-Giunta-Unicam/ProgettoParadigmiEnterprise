namespace ProgettoParadigmiEnterprise.Responses
{
    public class CreaOrdineResponse
    {
        public int numeroOrdine {  get; set; }
        public decimal totale { get; set; }
        public CreaOrdineResponse(int numeroOrdine, decimal totale)
        {
            this.numeroOrdine = numeroOrdine;
            this.totale = totale;
        }
    }
}
