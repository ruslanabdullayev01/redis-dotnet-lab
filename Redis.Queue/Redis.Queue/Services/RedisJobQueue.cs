using Redis.Queue.Models;
using Redis.Queue.Services.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.Queue.Services;

public class RedisJobQueue(IConnectionMultiplexer redis) : IJobQueue
{
    private const string QueueKey = "jobs";

    private readonly IDatabase _db = redis.GetDatabase();

    public async Task EnqueueAsync(JobMessage job)
    {
        var json = JsonSerializer.Serialize(job);

        await _db.ListLeftPushAsync(QueueKey, json);
    }

    public async Task<JobMessage?> DequeueAsync(CancellationToken cancellationToken)
    {
        var result = await _db.ListRightPopAsync(QueueKey);

        if (result.IsNullOrEmpty)
            return null;

        return JsonSerializer.Deserialize<JobMessage>(result.ToString());
    }
}