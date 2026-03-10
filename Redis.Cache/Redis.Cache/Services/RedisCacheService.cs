using Redis.Cache.Services.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.Cache.Services;

public class RedisCacheService(IConnectionMultiplexer redis, ILogger<RedisCacheService> logger) : ICacheService
{
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _db.StringGetAsync(key);

        if (!value.HasValue)
        {
            logger.LogInformation($"Cache MISS for {key}");
            return default;
        }

        logger.LogInformation($"Cache HIT for {key}");

        return JsonSerializer.Deserialize<T>(value.ToString());
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var json = JsonSerializer.Serialize(value);

        await _db.StringSetAsync(key, json, expiry, When.Always);
    }

    public async Task RemoveAsync(string key)
    {
        await _db.KeyDeleteAsync(key);
    }

    public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiry = null)
    {
        var cached = await GetAsync<T>(key);

        if (cached != null)
        {
            Console.WriteLine("Cache HIT");
            return cached;
        }

        Console.WriteLine("Cache MISS");

        var value = await factory();

        if (value != null)
            await SetAsync(key, value, expiry);

        return value;
    }
}