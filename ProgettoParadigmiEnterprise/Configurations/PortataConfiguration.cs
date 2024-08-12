using Microsoft.EntityFrameworkCore;
using ProgettoParadigmiEnterprise.Model;

namespace ProgettoParadigmiEnterprise.Configurations
{
    public class PortataConfiguration : IEntityTypeConfiguration<Portata>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Portata> builder)
        {
            builder.ToTable("Portate");
            builder.HasKey(p => p.id);
        }
    }
}
