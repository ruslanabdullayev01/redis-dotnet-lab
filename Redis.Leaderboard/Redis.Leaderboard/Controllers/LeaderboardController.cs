using Microsoft.AspNetCore.Mvc;
using Redis.Leaderboard.Services.Interfaces;

namespace Redis.Leaderboard.Controllers;

[ApiController]
[Route("leaderboard")]
public class LeaderboardController(ILeaderboardService leaderboard) : ControllerBase
{
    [HttpPost("score")]
    public async Task<IActionResult> AddScore(string userId, double score)
    {
        await leaderboard.AddScoreAsync(userId, score);

        return Ok();
    }

    [HttpGet("score/{userId}")]
    public async Task<IActionResult> GetScore(string userId)
    {
        var score = await leaderboard.GetScoreAsync(userId);

        return Ok(score);
    }

    [HttpGet("rank/{userId}")]
    public async Task<IActionResult> GetRank(string userId)
    {
        var rank = await leaderboard.GetRankAsync(userId);

        return Ok(rank);
    }

    [HttpGet("top")]
    public async Task<IActionResult> GetTop(int count = 100)
    {
        var top = await leaderboard.GetTopAsync(count);

        return Ok(top);
    }
}