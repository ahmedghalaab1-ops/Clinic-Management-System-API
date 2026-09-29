# 🏥 Clinic Management System API

A RESTful Web API for managing a clinic system built using **ASP.NET Core** and following **Clean Architecture** principles, **Repository Pattern**, and **Unit of Work**.

---

## 🏗️ Architecture & Technologies

- **Architecture:** Clean Architecture (Separation of Concerns)
  - `Clinic.Core`: Domain Models, Interfaces, DTOs, Business Services Specifications.
  - `Clinic.Data`: DbContext, Entity Configurations, Repository Implementations, Unit of Work.
  - `Clinic.Services`: Business Logic Implementations.
  - `Clinic.API`: REST Controllers, Middlewares, Dependency Injection.
- **Framework:** .NET 8 / .NET 9
- **ORM:** Entity Framework Core (SQL Server)
- **Documentation:** Swagger / OpenAPI
- **Validation:** Data Annotations & Model Validation

---

## ✨ Features

- **Doctor Management:** Full CRUD operations for doctor entities.
- **Patient Management:** Full CRUD operations for patients linked to assigned doctors.
- **Disease Catalog:** Manage disease records and descriptions.
- **Many-to-Many Relationships:** Assign multiple diseases to a patient and retrieve patient disease history.
- **Data Transfer Objects (DTOs):** Prevent circular references and expose only clean responses.
- **Data Validation:** Strict input validation with custom error messages.

---

## 🛠️ Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation
1. Clone the repository:
   ```bash
   git clone [https://github.com/YOUR_USERNAME/Clinic-Management-System-API.git](https://github.com/YOUR_USERNAME/Clinic-Management-System-API.git)