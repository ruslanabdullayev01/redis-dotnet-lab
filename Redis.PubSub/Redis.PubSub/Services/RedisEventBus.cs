using Redis.PubSub.Models;
using Redis.PubSub.Services.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.PubSub.Services;

public class RedisEventBus(IConnectionMultiplexer redis) : IEventBus
{
    private readonly ISubscriber _subscriber = redis.GetSubscriber();

    public async Task PublishAsync(string channel, EventMessage message)
    {
        var json = JsonSerializer.Serialize(message);

        await _subscriber.PublishAsync(RedisChannel.Literal(channel), json);
    }
}