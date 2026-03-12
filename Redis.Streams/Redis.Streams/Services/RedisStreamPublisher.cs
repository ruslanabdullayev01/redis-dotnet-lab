using Redis.Streams.Models;
using Redis.Streams.Services.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.Streams.Services;

public class RedisStreamPublisher(IConnectionMultiplexer redis) : IStreamPublisher
{
    private const string StreamKey = "stream:orders";

    private readonly IDatabase _db = redis.GetDatabase();

    public async Task PublishOrderCreatedAsync(OrderCreatedEvent evt)
    {
        var json = JsonSerializer.Serialize(evt);

        await _db.StreamAddAsync(
            StreamKey,
            [
                new("type", "order-created"),
                new("data", json)
            ]);
    }
}