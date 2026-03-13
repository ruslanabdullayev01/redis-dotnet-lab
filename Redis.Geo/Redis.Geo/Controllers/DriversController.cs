using Microsoft.AspNetCore.Mvc;
using Redis.Geo.Services.Interfaces;

namespace Redis.Geo.Controllers;

[ApiController]
[Route("drivers")]
public class DriversController(IGeoService geoService) : ControllerBase
{
    [HttpPost("location")]
    public async Task<IActionResult> SetLocation(string driverId, double latitude, double longitude)
    {
        await geoService.SetDriverLocationAsync(driverId, longitude, latitude);

        return Ok("Location updated");
    }

    [HttpGet("nearby")]
    public async Task<IActionResult> GetNearby(double latitude, double longitude, double radiusKm)
    {
        var drivers = await geoService.GetNearbyDriversAsync(longitude, latitude, radiusKm);

        return Ok(drivers);
    }

    [HttpGet("distance")]
    public async Task<IActionResult> GetDistance(string driver1, string driver2)
    {
        var distance = await geoService.GetDistanceAsync(driver1, driver2);

        return Ok(distance);
    }
}