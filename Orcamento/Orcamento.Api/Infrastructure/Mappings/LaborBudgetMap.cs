using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orcamento.Api.Models.Entities.Budget;

namespace Orcamento.Api.Infrastructure.Mappings
{
    public class LaborBudgetMap : IEntityTypeConfiguration<LaborBudget>
    {
        public void Configure(EntityTypeBuilder<LaborBudget> builder)
        {
            builder.HasKey(b => b.IdLabor);

            builder.ToTable(nameof(LaborBudget));
            builder.Property(b => b.IdLabor).IsRequired();
            builder.Property(b => b.IdClient).IsRequired();
            builder.Property(b => b.CostPrice).IsRequired();
            builder.Property(b => b.Description).HasColumnType("varchar(max)").IsRequired();
        }
    }
}
