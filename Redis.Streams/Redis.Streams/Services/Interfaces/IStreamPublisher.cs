using Redis.Streams.Models;

namespace Redis.Streams.Services.Interfaces;

public interface IStreamPublisher
{
    Task PublishOrderCreatedAsync(OrderCreatedEvent evt);
}