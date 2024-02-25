# User App

# Tree Diagram

```bash
├── Domain
│   └── User.cs                    <-- Domain model
│
├── Application
│   ├── Ports
│   │   ├── IUserRepository.cs     <-- Port
│   │   └── ICreateUserUseCase.cs  <-- Port
│   ├── Adapters
│   │   ├── IUserRepositoryAdapter.cs     <-- IUserRepository Adapter
│   │   └── UserRepository.cs             <-- Implementation of IUserRepositoryAdapter
│   ├── CreateUserRequest.cs
│   ├── CreateUserResponse.cs
│   └── CreateUserUseCase.cs        <-- Implementation of ICreateUserUseCase
│
├── Infrastructure
│   └── DatabaseContext.cs
│
├── Presentation
│   └── (controllers, views, etc.)
│
└── Tests
    └── (unit tests, integration tests, etc.)
```

# Clean Architecture:
Clean Architecture consists of concentric layers, each representing a different level of abstraction. 

## The main layers are:

Entities: Represent business objects containing basic business logic.

Use Cases: Contain application-specific logic and coordinate the execution of tasks.

Ports: Interfaces defining application-specific services or functionalities.

Adapters: Concrete implementations of boundary interfaces (Ports). They adapt the implementation details to the interfaces defined in the inner layers.

Ports and Adapters:
"Ports" are the interfaces defining application-specific services or functionalities, while "Adapters" are the concrete implementations of these interfaces.

# Project Organization:

Let's create a simple example to illustrate the project organization. Consider a user management system.

## Domain (Entities and Use Cases):

- **Entities:**
  - **User.cs:** Defines the user entity.

## Application (Boundary Interfaces):

- **Ports:**
  - **IUserRepository.cs:** Defines the interface for the user repository.
  - **ICreateUserUseCase.cs:** Defines the interface for creating a user.

- **UserRepositoryAdapter:**
  - **IUserRepositoryAdapter.cs:** IUserRepository Adapter
  - **UserRepository.cs:** Implements IUserRepository interacting with the database.

- **Request and Response Models:**
  - **CreateUserRequest.cs:** Request model for creating a user.
  - **CreateUserResponse.cs:** Response model for creating a user.

  - **Use Cases:**
  - **CreateUserUseCase.cs:** Implementation of ICreateUserUseCase

## Infrastructure (Implementation Details):

- **DatabaseContext.cs:** Database configuration.

## Presentation (Controllers, Views, etc. - Appropriate for APIs):

- **UserController.cs:** User interface controller, handles HTTP requests, calls the use case.

## Tests:

- **(unit tests, integration tests, etc.)**
