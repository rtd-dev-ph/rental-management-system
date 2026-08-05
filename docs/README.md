# 🏍️ Rental Management System

A full-stack rental management system built with .NET 10, React, and PostgreSQL. Designed for motorcycle and car rental businesses.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-19-61DAFB?logo=react)](https://react.dev/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-4169E1?logo=postgresql)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-✓-2496ED?logo=docker)](https://www.docker.com/)

---

## ✨ Features

- 🔐 JWT Authentication with refresh tokens
- 👥 Role-based access (Owner, Admin, Staff, Customer)
- 🚗 Vehicle management with categories
- 📅 Reservation system with availability checking
- 🔄 Rental lifecycle (pickup/return)
- 📊 Dashboard & reports
- 🗑️ Soft delete for data integrity
- 📝 Audit logging

## 🏗️ Architecture

├── src/
│ ├── RMS.Api/ # ASP.NET Core Web API
│ ├── RMS.Application/ # CQRS handlers, business logic
│ ├── RMS.Domain/ # Core entities
│ ├── RMS.Infrastructure/ # EF Core, services
│ └── RMS.Shared/ # Shared utilities
├── frontend/ # React + TypeScript + Tailwind
└── tests/ # Unit tests (xUnit)

**Patterns**: Clean Architecture, CQRS, Repository, Dependency Injection

## 🛠️ Tech Stack

| Layer    | Technology                                   |
| -------- | -------------------------------------------- |
| Backend  | .NET 10, ASP.NET Core, Entity Framework Core |
| Frontend | React 19, TypeScript, Tailwind CSS, Vite     |
| Database | PostgreSQL 16 (Docker)                       |
| Auth     | JWT                                          |
| Logging  | Serilog                                      |
| Testing  | xUnit, Moq, FluentAssertions                 |

## 📊 Project Progress

Sprint Feature Status
Sprint 0 Foundation & Architecture ✅
Sprint 1 Auth Backend ✅
Sprint 2 Auth Frontend ✅
Sprint 3 Vehicle Management ✅
Sprint 4 Reservation System ✅
Sprint 5 Rental Transactions ✅
Sprint 6 Dashboard & Reports 🟡
Sprint 7 Image Upload ⬜

## 🔒 Security

JWT with access + refresh tokens
PBKDF2 password hashing
Role-based authorization
Input validation (FluentValidation)
SQL injection prevention (EF Core)
CORS protection

🚧 Project Status: Ongoing 🚧
