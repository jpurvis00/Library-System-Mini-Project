# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET 8.0 console application for managing a basic library system. The project uses:
- **Dumpify** (v0.6.6) for console output formatting
- **Microsoft.Extensions.DependencyInjection** (v9.0.10) for dependency injection support

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

The codebase follows a simple layered architecture:

### Models Layer (`Models/`)
- **Book**: Represents a library book with title, author, ISBN, and checkout status/dates
- **Member**: Represents a library member with name, membership details, and checked-out books
- **Library**: Represents the library itself with a collection of books (initialized with sample data)

### Services Layer (`Services/`)
- **LibraryServices**: Contains business logic for querying books (e.g., filtering checked-out books, retrieving all books)

### Entry Point
- **Program.cs**: Main console application that demonstrates library operations using Dumpify for formatted console output

## Key Design Patterns

The Library class initializes with hardcoded sample book data in its constructor. Services operate on collections passed as parameters rather than maintaining state. The Member class includes display logic (DisplayCheckoutBooks method) for formatted output of checked-out books.

## Namespace

All project files use the namespace `LibrarySystemMiniProject` (matching the RootNamespace in the .csproj file).
