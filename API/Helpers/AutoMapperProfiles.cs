using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + ' ' + src.LastName));
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<SalesPersonDto, SalesPerson>().ReverseMap();
            CreateMap<SaleDto, Sale>().ReverseMap();
            CreateMap<DiscountDto, Discount>().ReverseMap();
        }
    }
}