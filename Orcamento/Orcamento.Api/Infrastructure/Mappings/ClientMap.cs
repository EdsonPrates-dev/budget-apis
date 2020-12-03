using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orcamento.Api.Models.Entities.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orcamento.Api.Infrastructure.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(b => b.IdClient);

            builder.ToTable(nameof(Client));
            builder.Property(b => b.IdClient).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Phone).IsRequired();
            builder.Property(b => b.Cpf).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Email).HasMaxLength(200).IsRequired();
        }
    }
}
