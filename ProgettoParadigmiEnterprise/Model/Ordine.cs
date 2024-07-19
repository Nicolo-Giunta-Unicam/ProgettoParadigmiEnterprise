using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoParadigmiEnterprise.Model
{
    [Table("Ordini")]
    public class Ordine
    {
        [Key]
        public int numero {  get; set; }
        public string emailUtente { get; set; }
        public DateTime data {  get; set; }
        public string indirizzo { get; set; }
        public ICollection<Portata> portata { get; set; }

        public Ordine(string emailUtente, DateTime data, string indirizzo, ICollection<Portata> portata)
        {
            this.emailUtente = emailUtente;
            this.data = data;
            this.indirizzo = indirizzo;
            this.portata = portata;
        }

        public Ordine() { }
    }
}
