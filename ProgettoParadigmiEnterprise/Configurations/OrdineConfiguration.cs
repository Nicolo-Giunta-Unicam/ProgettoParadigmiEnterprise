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
        }
    }
}
