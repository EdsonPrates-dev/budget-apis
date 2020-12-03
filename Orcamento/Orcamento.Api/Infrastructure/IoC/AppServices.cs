using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orcamento.Api.Infrastructure.Authentication;
using Orcamento.Api.Infrastructure.AutoMapper;
using Orcamento.Api.Infrastructure.Context;
using Orcamento.Api.Infrastructure.Repository;
using Orcamento.Api.Service;
using Orcamento.Api.Service.Interfaces;

namespace Orcamento.Api.Infrastructure.IoC
{
    public static class AppServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) =>
            services
                .AddScoped<ITokenService, TokenFactory>()
                .AddScoped<IClientService, ClientService>()
                .AddScoped<IClientAddressService, ClientAddressService>()
                .AddScoped<IContractorService, ContractorService>()
                .AddScoped<ILaborBudgetService, LaborBudgetService>()
                .AddScoped<IMaterialsBudgetService, MaterialsBudgetService>()
                .AddScoped<IUserService, UserService>();            

        public static IServiceCollection RegisterRepositories(this IServiceCollection services) =>
           services
               .AddScoped<IClientRepository, ClientRepository>()
               .AddScoped<IClientAddressRepository, ClientAddressRepository>()
               .AddScoped<IContractorRepository, ContractorRepository>()
               .AddScoped<ILaborBudgetRepository, LaborBudgetRepository>()
               .AddScoped<IUserRepository, UserRepository>()
               .AddScoped<IMaterialsBudgetRepository, MaterialsBudgetRepository>();

        public static IServiceCollection RegisterDataBases(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<ProjectBudgetContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("sqlConnectionString")));

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services) =>
            services
                .AddSingleton(provider => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ItemsMapper());

                }).CreateMapper());
    }
}
