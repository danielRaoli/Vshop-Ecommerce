using System.Text;
using System.Text.Json;
using VshopWeb.Contracts;
using VshopWeb.Models;

namespace VshopWeb.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IHttpClientFactory _httpClient;
        private const string endpoint = "/api/product/";
        private readonly JsonSerializerOptions _options;
        private ProductViewModel _productVm;
        private IEnumerable<ProductViewModel> _productsVm;

        public ServiceProduct(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productVm)
        {
            var client = _httpClient.CreateClient("ProductApi");

            StringContent contentProduct = new StringContent(JsonSerializer.Serialize(productVm), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(endpoint, contentProduct))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    _productVm = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return _productVm;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var client = _httpClient.CreateClient("ProductApi");
            using (var response = await client.DeleteAsync(endpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var client = _httpClient.CreateClient("ProductApi");
            using (var response = await client.GetAsync(endpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var productResponse = await response.Content.ReadAsStreamAsync();
                    _productVm = await JsonSerializer.DeserializeAsync<ProductViewModel>(productResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return _productVm;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var client = _httpClient.CreateClient("ProductApi");
            using (var response = await client.GetAsync(endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    _productsVm = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return _productsVm;
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel productVm)
        {
            var client = _httpClient.CreateClient("ProductApi");
            ProductViewModel productUpdate = new ProductViewModel();
            using (var response = await client.PutAsJsonAsync(endpoint, productVm))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUpdate = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);

                }
                else
                {
                    return null;
                }
            }
            return productUpdate;
        }
    }
}
