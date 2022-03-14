using CQRSAndMediatrSampleApplication.Product.Data;
using MediatR;

namespace CQRSAndMediatrSampleApplication.Product.Command
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public string Sku { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly ProductsInMemory _productsInMemory;

        public DeleteProductCommandHandler()
        {
            _productsInMemory = new ProductsInMemory();
        }
        
        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct =
                _productsInMemory.ProductDtos.FirstOrDefault(p => p.Sku.Equals(request.Sku));

            if (existingProduct != null)
            {
                var result = _productsInMemory.ProductDtos.Remove(existingProduct);
                return Task.FromResult(result);
            }

            throw new InvalidOperationException("Invalid product");
        }
    }
}
