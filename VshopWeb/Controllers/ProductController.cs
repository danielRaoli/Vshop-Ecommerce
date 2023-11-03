using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using VshopWeb.Contracts;
using VshopWeb.Models;

namespace VshopWeb.Controllers;

public class ProductController : Controller
{
    private readonly IServiceProduct _serviceProduct;
    private readonly IServiceCategory _serviceCategory;

    public ProductController(IServiceProduct serviceProduct, IServiceCategory serviceCategory)
    {
        _serviceProduct = serviceProduct;
        _serviceCategory = serviceCategory;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
    {
        var result = await _serviceProduct.GetProducts();
        if (result != null)
        {
            return View(result);
        }
        return View("Error");

    }

    [HttpGet]
    public async Task<ActionResult> Create()
    {
        ViewBag.Id = new SelectList(await _serviceCategory.GetCategories(), "Id", "Name");
        return View();
    }

    [HttpGet]
    public async Task<ActionResult<ProductViewModel>> DeleteProduct(int id)
    {
        var product = await _serviceProduct.GetProductById(id);
        if(product == null) {
            View("Error");
        }
        return View(product);
    }

    [HttpGet]
    public async Task<ActionResult<ProductViewModel>> UpdateProduct(int id)
    {
        var product = await _serviceProduct.GetProductById(id);   
        if(product == null)
        {
            return View("Error");
        }
        ViewBag.Id = new SelectList(await _serviceCategory.GetCategories(), "Id", "Name");
        return View(product);

    }


    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Create(ProductViewModel productVm)
    {
        if (ModelState.IsValid)
        {
            var result = await _serviceProduct.CreateProduct(productVm);

            if (result != null) return RedirectToAction(nameof(Index));

        }
        ViewBag.Id = new SelectList(await _serviceCategory.GetCategories(), "Id", "Name");
        return View("Create", productVm);

    }

    [HttpPost]
    public async Task<ActionResult> UpdateProduct(ProductViewModel productVm)
    {
        if (!ModelState.IsValid)
        {
            return View("UpdateProduct", productVm);
        }
        var result = await _serviceProduct.UpdateProduct(productVm);
        if(result == null)
        {
            return View("Error");
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ActionName("DeleteProduct")]
    public async Task<ActionResult> ConfirmDeleteProduct(int id)
    {
      var result =  await _serviceProduct.DeleteProduct(id);
        if (result)
        {
            return RedirectToAction(nameof(Index));
        }
        return View("Error");


    }


}
