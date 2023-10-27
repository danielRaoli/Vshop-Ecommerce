using AutoMapper;
using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Dto.Mappings;

public class MappingDtos : Profile
{
    public MappingDtos()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
