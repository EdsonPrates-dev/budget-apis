using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Orcamento.Api.Infrastructure.IoC
{
    public static class AppServiceConfiguration
    {
        public static IServiceCollection ConfigurationService(this IServiceCollection services, IConfiguration configuration) =>
              services
                  .AddSingleton(configuration);
    }
}
