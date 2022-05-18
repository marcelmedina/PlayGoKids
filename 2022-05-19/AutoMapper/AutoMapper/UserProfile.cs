using AutoMapper;
using AutoMapperDemo.Models;
using AutoMapperDemo.ViewModel;

namespace AutoMapperDemo
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<User, UserNameViewModel>()
                .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ReverseMap()
                .AfterMap((dest, src) =>
                {
                    dest.DateCreated = DateTime.Now;
                });

            CreateMap<UserAddress, UserAddressViewModel>();
        }
    }
}
