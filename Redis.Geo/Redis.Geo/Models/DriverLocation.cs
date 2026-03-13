namespace Redis.Geo.Models;

public sealed class DriverLocation
{
    public required string DriverId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}