# redis-dotnet-lab

![.NET](https://img.shields.io/badge/.NET-10-blue)
![Redis](https://img.shields.io/badge/Redis-In--Memory%20Database-red)
![Docker](https://img.shields.io/badge/Docker-Enabled-blue)
![License](https://img.shields.io/badge/License-MIT-green)

A practical collection of Redis patterns implemented with .NET and ASP.NET Core.

This repository demonstrates how Redis can be used in backend systems to solve common distributed architecture problems such as caching, rate limiting, queues, messaging, distributed locks, leaderboards, streams, and geo-based queries.

Each project focuses on a specific Redis pattern and provides a minimal implementation intended for learning and experimentation.


---

<p align="center">
  <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/redis/redis-original.svg" width="120">
  &nbsp;&nbsp;&nbsp;
  <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" width="120">
</p>

---

## Tech Stack

- .NET
- ASP.NET Core
- Redis
- StackExchange.Redis
- Docker / Docker Compose

---

## Repository Structure

Each project demonstrates a commonly used Redis pattern.

| Project | Pattern | Description |
|------|------|------|
| [Redis.Cache](./Redis.Cache) | Cache-Aside | Store frequently accessed data in Redis to reduce database load |
| [Redis.RateLimiter](./Redis.RateLimiter) | Rate Limiting | Protect APIs by limiting request rates |
| [Redis.Queue](./Redis.Queue) | Background Jobs | Implement job queues using Redis Lists |
| [Redis.PubSub](./Redis.PubSub) | Messaging | Event communication between services |
| [Redis.Lock](./Redis.Lock) | Distributed Lock | Prevent concurrent processing in distributed systems |
| [Redis.Leaderboard](./Redis.Leaderboard) | Sorted Sets | Ranking systems such as game leaderboards |
| [Redis.Streams](./Redis.Streams) | Event Streams | Durable event processing using Redis Streams |
| [Redis.Geo](./Redis.Geo) | Geo Spatial | Location-based queries such as nearby search |

Each project contains its own README with detailed explanations and examples.

---

## Getting Started

Clone the repository:


git clone https://github.com/ruslanabdullayev01/redis-dotnet-lab


Navigate to any example project:


cd Redis.Cache


Run the application and Redis using Docker Compose:


docker compose up -d --build


Redis will start automatically along with the example application.

---

## Redis Patterns Covered

This repository includes implementations of several important Redis patterns:

- Cache Aside
- Rate Limiting
- Background Job Queues
- Publish / Subscribe Messaging
- Distributed Locks
- Leaderboards (Sorted Sets)
- Event Streams (Redis Streams)
- Geo Spatial Queries

---

## Learning Goals

This project is intended to help developers:

- understand real-world Redis usage patterns
- learn how to integrate Redis with ASP.NET Core
- explore distributed system design techniques
- experiment with Redis data structures

---

## License

MIT
