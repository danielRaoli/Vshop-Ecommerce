using AutoMapper;
using Vshop.ProductApi.Dto;
using Vshop.ProductApi.Models;
using Vshop.ProductApi.Repository;

namespace Vshop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task Create(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.Create(product);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task Remove(int id)
        {
            await _productRepository.Remove(id);
        }

        public async Task Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.Update(product);
        }
    }
}
