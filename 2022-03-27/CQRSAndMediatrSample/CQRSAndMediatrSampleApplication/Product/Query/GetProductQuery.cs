using CQRSAndMediatrSampleApplication.Product.Data;
using CQRSAndMediatrSampleApplication.Product.Dto;
using MediatR;

namespace CQRSAndMediatrSampleApplication.Product.Query
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public string Sku { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly ProductsInMemory _productsInMemory;

        public GetProductQueryHandler()
        {
            _productsInMemory = new ProductsInMemory();
        }

        public Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _productsInMemory.ProductDtos.FirstOrDefault(p => p.Sku.Equals(request.Sku));
            if (product == null)
            {
                throw new InvalidOperationException("Invalid product");
            }

            return Task.FromResult(product);
        }
    }
}
