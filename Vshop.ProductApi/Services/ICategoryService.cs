using AutoMapper;
using Vshop.ProductApi.Dto;
using Vshop.ProductApi.Repository;

namespace Vshop.ProductApi.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAll();
    Task<List<CategoryDto>> GetProductsCategory();
    Task<CategoryDto> GetById(int id);
    Task Create(CategoryDto categoryDto);
    Task Update(CategoryDto categoryDto);
    Task Remove(int id);
}
