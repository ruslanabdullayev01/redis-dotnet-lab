using Redis.Queue.Models;
using Redis.Queue.Services.Interfaces;

namespace Redis.Queue.Services;

public class JobWorker(IJobQueue queue, ILogger<JobWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Job worker started");

        while (!stoppingToken.IsCancellationRequested)
        {
            var job = await queue.DequeueAsync(stoppingToken);

            if (job == null)
            {
                await Task.Delay(500, stoppingToken);
                continue;
            }

            logger.LogInformation($"Processing job {job.Id} Type: {job.Type}");

            await ProcessJob(job);
        }
    }

    private static async Task ProcessJob(JobMessage job)
    {
        await Task.Delay(1000);
    }
}