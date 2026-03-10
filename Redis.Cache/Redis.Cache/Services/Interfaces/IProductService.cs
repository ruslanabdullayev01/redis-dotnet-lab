using Redis.Cache.Models;

namespace Redis.Cache.Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product?> GetProductAsync(int id);
    Task<Product> AddOrUpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}