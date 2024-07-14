namespace ProgettoParadigmiEnterprise.Model
{
    public class Portata
    {
        public String nome { get; set; }
        public double prezzo { get; set; }
        public TipologiaPortata tipologia { get; set; }
    }

    public enum TipologiaPortata
    {
        Primo, Secondo, Contorno, Dolce
    }
}
