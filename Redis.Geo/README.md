# Redis.Geo

Example implementation of **geo-spatial queries** using Redis.

Geo features allow storing and querying location-based data such as nearby drivers or stores.

---

## Pattern

Locations are stored in Redis with latitude and longitude coordinates.

Applications can query for nearby objects within a radius.

---

## Redis Commands Used

- GEOADD
- GEOSEARCH
- GEODIST

---

## Learning Purpose

This example demonstrates:

- geo indexing
- proximity search
- location-based queries
