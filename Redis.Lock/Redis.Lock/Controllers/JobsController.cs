using Microsoft.AspNetCore.Mvc;
using Redis.Lock.Services.Interfaces;

namespace Redis.Lock.Controllers;

[ApiController]
[Route("jobs")]
public class JobsController(IDistributedLock distributedLock) : ControllerBase
{
    [HttpPost("process")]
    public async Task<IActionResult> Process()
    {
        var key = "lock:process-job";

        var token = await distributedLock.AcquireAsync(
            key,
            TimeSpan.FromSeconds(30));

        if (token == null)
            return Conflict("Job already running");

        try
        {
            Console.WriteLine("Job started");

            await Task.Delay(5000);

            Console.WriteLine("Job finished");

            return Ok("Job executed");
        }
        finally
        {
            await distributedLock.ReleaseAsync(key, token);
        }
    }
}