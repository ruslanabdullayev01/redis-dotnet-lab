using Microsoft.AspNetCore.Mvc;
using Redis.Streams.Models;
using Redis.Streams.Services.Interfaces;

namespace Redis.Streams.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController(IStreamPublisher publisher) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(int orderId, decimal amount)
    {
        await publisher.PublishOrderCreatedAsync(
            new OrderCreatedEvent
            {
                OrderId = orderId,
                Amount = amount
            });

        return Ok("Order event published");
    }
}