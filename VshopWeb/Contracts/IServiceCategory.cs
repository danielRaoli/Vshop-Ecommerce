using VshopWeb.Models;

namespace VshopWeb.Contracts
{
    public interface IServiceCategory
    {
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task<IEnumerable<CategoryViewModel>> GetProductsCategory();

        Task<CategoryViewModel> GetCategory(int id);

        Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryVm);

        Task<CategoryViewModel> UpdateCategory(CategoryViewModel categoryVm);
        Task<bool> DeleteCategory(int id);
    }
}
