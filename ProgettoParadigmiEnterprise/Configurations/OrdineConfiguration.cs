using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Configurations
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ordine> builder)
        {
            builder.ToTable("Ordini");
            builder.HasKey(p => p.numero);
            builder.HasMany(p => p.portate).WithMany(p => p.ordini)
            .UsingEntity(
            "PortateOrdine",
            l => l.HasOne(typeof(Portata)).WithMany().HasForeignKey("idPortata").HasPrincipalKey(nameof(Portata.id)),
            r => r.HasOne(typeof(Ordine)).WithMany().HasForeignKey("numeroOrdine").HasPrincipalKey(nameof(Ordine.numero)),
            j => j.HasKey("idPortata", "numeroOrdine"));
        }
    }
}
