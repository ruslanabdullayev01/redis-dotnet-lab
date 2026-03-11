using Microsoft.Extensions.Options;
using Redis.RateLimiter.Options;
using Redis.RateLimiter.Services.Interfaces;

namespace Redis.RateLimiter.Services;

public class RateLimitKeyGenerator(IOptions<RateLimiterOptions> options) : IRateLimitKeyGenerator
{
    private readonly RateLimiterOptions _options = options.Value;

    public string Generate(HttpContext context)
    {
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        var endpoint = context.Request.Path.ToString().ToLower();

        return $"{_options.KeyPrefix}:{ip}:{endpoint}";
    }
}