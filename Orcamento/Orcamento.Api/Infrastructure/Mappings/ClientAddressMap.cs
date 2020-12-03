using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orcamento.Api.Models.Entities.Clients;

namespace Orcamento.Api.Infrastructure.Mappings
{
    public class ClientAddressMap : IEntityTypeConfiguration<ClientsAddress>
    {
        public void Configure(EntityTypeBuilder<ClientsAddress> builder)
        {
            builder.HasKey(b => b.IdAddress);

            builder.ToTable("ClientAddress");

            builder.Property(b => b.IdAddress).IsRequired();
            builder.Property(b => b.IdClient).IsRequired();           
            builder.Property(b => b.Neighborhood).IsRequired();           
            builder.Property(b => b.Number).IsRequired();           
            builder.Property(b => b.Street).HasMaxLength(200).IsRequired();
            builder.Property(b => b.City).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Cep).IsRequired();
            builder.Property(b => b.Country).HasMaxLength(200).IsRequired();
        }
    }
}
