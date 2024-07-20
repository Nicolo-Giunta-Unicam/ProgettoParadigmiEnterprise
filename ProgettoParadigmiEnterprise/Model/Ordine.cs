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
        public virtual ICollection<Portata> portate { get; set; } = new HashSet<Portata>();

        public Ordine(string emailUtente, DateTime data, string indirizzo, ICollection<Portata> portate)
        {
            this.emailUtente = emailUtente;
            this.data = data;
            this.indirizzo = indirizzo;
            this.portate = portate;
        }

        public Ordine() { }
    }
}
