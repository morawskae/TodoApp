# TodoApp Backend

A RESTful task management API built with **ASP.NET Core Web API**.

The backend provides user registration and authentication, role-based authorization, user management, and CRUD operations for to-do items. Users can manage their own tasks, while administrators have access to additional management endpoints.

The project follows a layered architecture using **Controllers, Services, Repositories, DTOs, and Entity Framework Core**.

## Built With

* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* JWT Authentication
* ASP.NET Core Authorization
* Swagger
* C#

## Features

### Authentication

* User registration
* User login
* JWT token generation
* Authenticated API requests
* Role-based authorization

### User Roles

The application supports two roles:

* **User** — can manage their own to-do items
* **Admin** — can manage users and access all to-do items

### Todo Items

Users can:

* Create tasks
* View their own tasks
* Update tasks
* Delete tasks
* Mark tasks as finished

Administrators can:

* View all tasks
* View individual tasks

### User Management

Administrators can:

* View all users
* View a user by ID
* Create users
* Delete users

## Getting Started

### Prerequisites

Make sure you have:

* .NET SDK
* Git
* SQLite

Check your installed .NET version:

```bash
dotnet --version
```

### Installation

Clone the repository:

```bash
git clone <repository-url>
cd TodoAPI
```

Restore the backend dependencies:

```bash
dotnet restore
```

Apply Entity Framework Core migrations:

```bash
dotnet ef database update
```

Start the API:

```bash
dotnet run
```

The API will be available at the URL shown in the terminal.

Swagger UI can be accessed through:

```text
http://localhost:<port>/swagger
```

## Authentication

The API uses **JWT Bearer Authentication**.

Users can register through:

```http
POST /api/Auth/register
```

Users can then authenticate through:

```http
POST /api/Auth/login
```

A successful login returns a JWT token:

```json
{
  "token": "<jwt-token>"
}
```

The token should be included in requests to protected endpoints using the `Authorization` header:

```text
Authorization: Bearer <jwt-token>
```

## Authorization

Access to endpoints is controlled using roles.

### User

Regular users can manage their own tasks:

```text
POST   /api/toDoItems
PUT    /api/toDoItems/{id}
DELETE /api/toDoItems/{id}
GET    /api/toDoItems/my-items
```

### Admin

Administrators have access to user management and all task records:

```text
GET    /api/users
GET    /api/users/{id}
POST   /api/users
DELETE /api/users/{id}

GET    /api/toDoItems
GET    /api/toDoItems/{id}
```

## API Endpoints

### Authentication

| Method | Endpoint             | Authorization | Description                           |
| ------ | -------------------- | ------------- | ------------------------------------- |
| `POST` | `/api/Auth/register` | Anonymous     | Register a new user                   |
| `POST` | `/api/Auth/login`    | Anonymous     | Authenticate a user and receive a JWT |

### Todo Items

| Method   | Endpoint                  | Role  | Description                        |
| -------- | ------------------------- | ----- | ---------------------------------- |
| `GET`    | `/api/toDoItems`          | Admin | Get all tasks                      |
| `GET`    | `/api/toDoItems/{id}`     | Admin | Get a task by ID                   |
| `POST`   | `/api/toDoItems`          | User  | Create a task                      |
| `PUT`    | `/api/toDoItems/{id}`     | User  | Update a task                      |
| `DELETE` | `/api/toDoItems/{id}`     | User  | Delete a task                      |
| `GET`    | `/api/toDoItems/my-items` | User  | Get the authenticated user's tasks |

### Users

| Method   | Endpoint          | Role  | Description      |
| -------- | ----------------- | ----- | ---------------- |
| `GET`    | `/api/users`      | Admin | Get all users    |
| `GET`    | `/api/users/{id}` | Admin | Get a user by ID |
| `POST`   | `/api/users`      | Admin | Create a user    |
| `DELETE` | `/api/users/{id}` | Admin | Delete a user    |

## Architecture

