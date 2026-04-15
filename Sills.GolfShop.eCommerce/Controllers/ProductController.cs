using Microsoft.AspNetCore.Mvc;
using Sills.GolfShop.eCommerceAPI.DTO;
using Sills.GolfShop.eCommerceAPI.Helpers;
using Sills.GolfShop.eCommerceAPI.Models;
using Sills.GolfShop.eCommerceAPI.Services;

namespace Sills.GolfShop.eCommerceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController(IProductsService productsService) : ControllerBase
{
    private readonly IProductsService _productService = productsService;

    [HttpGet]
    public ActionResult<List<Product>> GetAllProducts(PaginationParameters param)
    {
        var products = _productService.GetAllProductsAsync().Result;
        var pagedProducts = products
            .Skip((param.PageNumber - 1) * param.PageSize)
            .Take(param.PageSize)
            .ToList();
        return Ok(products);
    }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
    {
        var existingProduct = _productService.GetProductByIdAsync(id).Result;
        if (existingProduct == null)
        {
            return NotFound();
        }
        existingProduct.Name = productUpdateDto.Name;
        existingProduct.Description = productUpdateDto.Description;
        existingProduct.QuantityInStock = productUpdateDto.QuantityInStock;

        await _productService.UpdateProductAsync(id, existingProduct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var existingProduct = _productService.GetProductByIdAsync(id).Result;
        if (existingProduct == null)
        {
            return NotFound();
        }
        _productService.DeleteProductAsync(id).Wait();

        return NoContent();
    }
}
