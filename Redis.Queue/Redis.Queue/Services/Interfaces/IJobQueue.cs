using Redis.Queue.Models;

namespace Redis.Queue.Services.Interfaces;

public interface IJobQueue
{
    Task EnqueueAsync(JobMessage job);

    Task<JobMessage?> DequeueAsync(CancellationToken cancellationToken);
}