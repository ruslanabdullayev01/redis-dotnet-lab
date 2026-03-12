using Redis.Lock.Services.Interfaces;
using StackExchange.Redis;

namespace Redis.Lock.Services;

public class RedisDistributedLock(IConnectionMultiplexer redis) : IDistributedLock
{
    private readonly IDatabase _db = redis.GetDatabase();

    public async Task<string?> AcquireAsync(string key, TimeSpan expiry)
    {
        var token = Guid.NewGuid().ToString();

        var acquired = await _db.StringSetAsync(
            key,
            token,
            expiry,
            When.NotExists);

        return acquired ? token : null;
    }

    public async Task ReleaseAsync(string key, string value)
    {
        var current = await _db.StringGetAsync(key);

        if (current == value)
        {
            await _db.KeyDeleteAsync(key);
        }
    }
}