# Redis.Queue

Example implementation of a **background job queue** using Redis Lists.

Queues are commonly used to process tasks asynchronously outside the main request pipeline.

---

## Pattern

Jobs are pushed into a Redis list.

Worker processes pull jobs from the queue and execute them.

---

## Redis Commands Used

- LPUSH
- BRPOP

---

## Example Flow

Producer:


LPUSH jobs email-task


Worker:


BRPOP jobs


---

## Learning Purpose

This example demonstrates:

- background job processing
- producer / consumer pattern
- asynchronous task execution
