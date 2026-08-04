# Sprint 5: Rental Transactions

**Date**: Aug 4, 2026  
**Status**: ✅ Complete

## Goal

Track vehicle pickup and return, manage rental lifecycle.

## User Stories

| ID     | Story                         | Status |
| ------ | ----------------------------- | ------ |
| US-5.1 | Pickup vehicle (start rental) | ✅     |
| US-5.2 | Return vehicle (end rental)   | ✅     |
| US-5.3 | Approve reservation           | ✅     |
| US-5.4 | View active rentals           | ✅     |
| US-5.5 | View rental history           | ✅     |

## API Endpoints

| Method | Endpoint                           | Description     |
| ------ | ---------------------------------- | --------------- |
| POST   | /api/rental/{reservationId}/pickup | Start rental    |
| POST   | /api/rental/{rentalId}/return      | End rental      |
| PUT    | /api/reservation/{id}/approve      | Approve booking |
| GET    | /api/rental/active                 | Active rentals  |
| GET    | /api/rental                        | Rental history  |

## Flow

Pending → Approved → Pickup (Rented) → Return (Completed)
↓ ↓
Vehicle: Rented Vehicle: Available

## Database

- ✅ rental_transactions (ReservationId, VehicleId, PickupDate, ReturnDate, Status)
