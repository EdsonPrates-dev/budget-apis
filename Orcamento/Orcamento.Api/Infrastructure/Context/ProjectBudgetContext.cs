using Microsoft.EntityFrameworkCore;
using Orcamento.Api.Infrastructure.Mappings;
using Orcamento.Api.Models.Entities.Budget;
using Orcamento.Api.Models.Entities.Clients;
using Orcamento.Api.Models.Entities.Contractors;
using Orcamento.Api.Models.User;

namespace Orcamento.Api.Infrastructure.Context
{
    public class ProjectBudgetContext : DbContext
    {
        public ProjectBudgetContext(DbContextOptions<ProjectBudgetContext> options) : 
            base(options) {}

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientsAddress> ClientAddress { get; set; }
        public DbSet<Contractor> Contractor { get; set; }
        public DbSet<MaterialsBudget> MaterialsBudget { get; set; }
        public DbSet<LaborBudget> LaborBudget { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientMap());
            builder.ApplyConfiguration(new ClientAddressMap());
            builder.ApplyConfiguration(new ContractorMap());
            builder.ApplyConfiguration(new MaterialsBudgetMap());
            builder.ApplyConfiguration(new LaborBudgetMap());
            builder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(builder);
        }
    }
}
