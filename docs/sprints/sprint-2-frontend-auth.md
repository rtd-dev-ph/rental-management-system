# Sprint 2: Frontend Authentication

**Date**: July 25, 2026
**Status**: ✅ Complete

## Goal

Build React frontend with login, register, dashboard, and protected routes.

## User Stories

| ID     | Story                              | Status |
| ------ | ---------------------------------- | ------ |
| US-2.1 | Login page with form validation    | ✅     |
| US-2.2 | Register page with form validation | ✅     |
| US-2.3 | Auth context (global state)        | ✅     |
| US-2.4 | Protected routes                   | ✅     |
| US-2.5 | Auto-attach JWT to API requests    | ✅     |
| US-2.6 | Redirect after login/register      | ✅     |

## Pages Built

- ✅ `/login` - Email + password form with error handling
- ✅ `/register` - Full registration form
- ✅ `/dashboard` - Protected page showing user info + logout

## Components Created

- ✅ Input, Button, Alert (reusable UI)
- ✅ ProtectedRoute (auth guard)

## State Management

- ✅ AuthContext + AuthProvider (global auth state)
- ✅ useAuth hook (access auth from any component)
- ✅ Token persistence in localStorage

## Services

- ✅ Axios instance with base URL + interceptors
- ✅ Auth service (login, register, refresh API calls)

## Tech Used

- React 19, TypeScript, Vite, Tailwind CSS 4, React Router 7, Axios

## Lessons Learned

- Separate context, provider, and hook to avoid ESLint warnings
- Use HTTP for local dev on Ubuntu (not HTTPS)
- Axios interceptors handle token attachment and 401 redirects

## Next Sprint

**Sprint 3: Vehicle Management** - CRUD backend + frontend for vehicles
