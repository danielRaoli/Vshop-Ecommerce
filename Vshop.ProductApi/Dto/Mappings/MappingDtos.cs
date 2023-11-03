using AutoMapper;
using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Dto.Mappings;

public class MappingDtos : Profile
{
    public MappingDtos()
    {
        CreateMap<Product, ProductDto>().ForMember(p => p.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<ProductDto, Product>();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
