using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Data;
using CQRSAndMediatrWithFluentValidationSampleApplication.Product.Dto;
using MediatR;

namespace CQRSAndMediatrWithFluentValidationSampleApplication.Product.Command
{
    public class AddOrUpdateProductCommand : IRequest<bool>
    {
        public ProductRequestDto ProductRequestDto { get; set; }
    }

    public class AddOrUpdateProductCommandHandler : IRequestHandler<AddOrUpdateProductCommand, bool>
    {
        private readonly ProductsInMemory _productsInMemory;

        public AddOrUpdateProductCommandHandler()
        {
            _productsInMemory = new ProductsInMemory();
        }

        public Task<bool> Handle(AddOrUpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct =
                _productsInMemory.ProductDtos.FirstOrDefault(p => p.Sku.Equals(request.ProductRequestDto.Sku));

            if (existingProduct != null)
            {
                var index = _productsInMemory.ProductDtos.FindIndex(p => p.Sku.Equals(request.ProductRequestDto.Sku));
                var productDto = _productsInMemory.ProductDtos[index];

                productDto.Name = request.ProductRequestDto.Name;
                productDto.Sku = request.ProductRequestDto.Sku;
                productDto.Quantity = request.ProductRequestDto.Quantity;
                productDto.Price = request.ProductRequestDto.Price;
                productDto.DateModified = DateTime.UtcNow;

                _productsInMemory.ProductDtos[index] = productDto;

                return Task.FromResult(true);
            }

            _productsInMemory.ProductDtos.Add(new ProductDto()
            {
                Name = request.ProductRequestDto.Name,
                Sku = request.ProductRequestDto.Sku,
                Quantity = request.ProductRequestDto.Quantity,
                Price = request.ProductRequestDto.Price,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            });

            return Task.FromResult(true);
        }
    }
}
