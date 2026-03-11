using Redis.PubSub.Models;

namespace Redis.PubSub.Services.Interfaces;

public interface IEventBus
{
    Task PublishAsync(string channel, EventMessage message);
}