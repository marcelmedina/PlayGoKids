using FluentValidation.AspNetCore;
using FluentValidationFunction;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FluentValidationFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssembly(typeof(Startup).Assembly);
            });
        }
    }
}
