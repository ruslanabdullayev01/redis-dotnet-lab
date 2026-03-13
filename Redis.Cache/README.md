# Redis.Cache

Example implementation of the **Cache-Aside pattern** using Redis.

The Cache-Aside pattern is one of the most common caching strategies used in backend systems to reduce database load and improve performance.

---

## Pattern

Cache-Aside works as follows:

1. Application tries to read data from Redis
2. If data exists → return cached value
3. If data does not exist → fetch from database
4. Store the result in Redis
5. Return the data to the client

---

## Redis Commands Used

- GET
- SET
- EXPIRE

---

## Example Flow

Client request


GET /products/1


Application:


Redis → miss
Database → fetch data
Redis → cache result


Next request:


Redis → hit


---

## Learning Purpose

This example demonstrates:

- Cache-Aside pattern
- Redis key expiration
- caching database queries
