using Redis.Cache.Constants;
using Redis.Cache.Models;
using Redis.Cache.Repositories.Interfaces;
using Redis.Cache.Services.Interfaces;

namespace Redis.Cache.Services;

public class ProductService(
    ICacheService cache,
    IProductRepository repository,
    ILogger<ProductService> logger) : IProductService
{
    public async Task<List<Product>> GetProductsAsync()
    {
        var key = RedisKeys.Products();

        var products = await cache.GetOrSetAsync(
            key,
            async () =>
            {
                logger.LogInformation($"Cache MISS for {key}. Fetching products from database.");

                var result = await repository.GetAllAsync();

                logger.LogInformation($"Products fetched from database. Count: {result.Count}");

                return result;
            },
            TimeSpan.FromMinutes(10));

        logger.LogInformation($"GetProducts completed (CacheKey: {key})");

        return products ?? [];
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        var key = RedisKeys.Product(id);

        var product = await cache.GetOrSetAsync(
            key,
            async () =>
            {
                logger.LogInformation($"Cache MISS for {key}. Fetching product from database.");

                var result = await repository.GetByIdAsync(id);

                if (result == null)
                    logger.LogWarning($"Product {id} not found in database.");
                else
                    logger.LogInformation($"Product {id} fetched from database.");

                return result;
            },
            TimeSpan.FromMinutes(10));

        logger.LogInformation($"GetProduct {id} completed");

        return product;
    }

    public async Task<Product> AddOrUpdateProductAsync(Product product)
    {
        await repository.AddOrUpdateAsync(product);

        await InvalidateProductCacheAsync(product.Id);

        return product;
    }

    public async Task DeleteProductAsync(int id)
    {
        await repository.DeleteAsync(id);

        await InvalidateProductCacheAsync(id);
    }

    private async Task InvalidateProductCacheAsync(int id)
    {
        var key = RedisKeys.Product(id);
        await cache.RemoveAsync(key);
        logger.LogInformation("Cache invalidated for key {CacheKey}", key);

        var allKey = RedisKeys.Products();
        await cache.RemoveAsync(allKey);
        logger.LogInformation("Cache invalidated for key {CacheKey}", allKey);
    }
}