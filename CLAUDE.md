# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET 8.0 console application for managing a library system. The project uses:
- **Dumpify** (v0.6.6) for console output formatting
- **Microsoft.Extensions.DependencyInjection** (v9.0.10) for dependency injection
- **JSON file storage** for persisting books and members data

## Build and Run Commands

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run

# Clean build artifacts
dotnet clean
```

## Architecture

The application follows a layered architecture with dependency injection:

### Entry Point (`Program.cs`)
- Configures dependency injection container
- Registers all services as singletons (ILibraryServices, IMemberServices, IDataServices, IMenuService)
- Bootstraps and runs the `LibraryApp`

### Main Application (`LibraryApp.cs`)
- Menu-driven console interface with operations: Borrow book, Return book, Update membership status
- Orchestrates interactions between data, library, member, and menu services
- Currently only "Borrow book" functionality is fully implemented

### Models Layer (`Models/`)
- **Book**: Library book with title, author, ISBN, checkout status, checkout date, and due date
- **Member**: Library member with first/last name, membership expiration status, and checked-out books
- **Library**: Legacy model (may not be actively used in current architecture)

### Services Layer (`Services/`)
All services implement corresponding interfaces from `Interfaces/`:

- **JsonDataServices** (`IDataServices`): Loads and saves books/members from JSON files in `Data/` directory
- **LibraryServices** (`ILibraryServices`): Book filtering logic (checked-out vs available books), member filtering by membership status
- **MemberServices** (`IMemberServices`): Member search, selection, and membership management operations
- **MenuService** (`IMenuService`): Console UI logic for displaying menus, selecting members/books, and showing success/error messages

### Data Storage
- Book and member data persisted in `Data/books.json` and `Data/members.json`
- JSON serialization/deserialization handled by `JsonDataServices`

## Key Design Patterns

- **Dependency Injection**: All services are interface-based and injected via constructor
- **Single Responsibility**: Services are separated by concern (data, business logic, UI, member operations)
- **Stateless Services**: Services operate on data passed as parameters rather than maintaining internal state

## Namespace

All project files use the namespace `LibrarySystemMiniProject` (matching the RootNamespace in the .csproj file).
