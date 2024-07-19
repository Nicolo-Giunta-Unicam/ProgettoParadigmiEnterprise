using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoParadigmiEnterprise.Model
{
    [Table("Portate")]
    public class Portata
    {
        [Key]
        public Guid id;
        public String nome { get; set; }
        public double prezzo { get; set; }
        public TipologiaPortata tipologia { get; set; }

        public Portata(string nome, double prezzo, TipologiaPortata tipologia)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.tipologia = tipologia;
        }

        public Portata() { }
    }

    public enum TipologiaPortata
    {
        Primo, Secondo, Contorno, Dolce
    }
}
