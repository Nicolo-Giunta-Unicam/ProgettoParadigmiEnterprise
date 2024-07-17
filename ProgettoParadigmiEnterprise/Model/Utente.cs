using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoParadigmiEnterprise.Model
{
    [Table("Utenti")]
    public class Utente
    {
        [Key]
        public string email { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string password { get; set; }
        public Ruolo ruolo { get; set; }

        public Utente(string email, string nome, string cognome, string password, Ruolo ruolo)
        {
            this.email = email;
            this.nome = nome;
            this.cognome = cognome;
            this.password = password;
            this.ruolo = ruolo;
        }
    }

    public enum Ruolo
    {
        Cliente, Amministratore
    }
}
