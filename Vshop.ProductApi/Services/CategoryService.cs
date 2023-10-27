using AutoMapper;
using Vshop.ProductApi.Dto;
using Vshop.ProductApi.Models;
using Vshop.ProductApi.Repository;

namespace Vshop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryrepository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryrepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Create(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryrepository.Create(category);
            categoryDto.Id = category.Id;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _categoryrepository.GetAll();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDto;

        }

        public async Task<CategoryDto> GetById(int id)
        {
            var product = await _categoryrepository.GetById(id);
            var productDto = _mapper.Map<CategoryDto>(product);
            return productDto;
        }

        public async Task<List<CategoryDto>> GetProductsCategory()
        {
            var productsCategories = await _categoryrepository.GetProductsCategory();
            var productsCatDto = _mapper.Map<List<CategoryDto>>(productsCategories);
            return productsCatDto;
        }

        public async Task Remove(int id)
        {
            await _categoryrepository.Remove(id);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryrepository.Update(category);
        }
    }
}