The backend follows a layered architecture:

```text
HTTP Request
     │
     ▼
Controllers
     │
     ▼
Services
     │
     ▼
Repositories
     │
     ▼
Entity Framework Core
     │
     ▼
SQLite Database
```

### Controllers

Controllers are responsible for handling HTTP requests and returning appropriate HTTP responses.

The main controllers are:

* `AuthController`
* `ToDoItemController`
* `UserController`

Controllers communicate with the service layer rather than directly accessing the database.

### Services

The service layer contains the application's business logic.

Examples include:

* User registration and login
* Task creation and updates
* User-specific task retrieval
* User management
* Authorization-related business rules

Services depend on repository interfaces to access persistent data.

For example:

```text
IUserService
     │
     ▼
UserService
     │
     ▼
IUserRepository
     │
     ▼
UserRepository
```

And for to-do items:

```text
IToDoItemService
     │
     ▼
ToDoItemService
     │
     ▼
IToDoItemRepository
     │
     ▼
ToDoItemRepository
```

### Repositories

The repository layer is responsible for data access.

Repositories abstract database operations away from the service layer and provide a dedicated place for querying and modifying entities.

This separation helps keep business logic independent from the specific persistence implementation.

### DTOs

Data Transfer Objects are used for API requests and responses.

Examples include:

* `CreateUserDTO`
* `UserLoginReqDTO`
* `CreateTDItemDTO`
* `UpdateTDItemDTO`

DTOs help separate API contracts from the underlying database entities.

### Entity Framework Core

Entity Framework Core is used as the ORM for database access.

Repositories use EF Core to query and modify the SQLite database.

## Project Structure

```text
TodoAPI/
├── Controllers/
│   ├── AuthController.cs
│   ├── ToDoItemController.cs
│   └── UserController.cs
│
├── DTOs/
│   ├── ItemDTOs/
│   └── UserDTOS/
|
├── Migrations/
|
├── Models/
│   ├── ToDoItem.cs
│   └── User.cs
|
├── Properties/
|
├── Repositories/
│   ├── Implementations/
│   |   ├── ToDoItemRepository.cs
│   |   └── UserRepository.cs
│   └── Interfaces/
│       ├── IToDoItemRepository.cs
│       └── IUserRepository.cs
|
├── Services/
│   ├── Implementations/
│   │   ├── ToDoItemService.cs
|   |   ├── TokenService.cs
│   │   └── UserService.cs
│   └── Implementations/
│       ├── IToDoItemService.cs
│       └── IUserService.cs
│
├──AppDbContext.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

## Database

The application uses **SQLite** with **Entity Framework Core**.

The database stores information related to users and their to-do items.

The relationship between users and tasks allows the API to retrieve tasks belonging to the authenticated user.

Migrations are used to manage changes to the database schema.

Create a migration:

```bash
dotnet ef migrations add <MigrationName>
```

Apply migrations:

```bash
dotnet ef database update
```

## Security

The API uses JWT tokens to authenticate users.

Protected endpoints use ASP.NET Core's authorization system:

```csharp
[Authorize(Roles = "User")]
```

or:

```csharp
[Authorize(Roles = "Admin")]
```

The authenticated user's ID is retrieved from the JWT claims when performing user-specific operations.

This allows task operations to be associated with the currently authenticated user rather than relying on a user ID supplied directly by the client.

## Swagger

Swagger is included for API exploration and testing.

After starting the application, open:

```text
http://localhost:<port>/swagger
```

Swagger can be used to:

* Explore available endpoints
* View request and response models
* Test authentication endpoints
* Test protected endpoints
* Send API requests directly from the browser

For protected endpoints, provide the JWT token through Swagger's authorization functionality.

## Frontend

The project also includes a frontend built with:

* React
* TypeScript
* HTML
* CSS

The frontend communicates with the ASP.NET Core Web API and provides the user interface for interacting with tasks and authentication.

The backend can also be used independently through Swagger or another API client.

