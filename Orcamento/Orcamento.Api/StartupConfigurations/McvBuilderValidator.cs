using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Orcamento.Api.Infrastructure.IoC
{
    public static class McvBuilderValidator
    {
        public static IMvcBuilder AddCustomValidator(this IMvcBuilder builder) =>
            builder
                 .AddFluentValidation(fv =>   
                        {
                            fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                        });
    }
}
