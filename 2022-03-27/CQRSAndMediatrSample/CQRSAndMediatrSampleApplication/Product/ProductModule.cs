using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSAndMediatrSampleApplication.Product
{
    public static class ProductModule
    {
        public static IServiceCollection AddProductModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(ProductModule).Assembly);

            return serviceCollection;
        }
    }
}
