using Autofac;
using CQRSAndMediatrSampleApplication.Product.Command;
using CQRSAndMediatrSampleApplication.Product.Notify;
using CQRSAndMediatrSampleApplication.Product.Query;

namespace CQRSAndMediatrSampleApplication.Product
{
    public class ProductModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetProductQuery>().AsImplementedInterfaces();
            builder.RegisterType<GetProductsQuery>().AsImplementedInterfaces();
            builder.RegisterType<AddOrUpdateProductCommand>().AsImplementedInterfaces();
            builder.RegisterType<DeleteProductCommand>().AsImplementedInterfaces();
            builder.RegisterType<PublishProductNotify>().AsImplementedInterfaces();

            builder.RegisterType<GetProductQueryHandler>().AsImplementedInterfaces();
            builder.RegisterType<GetProductsQueryHandler>().AsImplementedInterfaces();
            builder.RegisterType<AddOrUpdateProductCommandHandler>().AsImplementedInterfaces();
            builder.RegisterType<DeleteProductCommandHandler>().AsImplementedInterfaces();
            builder.RegisterType<PublishProductNotifyMessageHandler>().AsImplementedInterfaces();
            builder.RegisterType<PublishProductNotifyTextHandler>().AsImplementedInterfaces();
        }
    }
}
