using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orcamento.Api.Models.Entities.Contractors;

namespace Orcamento.Api.Infrastructure.Mappings
{
    public class ContractorMap : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> builder)
        {
            builder.HasKey(b => b.IdContractor);

            builder.ToTable(nameof(Contractor));
            builder.Property(b => b.IdContractor).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Phone).IsRequired();
            builder.Property(b => b.Cpf).HasMaxLength(100).IsRequired();
        }
    }
}
