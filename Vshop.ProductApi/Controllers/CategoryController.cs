using Microsoft.AspNetCore.Mvc;
using Vshop.ProductApi.Dto;
using Vshop.ProductApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vshop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            var categories = await _service.GetAll();
            if(categories == null)
            {
                return Ok("the list of categories is empty");
            }
            return Ok(categories);
        }

        
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _service.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<CategoryDto>>> GetProductsCategory()
        {
            var categoriesProducts = await _service.GetProductsCategory();
            if(categoriesProducts == null)
            {
                return Ok("The list of categories is empty");
            }
            return Ok(categoriesProducts);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto categoryDto)
        {
            if(categoryDto == null)
            {
                return BadRequest("the category model is wrong");
            }
            await _service.Create(categoryDto);
            return Ok(categoryDto);
        }

        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDto>> Put(int id, [FromBody] CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("Id missmatch");
            }
            if (categoryDto == null)
            {
                return BadRequest("the category model is wrong");
            }
            await _service.Update(categoryDto);
            return Ok(categoryDto);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = _service.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            await _service.Remove(id);
            return NoContent();

        }
    }
}
