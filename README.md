# 🧅 Explore Pattern — Onion Architecture (.NET)
source code for explore dotnet repository pattern

## 📐 Architecture Overview
```
src
├── Core
│ ├── Application
│ └── Domain
│
├── Infrastructure
│ ├── Persistence
│
├── Api
└── tests
```

- **Core**
  - `Application` – business logic
  - `Domain` – domain models, interfaces & contracts
- **Infrastructure**
  - `Persistence` – database & external services
- **Api** – application entry point
- **tests** – unit & integration tests


> **Dependency Rule:**  
> Outer layers depend on inner layers — never the opposite.

---

## 🧩 Layer Responsibilities

### 🔵 Core


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
- Repository interfaces
- Service abstractions
- Unit of Work contracts
⚠️ No framework, no infrastructure, no technical logic.

---

### 🟠 Infrastructure

**Infrastructure.Persistence**  
Technical implementations:
- Database access
- Repository implementations
- External services & integrations


---

### 🟣 API

**Api**  
Main application entry point:
- Controllers
- Request/Response models
- HTTP-related concerns only
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

