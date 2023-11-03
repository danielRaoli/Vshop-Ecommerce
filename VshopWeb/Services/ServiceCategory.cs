using System.Text;
using System.Text.Json;
using VshopWeb.Contracts;
using VshopWeb.Models;

namespace VshopWeb.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private CategoryViewModel _categoryViewModel;
        private IEnumerable<CategoryViewModel> _categories;
        private const string _endpoint = "/api/category/";
        public ServiceCategory(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<CategoryViewModel> CreateCategory(CategoryViewModel categoryVm)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            StringContent categoryContent = new StringContent(JsonSerializer.Serialize(categoryVm), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(_endpoint, categoryContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    var postContent = await response.Content.ReadAsStreamAsync();
                    _categoryViewModel = await JsonSerializer.DeserializeAsync<CategoryViewModel>(postContent, _options);

                }
                else
                {
                    return null;
                }
            }

            return _categoryViewModel;

        }

        public async Task<bool> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            using (var response = await client.DeleteAsync(_endpoint + id))
            {
                if (response.IsSuccessStatusCode) { return true; }

            }
            return false;
        }
        public async Task<CategoryViewModel> GetCategory(int id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(_endpoint + id))
            {
                if (!response.IsSuccessStatusCode) { return null; }
                var responseContent = await response.Content.ReadAsStreamAsync();
                _categoryViewModel = await JsonSerializer.DeserializeAsync<CategoryViewModel>(responseContent, _options);
            }
            return _categoryViewModel;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            using (var response = await client.GetAsync(_endpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStreamAsync();
                    _categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(responseContent, _options);
                    
                }
                else
                {
                    return null;
                }

            }
            return _categories;
        }



        public async Task<IEnumerable<CategoryViewModel>> GetProductsCategory()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            using (var response = await client.GetAsync(_endpoint + "products"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var responseContent = await response.Content.ReadAsStreamAsync();
                _categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(responseContent, _options);
            }
            return _categories;


        }

        public async Task<CategoryViewModel> UpdateCategory(CategoryViewModel categoryVm)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            CategoryViewModel categoryUpdated = new CategoryViewModel();

            using (var response = await client.PutAsJsonAsync(_endpoint, categoryVm))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var responseContent = await response.Content.ReadAsStreamAsync();
                categoryUpdated = await JsonSerializer.DeserializeAsync<CategoryViewModel>(responseContent, _options);
            }
            return categoryUpdated;
        }
    }
}
