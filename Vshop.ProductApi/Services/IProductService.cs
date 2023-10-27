using Vshop.ProductApi.Dto;


namespace Vshop.ProductApi.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetProducts();
    Task<ProductDto> GetById(int id);
    Task Create(ProductDto product);
    Task Update(ProductDto product);
    Task Remove(int id);
}
