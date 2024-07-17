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
    }

    public enum TipologiaPortata
    {
        Primo, Secondo, Contorno, Dolce
    }
}
