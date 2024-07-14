namespace ProgettoParadigmiEnterprise.Model
{
    public class Ordine
    {
        public int numero {  get; set; }
        public string emailUtente { get; set; }
        public DateTime data {  get; set; }
        public string indirizzo { get; set; }
        public ICollection<Portata> portata { get; set; }
    }
}
