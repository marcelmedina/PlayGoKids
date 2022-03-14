using CQRSAndMediatrSampleApplication.Product.Dto;

namespace CQRSAndMediatrSampleApplication.Product.Data
{
    public class ProductsInMemory
    {
        private readonly List<ProductDto> _productList;

        public ProductsInMemory()
        {
            _productList = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Milk",
                    Sku = "MILK",
                    Quantity = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Coffee",
                    Sku = "COFFEE",
                    Quantity = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new ProductDto()
                {
                    Id = 3,
                    Name = "Toast",
                    Sku = "TOAST",
                    Quantity = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new ProductDto()
                {
                    Id = 4,
                    Name = "Butter",
                    Sku = "BUTTER",
                    Quantity = 10,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            };
        }

        public List<ProductDto> ProductDtos => _productList;
    }
}
