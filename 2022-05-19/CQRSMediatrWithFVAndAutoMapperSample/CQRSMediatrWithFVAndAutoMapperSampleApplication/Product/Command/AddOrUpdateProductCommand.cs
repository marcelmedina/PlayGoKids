using AutoMapper;
using CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Data;
using CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Dto;
using MediatR;

namespace CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Command
{
    public class AddOrUpdateProductCommand : IRequest<bool>
    {
        public ProductRequestDto ProductRequestDto { get; set; }
    }

    public class AddOrUpdateProductCommandHandler : IRequestHandler<AddOrUpdateProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ProductsInMemory _productsInMemory;

        public AddOrUpdateProductCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
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

                var existingProductDto = _mapper.Map(request.ProductRequestDto, productDto);

                _productsInMemory.ProductDtos[index] = existingProductDto;

                return Task.FromResult(true);
            }

            var newProductDto = _mapper.Map<ProductDto>(request.ProductRequestDto);
            newProductDto.DateCreated = newProductDto.DateModified;

            _productsInMemory.ProductDtos.Add(newProductDto);

            return Task.FromResult(true);
        }
    }
}
