namespace Redis.RateLimiter.Services.Interfaces;

public interface IRateLimitKeyGenerator
{
    string Generate(HttpContext context);
}