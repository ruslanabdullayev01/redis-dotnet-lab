using Redis.Streams.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.Streams.Services;

public class RedisStreamConsumer(
    IConnectionMultiplexer redis,
    ILogger<RedisStreamConsumer> logger)
    : BackgroundService
{
    private const string StreamKey = "stream:orders";
    private const string GroupName = "orders-group";
    private const string ConsumerName = "consumer-1";

    private readonly IDatabase _db = redis.GetDatabase();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await _db.StreamCreateConsumerGroupAsync(
                StreamKey,
                GroupName,
                "$",
                true);
        }
        catch
        {
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            var messages = await _db.StreamReadGroupAsync(
                StreamKey,
                GroupName,
                ConsumerName,
                ">");

            foreach (var message in messages)
            {
                var data = message.Values.First(v => v.Name == "data").Value;

                var evt = JsonSerializer.Deserialize<OrderCreatedEvent>(data.ToString());

                logger.LogInformation($"Order received: {evt?.OrderId} Amount: {evt?.Amount}");

                await _db.StreamAcknowledgeAsync(
                    StreamKey,
                    GroupName,
                    message.Id);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}