# Sprint 4: Reservation System

**Date**: July 30, 2026  
**Status**: 🟡 Completed

## Goal

Allow customers to book vehicles with availability checks and date validation.

## User Stories

| ID     | Story                      | Priority | Status |
| ------ | -------------------------- | -------- | ------ |
| US-4.1 | Create reservation         | P0       | ⬜     |
| US-4.2 | Check vehicle availability | P0       | ⬜     |
| US-4.3 | Prevent double booking     | P0       | ⬜     |
| US-4.4 | View all reservations      | P1       | ⬜     |
| US-4.5 | Cancel reservation         | P1       | ⬜     |
| US-4.6 | Approve/reject reservation | P2       | ⬜     |

## Database Tables (Planned)

- reservations (VehicleId, CustomerId, StartDate, EndDate, Status, TotalAmount)
- rental_transactions (future sprint)

## API Endpoints (Planned)

| Method | Endpoint                        | Description        |
| ------ | ------------------------------- | ------------------ |
| POST   | /api/reservations               | Create reservation |
| GET    | /api/reservations               | List reservations  |
| GET    | /api/reservations/{id}          | Get by id          |
| PUT    | /api/reservations/{id}/cancel   | Cancel             |
| GET    | /api/vehicles/{id}/availability | Check dates        |
