using Microsoft.AspNetCore.Mvc;
using VshopWeb.Contracts;
using VshopWeb.Models;

namespace VshopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceCategory _serviceCategory;

        public CategoryController(IServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Index()
        {
            var result = await _serviceCategory.GetCategories();
            if(result != null)
            {
                return View(result);
            }
            return View("Error");
        }
    }
}
