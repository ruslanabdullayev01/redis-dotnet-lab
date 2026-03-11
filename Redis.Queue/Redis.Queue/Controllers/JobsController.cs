using Microsoft.AspNetCore.Mvc;
using Redis.Queue.Models;
using Redis.Queue.Services.Interfaces;

namespace Redis.Queue.Controllers;

[ApiController]
[Route("jobs")]
public class JobsController(IJobQueue queue) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Enqueue(JobMessage job)
    {
        await queue.EnqueueAsync(job);

        return Ok(new
        {
            message = "Job added to queue",
            job.Id
        });
    }
}