using VshopWeb.Models;

namespace VshopWeb.Contracts
{
    public interface IServiceProduct
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();

        Task<ProductViewModel> GetProductById(int id);

        Task<ProductViewModel> CreateProduct(ProductViewModel productVm);

        Task<ProductViewModel> UpdateProduct(ProductViewModel productVm);
        Task<bool> DeleteProduct(int id);

    }
}
