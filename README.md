# Video Game Character API

This is a simple ASP.NET Core Web API that manages video game characters. It demonstrates basic CRUD (Create, Read, Update, Delete) operations using Entity Framework Core and follows a layered structure (Controllers, Services, Data, Models, DTOs).

## Project structure (simple explanation)

- `Controllers/` - Receives HTTP requests and returns responses. It calls service methods to perform work.
- `Services/` - Contains business logic. Talks to the database via `AppDbContext` and translates between domain models and DTOs.
- `Data/` - Contains `AppDbContext` which is the EF Core database context. It defines which entities are stored in the database.
- `Models/` - Domain models that represent database tables (e.g., `Character`).
- `Dtos/` - Simple objects used to transfer data in/out of the API. Keeps domain models separate from API shape.
- `Program.cs` - App startup. Registers services and configures middleware.

## How the API works (beginner-friendly)

1. The controller defines endpoints like `GET /api/GameCharacter` or `POST /api/GameCharacter`.
2. When a request arrives, the controller calls the service (for example `IVideoGameCharacterService`).
3. The service uses `AppDbContext` to talk to the database (for example to add or read `Character` rows).
4. DTOs (`CreateCharacterRequest`, `UpdateCharacterRequest`, `CharacterResponse`) are used so the API doesn't expose internal database entities directly.

## Key files and why they exist (short notes)

- `Program.cs` - Registers services (controllers, DbContext, and the character service) and configures middleware. It's the app entry point.
- `AppDbContext.cs` - Inherits `DbContext`. Provides `DbSet<Character>` to query and save `Character` entities.
- `Character.cs` - Defines properties stored in the database for each character.
- `DTOs` -
  - `CreateCharacterRequest` - Payload for creating a character. Contains `Name`, `Game`, `Role`.
  - `UpdateCharacterRequest` - Payload for updating a character. Contains same fields plus `Id`.
  - `CharacterResponse` - Data returned to API clients, includes `Id`.
- `IVideoGameCharacterService.cs` - Interface describing what operations the service provides (GetAll, GetById, Add, Update, Delete).
- `VideoGameCharacterService.cs` - Implementation of the interface. Contains the actual database operations and maps DTOs to domain models.
- `GameCharacterController.cs` - Routes HTTP requests to the service and returns appropriate HTTP responses (200, 201, 204, 404).

## Running the project

- Ensure you have a SQL Server instance and update `appsettings.json` connection string `DefaultConnection`.
- Run `dotnet ef database update` to apply migrations.
- Start the app (F5 in Visual Studio). Use the Swagger/OpenAPI UI in development to test endpoints.

## Example HTTP requests

- GET /api/GameCharacter - list all characters
- GET /api/GameCharacter/1 - get character with id 1
- POST /api/GameCharacter - create new character (send JSON with `Name`, `Game`, `Role`)
- PUT /api/GameCharacter/1 - update character with id 1 (send JSON with `Id`, `Name`, `Game`, `Role`)
- DELETE /api/GameCharacter/1 - delete character with id 1

## Notes for beginners

- DTO: Data Transfer Object. Used to separate API shape from database entities.
- DbContext: Represents the database session, and `DbSet<T>` are collections representing tables.
- Migrations: EF Core feature to create/update database schema from code.

# Video Game Character API

This is a simple ASP.NET Core Web API that manages video game characters. It demonstrates basic CRUD (Create, Read, Update, Delete) operations using Entity Framework Core and follows a layered structure (Controllers, Services, Data, Models, DTOs).

## Project structure (simple explanation)

- `Controllers/` - Receives HTTP requests and returns responses. It calls service methods to perform work.
- `Services/` - Contains business logic. Talks to the database via `AppDbContext` and translates between domain models and DTOs.
- `Data/` - Contains `AppDbContext` which is the EF Core database context. It defines which entities are stored in the database.
- `Models/` - Domain models that represent database tables (e.g., `Character`).
- `Dtos/` - Simple objects used to transfer data in/out of the API. Keeps domain models separate from API shape.
- `Program.cs` - App startup. Registers services and configures middleware.

## How the API works (beginner-friendly)

1. The controller defines endpoints like `GET /api/GameCharacter` or `POST /api/GameCharacter`.
2. When a request arrives, the controller calls the service (for example `IVideoGameCharacterService`).
3. The service uses `AppDbContext` to talk to the database (for example to add or read `Character` rows).
4. DTOs (`CreateCharacterRequest`, `UpdateCharacterRequest`, `CharacterResponse`) are used so the API doesn't expose internal database entities directly.

## Key files and why they exist (short notes)

- `Program.cs` - Registers services (controllers, DbContext, and the character service) and configures middleware. It's the app entry point.
- `AppDbContext.cs` - Inherits `DbContext`. Provides `DbSet<Character>` to query and save `Character` entities.
- `Character.cs` - Defines properties stored in the database for each character.
- `DTOs` -
  - `CreateCharacterRequest` - Payload for creating a character. Contains `Name`, `Game`, `Role`.
  - `UpdateCharacterRequest` - Payload for updating a character. Contains same fields plus `Id`.
  - `CharacterResponse` - Data returned to API clients, includes `Id`.
- `IVideoGameCharacterService.cs` - Interface describing what operations the service provides (GetAll, GetById, Add, Update, Delete).
- `VideoGameCharacterService.cs` - Implementation of the interface. Contains the actual database operations and maps DTOs to domain models.
- `GameCharacterController.cs` - Routes HTTP requests to the service and returns appropriate HTTP responses (200, 201, 204, 404).

## Running the project

- Ensure you have a SQL Server instance and update `appsettings.json` connection string `DefaultConnection`.
- Run `dotnet ef database update` to apply migrations.
- Start the app (F5 in Visual Studio). Use the Swagger/OpenAPI UI in development to test endpoints.

## Example HTTP requests

- GET /api/GameCharacter - list all characters
- GET /api/GameCharacter/1 - get character with id 1
- POST /api/GameCharacter - create new character (send JSON with `Name`, `Game`, `Role`)
- PUT /api/GameCharacter/1 - update character with id 1 (send JSON with `Id`, `Name`, `Game`, `Role`)
- DELETE /api/GameCharacter/1 - delete character with id 1

## Notes for beginners

- DTO: Data Transfer Object. Used to separate API shape from database entities.
- DbContext: Represents the database session, and `DbSet<T>` are collections representing tables.
- Migrations: EF Core feature to create/update database schema from code.


If you want, I can annotate each file in-place with simple comments explaining every method and property. Would you like me to add those comments directly into the code files?

If you want, I can annotate each file in-place with simple comments explaining every method and property. Would you like me to add those comments directly into the code files?