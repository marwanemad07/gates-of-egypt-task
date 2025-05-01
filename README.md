# ECommerceApp

## Project Overview
ECommerceApp is a backend API for an e-commerce platform built using **ASP.NET Core 8**, **PostgreSQL**, and **Docker**. It provides features for user authentication, product management, cart operations, and multilingual product translations.

## Tech Stack
- **Backend:** ASP.NET Core 8, Entity Framework Core
- **Database:** PostgreSQL
- **Authentication:** JWT
- **Containerization:** Docker & Docker Compose

## Getting Started

###  Clone the Repository
```sh
git clone https://github.com/marwanemad07/ECommerceApp.git
cd ECommerceApp
```

### Run Locally (Without Docker)
#### Install Dependencies
```sh
dotnet restore
dotnet build
```
#### Apply Database Migrations
```sh
dotnet ef database update
```
#### Run the API
```sh
dotnet run --project ECommerceApp.API
```

API will be available at `http://localhost:5000`.

### Run with Docker
Ensure **Docker & Docker Compose** are installed.
```sh
docker-compose up --build
```
This starts both the **API** and **PostgreSQL** container.

## API Documentation
The API is documented with **Swagger** and **Postman**. After running the project, open:
- **Swagger UI:** `http://localhost:5001/swagger`
- **Postman Collection:** [Link to Postman Collection](https://gates7.postman.co/workspace/Gates-Workspace~c0a9c116-3b59-44d6-bf25-973931813a85/collection/31607561-1e5b8642-8c51-4ae3-baa3-413e8674e531?action=share&creator=31607561)

## Authentication
- Use JWT for authentication.
- Login to receive a token and include it in `Authorization: Bearer {token}` for protected endpoints.

## Database Seeding
To seed data manually, modify `DbSeeder.SeedData(appContext)` in `Program.cs`.

## Features
### User Management
- Register/Login with JWT authentication
- Role-based authorization (Admin/User)

### Product Management
- Add, update, delete products
- Multilingual support for product names/descriptions

### Cart System
- Add/Remove items from cart
- Prevents adding deleted products
