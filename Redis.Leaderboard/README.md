# Redis.Leaderboard

Example implementation of a **leaderboard system** using Redis Sorted Sets.

Leaderboards are commonly used in gaming systems, ranking systems, and scoring platforms.

---

## Pattern

Redis stores scores in a Sorted Set.

Members are automatically sorted by score.

---

## Redis Commands Used

- ZADD
- ZINCRBY
- ZREVRANGE
- ZRANK

---

## Example


ZADD leaderboard 100 user1
ZADD leaderboard 250 user2


Top players:


ZREVRANGE leaderboard 0 10


---

## Learning Purpose

This example demonstrates:

- Redis sorted sets
- ranking systems
- score aggregation
