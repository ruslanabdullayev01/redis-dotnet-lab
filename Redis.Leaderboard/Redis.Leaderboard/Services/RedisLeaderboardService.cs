using Redis.Leaderboard.Models;
using Redis.Leaderboard.Services.Interfaces;
using StackExchange.Redis;

namespace Redis.Leaderboard.Services;

public class RedisLeaderboardService(IConnectionMultiplexer redis) : ILeaderboardService
{
    private const string LeaderboardKey = "leaderboard:global";

    private readonly IDatabase _db = redis.GetDatabase();

    public async Task AddScoreAsync(string userId, double score)
    {
        await _db.SortedSetIncrementAsync(
            LeaderboardKey,
            userId,
            score);
    }

    public async Task<double?> GetScoreAsync(string userId)
    {
        return await _db.SortedSetScoreAsync(
            LeaderboardKey,
            userId);
    }

    public async Task<long?> GetRankAsync(string userId)
    {
        return await _db.SortedSetRankAsync(
            LeaderboardKey,
            userId,
            Order.Descending);
    }

    public async Task<List<LeaderboardEntry>> GetTopAsync(int count)
    {
        var entries = await _db.SortedSetRangeByRankWithScoresAsync(
            LeaderboardKey,
            0,
            count - 1,
            Order.Descending);

        var result = new List<LeaderboardEntry>();

        for (int i = 0; i < entries.Length; i++)
        {
            result.Add(new LeaderboardEntry
            {
                UserId = entries[i].Element!,
                Score = entries[i].Score,
                Rank = i + 1
            });
        }

        return result;
    }
}