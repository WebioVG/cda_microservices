using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Services;

namespace ProductService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductsService productsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await productsService.GetAllAsync();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await productsService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(Product product)
    {
        await productsService.CreateAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id) return BadRequest();
        await productsService.UpdateAsync(product);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        await productsService.DeleteAsync(id);
        return NoContent();
    }
}