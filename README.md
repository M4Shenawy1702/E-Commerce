# 🛒 E-Commerce Backend API

A **scalable**, **feature-rich** E-Commerce backend built with **ASP.NET Core 8**, following **Clean Architecture** and **Domain-Driven Design** principles.

## 📌 Project Highlights

- ✅ Clean Architecture & Domain-Driven Design
- ✅ JWT Authentication & Role-Based Authorization
- ✅ Complete Order Management System (Basket → Checkout → Payment)
- ✅ CRUD Operations for Products, Brands, and Types
- ✅ Redis Caching for High Performance
- ✅ Stripe Payment Integration
- ✅ Specification Pattern for Flexible Filtering
- ✅ Repository + Unit of Work Pattern
- ✅ AutoMapper for DTO Mapping
- ✅ Centralized Exception Handling

---

## ⚙️ Tech Stack

| Technology        | Description                           |
|-------------------|---------------------------------------|
| .NET 8            | Backend framework                     |
| Entity Framework Core | ORM for database access         |
| MS SQL Server     | Relational Database                   |
| Redis             | In-memory caching                     |
| Stripe            | Payment Gateway Integration           |
| AutoMapper        | DTO to Entity Mapping                 |
| JWT               | Secure Authentication & Authorization |

---

## 📁 Project Structure (Clean Architecture)

├── Domain
│ └── Models
├── Application
│ └── Interfaces, DTOs, Services
├── Infrastructure
│ └── EF Core, Repositories, Redis, Stripe
├── WebAPI
│ └── Controllers, Middleware, Startup


---

## 🔐 Authentication

- **JWT-Based Authentication**
- **Role-Based Authorization**
  - Super Admin
  - Admin
  - User

---

## 🧾 Features

### ✅ Products Module
- Create, Update, Delete Products
- Assign Brands & Types
- Image Upload & Validation

### ✅ Orders Module
- Add to Basket
- Checkout
- Track Orders
- Pay with Stripe

### ✅ Redis Caching
- Improve performance of Product listing

---

## 🚀 Getting Started

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/M4Shenawy1702/E-Commerce.git
cd E-Commerce
```
### 2️⃣ Set up the Database
```bash
    Update connection string in appsettings.json

    Run migrations:

dotnet ef database update
```
### 3️⃣ Run the Project
```bash
dotnet run --project WebAPI
```
### 💳 Stripe Setup
```bash
    Add your Stripe Secret Key in appsettings.json:

"Stripe": {
  "SecretKey": "your_stripe_secret_key",
  "PublishableKey": "your_stripe_publishable_key"
}
```
### 📸 Screenshots 

![Swagger Doc](assets/E-Commerce API Documentation.png)



