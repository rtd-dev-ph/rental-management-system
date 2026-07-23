# Sprint 0: Project Foundation

**Start Date**: July 23, 2026
**Status**: 🟡 In Progress

## Goal

Set up development environment and project structure.

## Tasks

### Environment Setup

- [✅] Verify .NET 8 SDK installed
- [✅] Verify Node.js installed
- [✅] Verify Docker installed
- [✅] Install VS Code

### Project Creation

- [✅] Create Clean Architecture solution
- [✅] Install NuGet packages
- [✅] Configure PostgreSQL in Docker
- [ ] Set up Entity Framework Core
- [ ] Configure Swagger
- [ ] Set up Serilog logging
- [ ] Create exception middleware

### Database

- [ ] Create roles table
- [ ] Create users table
- [ ] Create refresh_tokens table
- [ ] Run initial migration

### Frontend

- [ ] Scaffold React app with Vite
- [ ] Install Tailwind CSS
- [ ] Install React Router
- [ ] Install Axios

### Documentation

- [x] Create docs folder structure
- [x] Create Sprint 0 document
- [x] Create Sprint 1 document
- [ ] Create main README.md

## 🔄 The Setup Pattern

### Step 1: Create Solution & Projects

dotnet new sln -n YourProjectName
dotnet new webapi -n YourProject.Api -f net10.0 -o src/YourProject.Api
dotnet new classlib -n YourProject.Application -f net10.0 -o src/YourProject.Application
dotnet new classlib -n YourProject.Domain -f net10.0 -o src/YourProject.Domain
dotnet new classlib -n YourProject.Infrastructure -f net10.0 -o src/YourProject.Infrastructure
dotnet new classlib -n YourProject.Shared -f net10.0 -o src/YourProject.Shared
dotnet sln add src/\*_/_.csproj

### Step 2: Delete Default Files

rm src/YourProject.Application/Class1.cs
rm src/YourProject.Domain/Class1.cs
rm src/YourProject.Infrastructure/Class1.cs
rm src/YourProject.Shared/Class1.cs

### Step 3: Project Dependencies

API → Application
API → Infrastructure
Application → Domain
Application → Shared
Infrastructure → Application

# API dependencies

dotnet add src/YourProject.Api reference src/YourProject.Application
dotnet add src/YourProject.Api reference src/YourProject.Infrastructure

# Application dependencies

dotnet add src/YourProject.Application reference src/YourProject.Domain
dotnet add src/YourProject.Application reference src/YourProject.Shared

# Infrastructure dependencies

dotnet add src/YourProject.Infrastructure reference src/YourProject.Application

### Step 4: Docker Compose (Database)

services:
postgres:
image: postgres:16-alpine
container_name: yourproject-postgres
environment:
POSTGRES_DB: your_db
POSTGRES_USER: your_user
POSTGRES_PASSWORD: your_password
ports: - "5432:5432"
volumes: - postgres_data:/var/lib/postgresql/data
healthcheck:
test: ["CMD-SHELL", "pg_isready -U your_user"]
interval: 5s
timeout: 5s
retries: 5

volumes:
postgres_data:

docker compose up -d
docker compose ps

### Step 5: Connection String

{
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Port=5432;Database=your_db;Username=your_user;Password=your_password"
}
}

## Step 6: NuGet Packages

# API Layer:

dotnet add src/YourProject.Api package Swashbuckle.AspNetCore
dotnet add src/YourProject.Api package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add src/YourProject.Api package Serilog.AspNetCore
dotnet add src/YourProject.Api package Serilog.Sinks.Console
dotnet add src/YourProject.Api package Serilog.Sinks.File
dotnet add src/YourProject.Api package Microsoft.EntityFrameworkCore.Design

# Application Layer:

dotnet add src/YourProject.Application package MediatR
dotnet add src/YourProject.Application package FluentValidation
dotnet add src/YourProject.Application package FluentValidation.DependencyInjectionExtensions
dotnet add src/YourProject.Application package AutoMapper
dotnet add src/YourProject.Application package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add src/YourProject.Application package Microsoft.EntityFrameworkCore

# Infrastructure Layer:

dotnet add src/YourProject.Infrastructure package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add src/YourProject.Infrastructure package Microsoft.AspNetCore.Identity
dotnet add src/YourProject.Infrastructure package System.IdentityModel.Tokens.Jwt

### Step 7: Documentation Structure

mkdir -p docs/sprints
mkdir -p docs/architecture/adr
mkdir -p docs/api
mkdir -p docs/guides
mkdir -p docs/diagrams
mkdir -p docs/screenshots

### ✅ Step 8: Verify All Packages

echo "=== API Packages ==="
dotnet list src/YourProject.Api package

echo ""
echo "=== Application Packages ==="
dotnet list src/YourProject.Application package

echo ""
echo "=== Infrastructure Packages ==="
dotnet list src/YourProject.Infrastructure package

echo ""
echo "=== Build Test ==="
dotnet build

### 📊 Dependency Flow Diagram

┌─────────────────────────────────────────────┐
│ RMS.Api │
│ (Controllers, Middleware) │
└──────────┬──────────────────────┬───────────┘
│ │
▼ ▼
┌──────────────────┐ ┌──────────────────────┐
│ RMS.Application │ │ RMS.Infrastructure │
│ (Use Cases) │◄──│ (EF Core, Services) │
└────────┬─────────┘ └──────────────────────┘
│
▼
┌──────────────────┐
│ RMS.Domain │
│ (Entities, Enums)│
└──────────────────┘
▲
│
┌──────────────────┐
│ RMS.Shared │
│ (Constants, Ext) │
└──────────────────┘

# Rules:

Domain has NO dependencies

Application depends on Domain + Shared

Infrastructure depends on Application

API depends on Application + Infrastructure

### 🐳 Docker Commands Cheat Sheet

# Start containers

docker compose up -d

# Check status

docker compose ps

# View logs

docker compose logs postgres

# Connect to database

docker compose exec postgres psql -U your_user -d your_db

# Stop containers (keeps data)

docker compose down

# Stop and delete data

docker compose down -v

# Restart

docker compose restart

### 📝 Environment Quick Check

echo "=== Dev Environment ==="
echo "Docker: $(docker --version 2>/dev/null || echo 'NOT INSTALLED')"
echo ".NET: $(dotnet --version 2>/dev/null || echo 'NOT INSTALLED')"
echo "Node: $(node --version 2>/dev/null || echo 'NOT INSTALLED')"
echo "Git: $(git --version 2>/dev/null || echo 'NOT INSTALLED')"
