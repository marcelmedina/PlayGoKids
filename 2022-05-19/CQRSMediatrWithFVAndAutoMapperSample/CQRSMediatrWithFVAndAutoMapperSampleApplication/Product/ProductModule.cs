using CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Pipeline;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSMediatrWithFVAndAutoMapperSampleApplication.Product
{
    public static class ProductModule
    {
        public static IServiceCollection AddProductModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(ProductModule).Assembly);
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            serviceCollection.AddAutoMapper(typeof(ProductModule));

            return serviceCollection;
        }
    }
}
