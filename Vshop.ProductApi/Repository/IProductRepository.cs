using Vshop.ProductApi.Data;
using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Repository;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<Product> GetById(int id);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Remove(int id);


}
