# Sprint 3: Vehicle Management

**Date**: July 29, 2026
**Status**: ✅ Complete

## Goal

Full CRUD for vehicles with categories and soft delete.

## User Stories

| ID     | Story                   | Status |
| ------ | ----------------------- | ------ |
| US-3.1 | Create vehicle          | ✅     |
| US-3.2 | Get all vehicles        | ✅     |
| US-3.3 | Get vehicle by id       | ✅     |
| US-3.4 | Update vehicle          | ✅     |
| US-3.5 | Soft delete vehicle     | ✅     |
| US-3.6 | Vehicle categories CRUD | ✅     |

## API Endpoints

| Method | Endpoint              | Description       |
| ------ | --------------------- | ----------------- |
| GET    | /api/vehicle          | List all vehicles |
| GET    | /api/vehicle/{id}     | Get by id         |
| POST   | /api/vehicle          | Create vehicle    |
| PUT    | /api/vehicle/{id}     | Update vehicle    |
| DELETE | /api/vehicle/{id}     | Soft delete       |
| GET    | /api/vehicle/category | List categories   |
| POST   | /api/vehicle/category | Create category   |

## Database

- ✅ vehicle_categories (Id, Name, Description)
- ✅ vehicles (Brand, Model, Year, PlateNumber, DailyRate, Status, CategoryId, DeletedAt)
- ✅ Soft delete with query filter
- ✅ PlateNumber unique constraint (Brand NOT unique)

## Lessons Learned

- Always review database design after migration (\d table_name)
- Brand should NOT be unique (multiple vehicles same brand)
- PlateNumber SHOULD be unique
- Custom Response<T> pattern for consistent API responses
- HandleResponse in controller for clean response handling

## Next Sprint

**Sprint 4: Reservation System** - Booking, availability checks, approval workflow
