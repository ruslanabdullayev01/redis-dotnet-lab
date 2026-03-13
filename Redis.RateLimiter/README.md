# Redis.RateLimiter

Example implementation of **API Rate Limiting** using Redis.

Rate limiting protects APIs from abuse by restricting how many requests a client can perform within a specific time window.

---

## Pattern

This implementation uses a **fixed window counter**.

Each request increments a counter in Redis.

If the counter exceeds the allowed limit, the request is rejected.

---

## Redis Commands Used

- INCR
- EXPIRE

---

## Example

Client sends requests:


GET /api/resource


Redis counter:


rate:ip:127.0.0.1


If request count exceeds limit:


429 Too Many Requests


---

## Learning Purpose

This example demonstrates:

- API rate limiting
- Redis atomic counters
- request throttling
