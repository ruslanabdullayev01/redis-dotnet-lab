# Redis.Streams

Example implementation of **event streaming** using Redis Streams.

Streams allow building durable event pipelines similar to lightweight message brokers.

---

## Pattern

Events are appended to a Redis Stream.

Consumers process events using consumer groups.

---

## Redis Commands Used

- XADD
- XREADGROUP
- XACK

---

## Learning Purpose

This example demonstrates:

- event streaming
- consumer groups
- scalable event processing
