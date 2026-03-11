namespace Redis.RateLimiter.Services.Interfaces;

public interface IRateLimiterService
{
    Task<bool> IsAllowedAsync(string key, int limit, TimeSpan window);
}