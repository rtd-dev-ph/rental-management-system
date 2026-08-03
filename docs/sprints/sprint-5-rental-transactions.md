# Sprint 5: Rental Transactions

**Start Date**: Aug 3, 2026  
**Status**: 🟡 In Progress

## Goal

Track vehicle pickup and return, update vehicle status, calculate rental duration.

## User Stories

| ID     | Story                         | Priority | Status |
| ------ | ----------------------------- | -------- | ------ |
| US-5.1 | Pickup vehicle (start rental) | P0       | ⬜     |
| US-5.2 | Return vehicle (end rental)   | P0       | ⬜     |
| US-5.3 | View active rentals           | P1       | ⬜     |
| US-5.4 | View rental history           | P1       | ⬜     |

## API Endpoints

| Method | Endpoint                            | Description    |
| ------ | ----------------------------------- | -------------- |
| POST   | /api/rentals/{reservationId}/pickup | Start rental   |
| POST   | /api/rentals/{id}/return            | End rental     |
| GET    | /api/rentals/active                 | Active rentals |
| GET    | /api/rentals                        | Rental history |

## Database Tables

- rental_transactions
