using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orcamento.Api.Infrastructure.IoC;
using Orcamento.Api.StartupConfigurations;

namespace Orcamento.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddCustomValidator();

            services
                .AddCustomSwagger()
                .AddCustomAutoMapper()
                .RegisterServices()
                .RegisterRepositories()
                .RegisterDataBases(Configuration)
                .ConfigureValidators()
                .ConfigureAuthentication(Configuration)
                .ConfigurationService(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app
               .UseAuthentication()
               .UseDefaultFiles()
               .UseStaticFiles()
               .UseMvc()
               .UseHsts()
               .UseSwagger()
               .UseCustomSwagger()
               .UseHttpsRedirection();
        }
    }
}
