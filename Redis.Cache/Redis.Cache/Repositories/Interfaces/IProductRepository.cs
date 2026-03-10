using Redis.Cache.Models;

namespace Redis.Cache.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddOrUpdateAsync(Product product);
    Task DeleteAsync(int id);
}