using Redis.Leaderboard.Models;

namespace Redis.Leaderboard.Services.Interfaces;

public interface ILeaderboardService
{
    Task AddScoreAsync(string userId, double score);
    Task<double?> GetScoreAsync(string userId);
    Task<long?> GetRankAsync(string userId);
    Task<List<LeaderboardEntry>> GetTopAsync(int count);
}