﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vshop.ProductApi.Dto;
using Vshop.ProductApi.Services;

namespace Vshop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductService _service;
    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto productDto)
    {
        if (productDto == null) return BadRequest();

            await _service.Create(productDto);

        return new CreatedAtRouteResult("GetProduct",
            new { id = productDto.Id }, productDto);

    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> Get()
    {
        var products = await _service.GetProducts();
        if (products == null)
        {
            return Ok("this list products is empty");
        }
        return Ok(products);
    }

    [HttpGet("{id}", Name ="GetProduct")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] int id)
    {
        var product = await _service.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<ProductDto>> Put(ProductDto prodDto)
    {

        if (prodDto == null)
        {
            return BadRequest("product data is not correct");
        }
        await _service.Update(prodDto);
        return Ok(prodDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var product = await _service.GetById(id);
        if (product == null)
        {
            return NotFound();
        }

        await _service.Remove(id);
        return NoContent();
    }

}
