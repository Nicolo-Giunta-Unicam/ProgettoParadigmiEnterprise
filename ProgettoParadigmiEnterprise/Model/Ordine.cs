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
    }
}
