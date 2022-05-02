using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Data;
using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Dto;
using MediatR;

namespace CQRSAndMediatrWithFluentValidationSampleApplication.Product.Query
{
    public class GetProductsQuery : IRequest<List<ProductDto>> {}

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly ProductsInMemory _productsInMemory;

        public GetProductsQueryHandler()
        {
            _productsInMemory = new ProductsInMemory();
        }

        public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productsInMemory.ProductDtos;

            return Task.FromResult(products);
        }
    }
}
