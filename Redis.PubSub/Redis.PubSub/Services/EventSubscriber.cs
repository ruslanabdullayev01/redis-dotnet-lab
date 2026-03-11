using Redis.PubSub.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.PubSub.Services;

public class EventSubscriber(
    IConnectionMultiplexer redis,
    ILogger<EventSubscriber> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var subscriber = redis.GetSubscriber();

        await subscriber.SubscribeAsync(RedisChannel.Pattern("events:*"), (channel, message) =>
        {
            var evt = JsonSerializer.Deserialize<EventMessage>(message.ToString());

            if (evt == null)
                return;

            logger.LogInformation($"Received event {evt.EventType} Data: {evt.Data}");
        });

        logger.LogInformation("Redis subscriber started");

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}