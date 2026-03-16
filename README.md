# DentalClinic API

Overview
--------
DentalClinic is a sample REST API for managing patients in a dental clinic. It exposes endpoints to create patients and retrieve patient lists with pagination metadata. The solution is organized into layered projects: `API`, `Application`, and `Persistence`.

Key features
------------
- Create patient (POST)
- List patients with pagination (GET), returns `X-Pagination` header
- Clean separation of concerns (API / Application / Persistence)
- Simple custom mediator for CQRS-style requests
- Repository abstraction for data access
- FluentValidation integration for request validation
- Global error handling middleware

Architecture & Design Patterns
-----------------------------
- Clean Architecture / Layered approach
  - `API` — Presentation layer (Controllers, DTOs, middleware, extensions)
  - `Application` — Business logic (Requests, Handlers, DTOs, Interfaces)
  - `Persistence` — Data access (repositories, EF or other implementations)
- CQRS (Command / Query Responsibility Segregation)
  - Commands for state changes, Queries for read operations
- Mediator pattern
  - Custom `SimpleMediator` and `IMediator` used to dispatch `IRequest` / `IRequest<T>`
- Repository pattern
  - `IPatientRepository` abstracts storage concerns
- Dependency Injection
  - Services registered via `AddApplicationServices()` and `AddPersistenceServices()`
- Validation
  - `FluentValidation` validators (resolved by mediator before handlers)
- Middleware
  - Global error handler (`ErrorHandlingMiddleware`) and HTTP context extensions for pagination

Folder structure
----------------
Top-level projects:
- `DentalClinic.API/`
  - `Controllers/` - API controllers (e.g., `PatientsController.cs`)
  - `DTOs/` - request/response DTOs
  - `Middleware/` - error handling, other middleware
  - `Utilities/` - helpers (e.g., `HttpContextExtensions.cs`)
- `DentalClinic.Application/`
  - `Features/` - feature folders with `Commands` and `Queries`
    - `Patients/Commands/CreatePatient/`
      - `CreatePatientCommand.cs`, `CreatePatientCommandHandler.cs`
    - `Patients/Queries/GetPatientsList/`
      - `GetPatientsListQuery.cs`, `GetPatientsListQueryHandler.cs`, `PatientListDTO.cs`
  - `Utilities/` - mediator interfaces and implementations (`IMediator`, `IRequest`, `IRequestHandler`, `SimpleMediator`)
  - `Contracts/` - repository interfaces (`IPatientRepository`)
  - `Validators/` - `FluentValidation` validators
- `DentalClinic.Persistence/`
  - Repository implementations and DB context (e.g., `PatientRepository`, `ApplicationDbContext`)
- `tests/` (optional) - unit/integration tests

Important files
---------------
- `Program.cs` — app bootstrap; calls `AddPersistenceServices()` and `AddApplicationServices()`
- `DentalClinic.Application.Utilities.SimpleMediator` — dispatches requests to `IRequestHandler<TRequest, TResponse>`
- `HttpContextExtensions.InsertPaginationInformationInHeader` — sets `X-Pagination` header
- `ErrorHandlingMiddleware` — unified exception handling

How the mediator dispatch works
-------------------------------
- Requests implement `IRequest<TResponse>` or `IRequest`.
- Handlers implement `IRequestHandler<TRequest, TResponse>` or `IRequestHandler<TRequest>`.
- `SimpleMediator` resolves a `IRequestHandler<TRequest, TResponse>` from DI and invokes `Handle`.
- Validators (if registered) are executed before handler invocation.

Common pitfalls & notes
----------------------
- Handlers must be registered in the DI container as the `IRequestHandler<,>` interfaces, or the mediator will throw: `No handler found for request of type ...`.
  - Example explicit registration:
    `services.AddScoped<IRequestHandler<GetPatientsListQuery, List<PatientListDTO>>, GetPatientsListQueryHandler>();`
  - Recommended: register handlers by scanning assemblies (e.g., using `Scrutor`) and register `IRequestHandler<,>` implementations as their implemented interfaces.
- Ensure validators are registered as `IValidator<TRequest>` so `SimpleMediator` can find and run them.
- Pagination header key: `X-Pagination`. The header is exposed via `Access-Control-Expose-Headers` for browsers.

Getting started
---------------
Requirements:
- .NET 10 SDK

Build and run:
- `dotnet restore`
- `dotnet build`
- `dotnet run --project DentalClinic.API`

API Endpoints (examples)
------------------------
- POST `/api/patients` — create a patient (body: `CreatePatientDTO`)
- GET `/api/patients` — list patients; supports query parameters that map to `GetPatientsListQuery`
  - Response includes `X-Pagination` header containing JSON `{ "TotalAmountOfRecords": <int> }`

Extending the app
-----------------
- Add new queries/commands under `Application/Features/<Entity>/...` with corresponding handlers.
- Register new handlers in DI or configure assembly scanning to auto-register handlers.
- Add validators under `Application/Validators` and register them with DI.

Troubleshooting
---------------
- If you see `No handler found for request of type ...`, verify:
  - The handler implements the correct `IRequestHandler<TRequest, TResponse>` signature matching the request type and response type.
  - The handler is registered in DI as the `IRequestHandler<,>` interface (or assembly scanning is set up).
- If validations not executed, ensure validators are registered as `IValidator<TRequest>`.

License
-------
This repository is for demonstration purposes.
