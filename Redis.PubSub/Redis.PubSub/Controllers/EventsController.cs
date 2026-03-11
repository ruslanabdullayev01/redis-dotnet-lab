using Microsoft.AspNetCore.Mvc;
using Redis.PubSub.Models;
using Redis.PubSub.Services.Interfaces;

namespace Redis.PubSub.Controllers;

[ApiController]
[Route("events")]
public class EventsController(IEventBus bus) : ControllerBase
{
    [HttpPost("user-created")]
    public async Task<IActionResult> UserCreated()
    {
        var evt = new EventMessage
        {
            EventType = "user.created",
            Data = "UserId:123"
        };

        await bus.PublishAsync("events:user.created", evt);

        return Ok("Event published");
    }
}