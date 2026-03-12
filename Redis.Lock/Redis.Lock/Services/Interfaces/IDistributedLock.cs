namespace Redis.Lock.Services.Interfaces;

public interface IDistributedLock
{
    Task<string?> AcquireAsync(string key, TimeSpan expiry);
    Task ReleaseAsync(string key, string value);
}