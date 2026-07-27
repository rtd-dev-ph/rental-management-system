# Sprint 3: Vehicle Management

**Start Date**: July 27, 2026
**Status**: 🟡 In Progress

## Goal

Full CRUD for vehicles with categories, images, and status tracking.

## User Stories

| ID     | Story                       | Priority | Status |
| ------ | --------------------------- | -------- | ------ |
| US-3.1 | Create vehicle with details | P0       | ⬜     |
| US-3.2 | Get all vehicles (list)     | P0       | ⬜     |
| US-3.3 | Get vehicle by id           | P0       | ⬜     |
| US-3.4 | Update vehicle              | P1       | ⬜     |
| US-3.5 | Delete/Archive vehicle      | P1       | ⬜     |
| US-3.6 | Vehicle categories          | P0       | ⬜     |
| US-3.7 | Vehicle status tracking     | P1       | ⬜     |

## API Endpoints (Planned)

| Method | Endpoint           | Description       |
| ------ | ------------------ | ----------------- |
| POST   | /api/vehicles      | Create vehicle    |
| GET    | /api/vehicles      | List all vehicles |
| GET    | /api/vehicles/{id} | Get by id         |
| PUT    | /api/vehicles/{id} | Update vehicle    |
| DELETE | /api/vehicles/{id} | Soft delete       |
| GET    | /api/categories    | List categories   |
| POST   | /api/categories    | Create category   |

## Database Tables (Planned)

- vehicle_categories
- vehicles
- vehicle_images

## Notes

- Add ValidationBehavior to MediatR pipeline
- Vehicle status: Available, Rented, Maintenance, Archived
