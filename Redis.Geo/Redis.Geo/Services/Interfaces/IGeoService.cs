namespace Redis.Geo.Services.Interfaces;

public interface IGeoService
{
    Task SetDriverLocationAsync(string driverId, double longitude, double latitude);

    Task<List<string>> GetNearbyDriversAsync(double longitude, double latitude, double radiusKm);

    Task<double?> GetDistanceAsync(string driver1, string driver2);
}