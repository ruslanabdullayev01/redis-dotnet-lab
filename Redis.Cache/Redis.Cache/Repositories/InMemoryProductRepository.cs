using Redis.Cache.Models;
using Redis.Cache.Repositories.Interfaces;
using System.Collections.Concurrent;

namespace Redis.Cache.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly ConcurrentDictionary<int, Product> _products = new();

    public InMemoryProductRepository()
    {
        _products[1] = new Product { Id = 1, Name = "Laptop", Price = 1200 };
        _products[2] = new Product { Id = 2, Name = "Phone", Price = 800 };
        _products[3] = new Product { Id = 3, Name = "Headphones", Price = 200 };
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        _products.TryGetValue(id, out var product);
        return Task.FromResult(product);
    }

    public Task<List<Product>> GetAllAsync()
    {
        var allProducts = _products.Values.ToList();
        return Task.FromResult(allProducts);
    }

    public Task AddOrUpdateAsync(Product product)
    {
        _products[product.Id] = product;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        _products.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}