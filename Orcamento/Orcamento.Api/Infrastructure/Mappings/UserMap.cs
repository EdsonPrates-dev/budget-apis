using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orcamento.Api.Models.User;

namespace Orcamento.Api.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.IdUser);

            builder.ToTable(nameof(User));
            builder.Property(b => b.IdContractor).IsRequired();
            builder.Property(b => b.Login).IsRequired();
            builder.Property(b => b.Password).IsRequired();
        }   
    }
}
