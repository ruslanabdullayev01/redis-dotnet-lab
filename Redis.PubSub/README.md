# Redis.PubSub

Example implementation of **Publish / Subscribe messaging** using Redis.

Pub/Sub enables services to communicate through events without direct coupling.

---

## Pattern

One service publishes an event.

Multiple subscribers can receive the event.

---

## Redis Commands Used

- PUBLISH
- SUBSCRIBE

---

## Example Flow

Publisher:


PUBLISH events:user.created


Subscribers receive the event in real time.

---

## Learning Purpose

This example demonstrates:

- event-driven communication
- loosely coupled services
- real-time messaging
