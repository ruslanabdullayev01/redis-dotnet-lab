using Microsoft.Extensions.Options;
using Redis.RateLimiter.Options;
using Redis.RateLimiter.Services.Interfaces;

namespace Redis.RateLimiter.Middlewares;

public class RateLimiterMiddleware(
    RequestDelegate next,
    IRateLimiterService limiter,
    IRateLimitKeyGenerator keyGenerator,
    IOptions<RateLimiterOptions> options)
{
    private readonly RateLimiterOptions _options = options.Value;

    public async Task InvokeAsync(HttpContext context)
    {
        var key = keyGenerator.Generate(context);

        var window = TimeSpan.FromSeconds(_options.WindowSeconds);

        var allowed = await limiter.IsAllowedAsync(key, _options.Limit, window);

        if (!allowed)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;

            context.Response.Headers.RetryAfter = _options.WindowSeconds.ToString();

            await context.Response.WriteAsync("Rate limit exceeded");

            return;
        }

        context.Response.Headers["X-RateLimit-Limit"] = _options.Limit.ToString();

        await next(context);
    }
}