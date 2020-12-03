using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Orcamento.Api.Infrastructure.Validations;
using Orcamento.Api.Models.Entities.Budget;
using Orcamento.Api.Models.Entities.Clients;
using Orcamento.Api.Models.Entities.Contractors;
using Orcamento.Api.Models.User;

namespace Orcamento.Api.Infrastructure.IoC
{
    public static class ConfigureServicesValidators
    {
        public static IServiceCollection ConfigureValidators(this IServiceCollection services) =>
               services
                     .AddScoped<IValidator<Client>, ClientValidation>()
                     .AddScoped<IValidator<Contractor>, ContractorValidation>()
                     .AddScoped<IValidator<LaborBudget>, LaborBudgetValidation>()
                     .AddScoped<IValidator<MaterialsBudget>, MaterialsBudgetValidation>()
                     .AddScoped<IValidator<User>, UserValidation>()
                     .AddScoped<IValidator<ClientsAddress>, ClientAddressValidation>();
    }
}
