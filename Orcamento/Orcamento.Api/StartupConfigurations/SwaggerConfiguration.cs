using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Orcamento.Api.StartupConfigurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("BEARER TOKEN", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insira o JWT Token.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("budget", new OpenApiInfo
                {
                    Title = "Budget API"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app) =>
           app
               .UseSwagger()
               .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/budget/swagger.json", "Budget API");
                });
    }
}
