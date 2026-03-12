namespace Redis.Leaderboard.Models;

public sealed class LeaderboardEntry
{
    public required string UserId { get; set; }
    public double Score { get; set; }
    public long Rank { get; set; }
}