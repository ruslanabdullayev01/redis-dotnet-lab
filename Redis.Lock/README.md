# Redis.Lock

Example implementation of a **Distributed Lock** using Redis.

Distributed locks prevent multiple processes from executing the same critical operation simultaneously.

---

## Pattern

Application attempts to acquire a lock in Redis.

If the lock already exists, another process is already executing the operation.

---

## Redis Commands Used

- SET NX
- DEL

---

## Example


lock:update:order:123


Only one instance can process the update at a time.

---

## Learning Purpose

This example demonstrates:

- distributed synchronization
- preventing race conditions
- coordinating multiple services

This example demonstrates:

- Redis sorted sets
- ranking systems
- score aggregation
