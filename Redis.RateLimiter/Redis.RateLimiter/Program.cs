using Redis.RateLimiter.Middlewares;
using Redis.RateLimiter.Services;
using Redis.RateLimiter.Services.Interfaces;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = builder.Configuration["Redis:ConnectionString"]
        ?? throw new InvalidOperationException("Redis connection string is not configured.");

    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddSingleton<IRateLimiterService, RedisRateLimiterService>();

var app = builder.Build();

app.UseMiddleware<RateLimiterMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
