using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<List<Category>> GetProductsCategory();
        Task<Category> GetById(int id);
        Task<Category> Create(Category product);
        Task<Category> Update(Category product);
        Task<Category> Remove(int id);


    }
}
