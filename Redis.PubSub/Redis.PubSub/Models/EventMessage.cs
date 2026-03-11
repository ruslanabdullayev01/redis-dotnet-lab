namespace Redis.PubSub.Models;

public class EventMessage
{
    public string EventType { get; set; } = default!;

    public string Data { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}