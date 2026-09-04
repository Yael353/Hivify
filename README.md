# Hivify

A modular .NET 10 solution with a Blazor UI and multiple bounded-context projects. The solution follows a layered architecture (Domain / Application / Infrastructure / UI) and uses EF Core (relational) for persistence.

---

## Table of contents

- [Prerequisites](#prerequisites)
- [Getting started](#getting-started)
- [Project layout](#project-layout)
- [Common commands](#common-commands)
- [Database & EF Core](#database--ef-core)
- [Known issues & quick fixes](#known-issues--quick-fixes)
- [Conventions](#conventions)
- [Contributing](#contributing)
- [Debugging tips](#debugging-tips)
- [Contact / further help](#contact--further-help)

---

## Prerequisites

- .NET 10 SDK
- Visual Studio 2026 (Enterprise 18.8.1) or VS Code with C# extensions
- PowerShell (preferred terminal)
- SQL Server or another relational DB (configured per project)

## Getting started

Clone the repository and run the commands from the repository root.

Restore packages:

```bash
dotnet restore
```

Build the full solution:

```bash
dotnet build Hivify.slnx -c Debug
```

Build a single project (example):

```bash
dotnet build src\Association\Application\Association.Application.csproj -c Debug -f net10.0
```

Run the Blazor host:

```bash
dotnet run --project Hivify/Hivify.csproj
```

## Project layout

Top-level structure (important projects):

- Hivify.slnx — solution file
- src/
  - Hivify/ (Blazor host / UI)
  - Association/
    - Domain/ (entities, value objects)
    - Application/ (commands, queries, DTOs, abstractions)
    - Infrastructure/ (EF DbContext, repositories)
  - Feeds/
  - Houses/
  - Complaints/
  - SharedKernel/ (common value objects, messaging)
  - AdminUserMgmt/ (admin UI components)
  - Documents/ (document components)
- tests/ (if present)

> Note: projects target net10.0

## Common commands

Clean bin/obj for a project (PowerShell):

```powershell
Remove-Item -Recurse -Force "src\Association\Application\bin","src\Association\Application\obj"
```

Rebuild solution:

```bash
dotnet build Hivify.slnx -c Debug
```

Run EF migrations (example):

```bash
# add migration
dotnet ef migrations add <Name> --project src\<Project>\Infrastructure --startup-project Hivify/Hivify.csproj

# apply migrations
dotnet ef database update --project src\<Project>\Infrastructure --startup-project Hivify/Hivify.csproj
```

## Database & EF Core

Ensure EF Core relational extensions are available in the infrastructure projects that define DbContext mapping (for methods such as `HasColumnName`, `OwnsOne`, etc.). Add the package if needed:

```bash
dotnet add <project>.csproj package Microsoft.EntityFrameworkCore.Relational --version 10.0.9
```

## Known issues & quick fixes

- CS0006: Metadata file not found
  - Build the referenced project (e.g. `Association.Application`) directly and ensure the ProjectReference exists. Clean `bin/obj` and rebuild.

- CS0118: "X is a namespace but is used like a type"
  - Avoid namespace/type name collisions. Use fully-qualified namespaces or rename the type (e.g. `AssociationEntity`). Ensure `using` directives are consistent (e.g. `using Hivify.Association.Domain.Associations;`).

- CS1061: EF mapping extension methods (e.g. `HasColumnName`) missing
  - Add `Microsoft.EntityFrameworkCore.Relational` to the project that contains the `DbContext`.

- CS0841: "Cannot use local variable before it is declared"
  - Avoid naming local variables the same as types (use `associationEntity` instead of `AssociationEntity`).

## Conventions

- Layering: Domain → Application → Infrastructure → UI (Blazor)
- Use value objects for identities (e.g., `AssociationID`, `HouseID`)
- Repositories live in Infrastructure and implement Application-layer abstractions (e.g., `IAssociationRepo`)

## Contributing

1. Create a feature branch from `development`.
2. Run `dotnet build` and fix compilation issues locally.
3. Add or update EF migrations in the responsible Infrastructure project.
4. Open a pull request targeting `development` with a clear description and testing steps.

## Debugging tips

- Build individual projects to isolate compilation errors.
- Delete and regenerate `bin/obj` directories if metadata or stale references persist.
- Search the repo for malformed namespaces introduced by bulk refactors (e.g. `Hivify.Hivify.*`) and correct `using` directives.
- Use Visual Studio's Error List and jump to the first failing error.

## Contact / further help

Open an issue in the repo or paste the top build error lines (first ~10) when you need help fixing compilation problems.
