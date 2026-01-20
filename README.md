# 🧅 Explore Pattern — Onion Architecture (.NET)
source code for explore dotnet repository pattern

## 📐 Architecture Overview
```
src
├── Core
│ ├── Abstractions
│ ├── Application
│ └── Domain
│
├── Infrastructure
│ ├── Persistence
│ └── Presentation
│
├── Api
└── tests
```

> **Dependency Rule:**  
> Outer layers depend on inner layers — never the opposite.

---

## 🧩 Layer Responsibilities

### 🔵 Core

**Core.Abstractions**  
Contracts and interfaces only:
- Repository interfaces
- Service abstractions
- Unit of Work contracts

**Core.Application**  
Application & business logic:
- Use cases
- Application services
- CQRS-ready commands & queries

**Core.Domain**  
Pure domain models:
- Entities
- Value Objects
- Enums  
⚠️ No framework, no infrastructure, no technical logic.

---

### 🟠 Infrastructure

**Infrastructure.Persistence**  
Technical implementations:
- Database access
- Repository implementations
- External services & integrations

**Infrastructure.Presentation**  
API presentation layer:
- Controllers
- Request/Response models
- HTTP-related concerns only

---

### 🟣 API

**Api**  
Main application entry point:
- Dependency Injection
- Configuration
- Middleware & hosting pipeline

---

## 🧪 Testing
Located under `tests`:
- Unit tests (Core)
- Integration tests (Infrastructure)
- CI-friendly structure

---

