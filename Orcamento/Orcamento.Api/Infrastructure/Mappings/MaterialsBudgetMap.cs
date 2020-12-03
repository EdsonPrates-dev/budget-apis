using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orcamento.Api.Models.Entities.Budget;

namespace Orcamento.Api.Infrastructure.Mappings
{
    public class MaterialsBudgetMap : IEntityTypeConfiguration<MaterialsBudget>
    {
        public void Configure(EntityTypeBuilder<MaterialsBudget> builder)
        {
            builder.HasKey(b => b.IdMaterials);

            builder.ToTable(nameof(MaterialsBudget));
            builder.Property(b => b.IdMaterials).IsRequired();
            builder.Property(b => b.IdClient).IsRequired();
            builder.Property(b => b.Description).HasColumnType("varchar(max)").IsRequired();
            builder.Property(b => b.CostPrice).IsRequired();
            builder.Property(b => b.Quantity).IsRequired();
        }
    }
}
