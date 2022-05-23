using AutoMapper;
using CQRSMediatrWithFVAndAutoMapperSampleApplication.Product.Dto;

namespace CQRSMediatrWithFVAndAutoMapperSampleApplication.Product
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequestDto, ProductDto>()
                .AfterMap((_, dest) => dest.DateModified = DateTime.Now);
        }
    }
}
