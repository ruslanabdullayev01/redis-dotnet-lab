# redis-dotnet-lab

A collection of Redis usage patterns implemented with .NET and ASP.NET Core.

This repository demonstrates how Redis can be used in backend applications for common distributed system scenarios.

Each project focuses on a specific Redis pattern and provides a minimal implementation intended for learning and experimentation.

---

## Tech Stack

- .NET
- ASP.NET Core
- Redis
- StackExchange.Redis
- Docker

---

## Repository Structure

Each project demonstrates a specific Redis pattern.

- [Redis.Cache](./Redis.Cache)  
  Cache-Aside pattern implementation.

- [Redis.RateLimiter](./Redis.RateLimiter)  
  API rate limiting using Redis counters.

- [Redis.Queue](./Redis.Queue)  
  Background job queue using Redis Lists.

- [Redis.PubSub](./Redis.PubSub)  
  Publish/Subscribe messaging between services.

- [Redis.Lock](./Redis.Lock)  
  Distributed locking with Redis.

- [Redis.Leaderboard](./Redis.Leaderboard)  
  Leaderboard implementation using Redis Sorted Sets.

Detailed documentation for each example is located inside the corresponding project folder.

---

## Getting Started

Clone the repository:


git clone https://github.com/ruslanabdullayev01/redis-dotnet-lab


Navigate to any example project:


cd Redis.Cache


Run the application:


docker compose up -d --build

---

## Learning Goals

This repository helps developers:

- understand common Redis usage patterns
- learn how to integrate Redis with ASP.NET Core
- explore practical distributed system techniques

---

## License

MIT