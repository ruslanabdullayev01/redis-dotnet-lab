using Redis.RateLimiter.Services.Interfaces;

namespace Redis.RateLimiter.Middlewares;

public class RateLimiterMiddleware(RequestDelegate next, IRateLimiterService rateLimiter, ILogger<RateLimiterMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        var key = $"rate_limit:{ip}";

        var allowed = await rateLimiter.IsAllowedAsync(key, 10, TimeSpan.FromSeconds(60));

        if (!allowed)
        {
            logger.LogWarning("Rate limit exceeded for {IP}", ip);

            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;

            await context.Response.WriteAsync("Too many requests");

            return;
        }

        await next(context);
    }
}