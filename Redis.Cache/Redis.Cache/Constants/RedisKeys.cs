namespace Redis.Cache.Constants;

public static class RedisKeys
{
    private const string Prefix = "redis-lab";

    public static string Product(int id)
        => $"{Prefix}:product:{id}";

    public static string Products()
        => $"{Prefix}:products:all";
}