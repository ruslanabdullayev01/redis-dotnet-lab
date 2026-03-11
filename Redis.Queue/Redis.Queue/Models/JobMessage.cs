namespace Redis.Queue.Models;

public class JobMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Type { get; set; }

    public required string Payload { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}