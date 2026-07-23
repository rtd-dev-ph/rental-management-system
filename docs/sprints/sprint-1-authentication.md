# Sprint 1: Authentication & User Management

**Planned Start**: After Sprint 0  
**Status**: ⬜ Not Started

## Goal

Users can register and login with JWT authentication.

## User Stories

| ID   | Story             | Status |
| ---- | ----------------- | ------ |
| US-1 | User Registration | ⬜     |
| US-2 | User Login        | ⬜     |
| US-3 | Token Refresh     | ⬜     |
| US-4 | Get User Profile  | ⬜     |

## API Endpoints (Planned)

| Method | Endpoint           | Description       |
| ------ | ------------------ | ----------------- |
| POST   | /api/auth/register | Register new user |
| POST   | /api/auth/login    | Login             |
| POST   | /api/auth/refresh  | Refresh token     |
| GET    | /api/auth/me       | Get profile       |

## Backend Tasks

- [ ] Create User domain entity
- [ ] Create Register endpoint
- [ ] Create Login endpoint
- [ ] Implement JWT generation
- [ ] Implement password hashing
- [ ] Add FluentValidation
- [ ] Test with Swagger

## Frontend Tasks

- [ ] Create login form
- [ ] Create register form
- [ ] Create auth context
- [ ] Set up protected routes
