# Sprint 2: Frontend Authentication

**Start Date**: July 24, 2026
**Status**: 🟡 In Progress

## Goal

Build React frontend with login, register, and protected routes.

## User Stories

| ID     | Story                              | Status |
| ------ | ---------------------------------- | ------ |
| US-2.1 | Login page with form validation    | ⬜     |
| US-2.2 | Register page with form validation | ⬜     |
| US-2.3 | Auth context (store user state)    | ⬜     |
| US-2.4 | Protected routes                   | ⬜     |
| US-2.5 | Auto-attach JWT to requests        | ⬜     |
| US-2.6 | Redirect after login               | ⬜     |

## Tech Stack

- React 19 + TypeScript
- Vite (build tool)
- Tailwind CSS 4
- React Router 7
- Axios (HTTP client)
- React Query (server state)

## Tasks

### Setup

- [ ] Scaffold React app with Vite
- [ ] Install dependencies
- [ ] Configure Tailwind CSS
- [ ] Set up folder structure

### Pages

- [ ] Login page (`/login`)
- [ ] Register page (`/register`)
- [ ] Dashboard page (`/dashboard`) - placeholder
- [ ] Unauthorized page (`/unauthorized`)

### Components

- [ ] AuthLayout (centered card layout)
- [ ] ProtectedRoute wrapper
- [ ] Input component
- [ ] Button component
- [ ] Alert/Error component

### Services

- [ ] API service (axios instance)
- [ ] Auth service (login, register, refresh)
- [ ] Token interceptor

### State

- [ ] AuthContext (user, tokens, login/logout)
- [ ] Token persistence (localStorage)

## Notes

- Backend API already running at https://localhost:5001
- JWT tokens expire in 15 minutes
- Refresh token flow to be implemented
