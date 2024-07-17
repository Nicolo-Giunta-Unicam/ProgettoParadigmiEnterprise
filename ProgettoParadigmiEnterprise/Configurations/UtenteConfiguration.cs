using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Configurations
{
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(p => p.email);
        }
    }
}
