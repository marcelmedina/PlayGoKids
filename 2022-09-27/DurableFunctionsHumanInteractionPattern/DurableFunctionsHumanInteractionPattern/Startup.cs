using DurableFunctionsHumanInteractionPattern;
using DurableFunctionsHumanInteractionPattern.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DurableFunctionsHumanInteractionPattern
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<INotifier>(s => new Notifier());
        }
    }
}