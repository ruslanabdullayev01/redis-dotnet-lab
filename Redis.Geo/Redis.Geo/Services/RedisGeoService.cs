using Redis.Geo.Services.Interfaces;
using StackExchange.Redis;

namespace Redis.Geo.Services;

public class RedisGeoService(IConnectionMultiplexer redis) : IGeoService
{
    private const string GeoKey = "drivers:locations";

    private readonly IDatabase _db = redis.GetDatabase();

    public async Task SetDriverLocationAsync(string driverId, double longitude, double latitude)
    {
        await _db.GeoAddAsync(GeoKey, longitude, latitude, driverId);
    }

    public async Task<List<string>> GetNearbyDriversAsync(double longitude, double latitude, double radiusKm)
    {
        var results = await _db.GeoRadiusAsync(
            GeoKey,
            longitude,
            latitude,
            radiusKm,
            GeoUnit.Kilometers);

        return [.. results.Select(x => x.Member.ToString())];
    }

    public async Task<double?> GetDistanceAsync(string driver1, string driver2)
    {
        return await _db.GeoDistanceAsync(GeoKey, driver1, driver2, GeoUnit.Kilometers);
    }
}