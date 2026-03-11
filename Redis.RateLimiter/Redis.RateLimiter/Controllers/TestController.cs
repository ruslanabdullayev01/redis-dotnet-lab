using Microsoft.AspNetCore.Mvc;

namespace Redis.RateLimiter.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "Request successful",
            time = DateTime.UtcNow
        });
    }
}