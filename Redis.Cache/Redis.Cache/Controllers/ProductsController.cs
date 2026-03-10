using Microsoft.AspNetCore.Mvc;
using Redis.Cache.Models;
using Redis.Cache.Services.Interfaces;

namespace Redis.Cache.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet]
    public Task<List<Product>> GetAll() => service.GetProductsAsync();

    [HttpGet("{id}")]
    public Task<Product?> Get(int id) => service.GetProductAsync(id);

    [HttpPost]
    public Task<Product> Add(Product product) => service.AddOrUpdateProductAsync(product);

    [HttpPut("{id}")]
    public Task<Product> Update(int id, Product product)
    {
        product.Id = id;
        return service.AddOrUpdateProductAsync(product);
    }

    [HttpDelete("{id}")]
    public Task Delete([FromRoute] int id) => service.DeleteProductAsync(id);
}