using Redis.RateLimiter.Services.Interfaces;
using StackExchange.Redis;

namespace Redis.RateLimiter.Services;

public class RedisRateLimiterService(IConnectionMultiplexer redis) : IRateLimiterService
{
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task<bool> IsAllowedAsync(string key, int limit, TimeSpan window)
    {
        var current = await _db.StringIncrementAsync(key);

        if (current == 1)
        {
            await _db.KeyExpireAsync(key, window);
        }

        return current <= limit;
    }
}