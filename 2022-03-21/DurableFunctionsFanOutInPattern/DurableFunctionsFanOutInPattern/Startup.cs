using DurableFunctionsFanOutInPattern;
using DurableFunctionsFanOutInPattern.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DurableFunctionsFanOutInPattern
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IOrderService>(s => new OrderService());
        }
    }
}
