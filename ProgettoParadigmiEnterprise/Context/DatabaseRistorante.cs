using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Context
{
    public class DatabaseRistorante : DbContext
    {
        public DbSet<Utente> utenti { get; set; }
        public DbSet<Ordine> ordini { get; set; }
        public DbSet<Portata> portate { get; set; }
    }
}
