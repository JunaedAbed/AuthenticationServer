# Authentication Server

A layered ASP.NET Core 6 Web API for user registration, with BCrypt password hashing and SQL Server through Entity Framework Core.

## Features
- `POST /register`: validates the request, checks for duplicate users and stores a BCrypt-hashed password
- Password hashing behind an `IPasswordHasher` interface (BCrypt implementation)
- User data access behind a user repository interface
- Swagger UI for exploring the API

## Tech stack
- **C# / ASP.NET Core 6** Web API
- **Entity Framework Core** + **SQL Server**
- **BCrypt.Net-Next**
- **Swashbuckle** (Swagger)

## Project structure
```
AuthenticationServer.API   # controllers, Program.cs, configuration
AuthenticationServer.BLL   # services: password hashing, user repository
AuthenticationServer.DAL   # DbContext, entity models, request DTOs
```

## Run it
1. Set your SQL Server connection string in `AuthenticationServer.API/appsettings.json`, or better, use user secrets:
   ```bash
   cd AuthenticationServer.API
   dotnet user-secrets set "ConnectionStrings:AuthenticationServerConnectionString" "<your connection string>"
   ```
2. Apply migrations and run:
   ```bash
   dotnet ef database update --project AuthenticationServer.DAL --startup-project AuthenticationServer.API
   dotnet run --project AuthenticationServer.API
   ```
3. Open `/swagger` to try the endpoints.

## Author
**Md Junaed Abed**: [Portfolio](https://abed-page.vercel.app) · [GitHub](https://github.com/JunaedAbed)
