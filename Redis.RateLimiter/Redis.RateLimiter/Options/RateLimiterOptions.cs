namespace Redis.RateLimiter.Options;

public class RateLimiterOptions
{
    public int Limit { get; set; } = 20;
    public int WindowSeconds { get; set; } = 60;
    public string KeyPrefix { get; set; } = "rate_limit";
}