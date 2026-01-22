# 🧩 Explore Pattern — N‑Layer Architecture with EF Core (.NET)

Source code for explore **N‑Layer Architecture**  
(`Controller → Service → Repository → Unit of Work`) use **Entity Framework Core**

---

## 📐 Architecture Overview

```
src
├── explore-pattern.Api
│   ├── Controllers
│   ├── Services
│   ├── Repositories
│   ├── UnitOfWorks
│   ├── Interfaces
│   ├── Models
│   ├── Databases
│   ├── Configurations
│   ├── Utilities
│   └── Program.cs
│
└── tests
```
---

## 🧠 Architectural Style

This project follows a **classic N‑Layer architecture**:
> **Responsibility Rule:**  
> Each layer has a single responsibility and communicates only with the layer directly below it.

---
## 🧩 Layer Responsibilities

### 🟣 API Layer (`explore-pattern.Api`)
Acts as the **application boundary & composition root**.

**Controllers**
- Handle HTTP requests & responses
- Basic input validation
- Call Service layer only
- No business logic

---

### 🔵 Service Layer
Contains **application & business logic**.

- Use‑case orchestration
- Business validations
- Transaction boundaries
- Coordinates multiple repositories
- Responsible for `SaveChangesAsync()` via Unit of Work

Services/
---

### 🟠 Repository Layer
Handles **data access logic only**.

- Querying data
- Add / Update / Remove entities
- EF Core `DbSet<TEntity>` usage
- No `SaveChanges()`

Repositories/
---

### 🟡 Unit of Work Layer
Defines **commit & transaction boundary**.

- Wraps `DbContext.SaveChangesAsync()`
- Ensures atomicity across multiple repositories

UnitOfWorks/
---

### 🧾 Interfaces
Holds **abstractions** to support loose coupling.

- Service interfaces
- Repository interfaces
- Unit of Work contracts


Interfaces/
---

### 🗄️ Database Layer
EF Core persistence components.

- DbContext
- Entity configurations
- Migrations (if enabled)


Databases/
---

### 🧪 Models
Application data structures.

- Entities
- DTOs
- Request / Response models


Models/
---

### ⚙️ Configurations
Application setup and dependency mappings.

- Dependency Injection
- Options binding
- Environment-based configuration


Configurations/
---

### 🧰 Utilities
Cross‑cutting utilities and helpers.

```
Utilities/
├── Constants
│   └── StatusMessage.cs
├── Helpers
│   └── MessageFormatter.cs
```
---

## 🔁 Dependency Flow Summary

✅ Controllers → Services  
✅ Services → Repositories + UnitOfWork  
✅ Repositories → DbContext  

🚫 Controllers do not access repositories directly  
🚫 Repositories do not perform commits  
🚫 Database logic does not leak into Controllers

---

## 🧪 Testing

Located under `tests`:

- Unit tests for Services & Utilities
- Integration tests for Repositories & DbContext
- CI‑ready structure

---

## ✅ Key Design Decisions

- N‑Layer architecture for clarity and learning purpose
- EF Core DbContext acts as persistence mechanism
- Explicit separation of:
  - Orchestration (Service)
  - Persistence (Repository)
  - Commit (Unit of Work)
- Async API end‑to‑end

---
