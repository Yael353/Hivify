Hivify
A modular .NET 10 solution with a Blazor UI and multiple bounded-context projects (Association, Feeds, Houses, Complaints, AdminUserMgmt, Documents, SharedKernel, etc.). The solution uses EF Core (relational) for persistence and a clean layered architecture (Domain / Application / Infrastructure / UI).
Prerequisites
•	.NET 10 SDK
•	Visual Studio 2026 (Enterprise 18.8.1) or VS Code + C# extensions
•	PowerShell (preferred terminal)
•	SQL Server / other database depending on configured providers (see project config)
Solution layout (important projects)
•	Hivify.slnx — solution file
•	src/
•	Hivify/ (Blazor host/UI)
•	Association/
•	Domain/ (entities, value objects)
•	Application/ (commands, queries, DTOs, abstractions)
•	Infrastructure/ (EF DbContext, repositories)
•	Feeds/
•	Houses/
•	Complaints/
•	SharedKernel/ (common value objects, messaging)
•	AdminUserMgmt/ (admin UI components)
•	Documents/ (document components)
•	tests/ (if present)
Note: Projects target net10.0.
Common commands
From repo root:
•	Restore dependencies: dotnet restore
•	Build solution: dotnet build Hivify.slnx -c Debug
•	Build a single project: dotnet build src\Association\Application\Association.Application.csproj -c Debug -f net10.0
•	Clean bin/obj for a project (PowerShell): Remove-Item -Recurse -Force "src\Association\Application\bin","src\Association\Application\obj"
•	Run (Blazor host): dotnet run --project Hivify/Hivify.csproj
Database & EF Core
•	Ensure relational EF package is referenced for DbContext mapping extensions: dotnet add <project>.csproj package Microsoft.EntityFrameworkCore.Relational --version 10.0.9
•	Typical EF migration commands: dotnet ef migrations add <Name> --project src<Project>\Infrastructure --startup-project Hivify/Hivify.csproj dotnet ef database update --project src<Project>\Infrastructure --startup-project Hivify/Hivify.csproj
Known issues & quick fixes
•	CS0006 Metadata file not found
•	Build the referenced project (e.g., Association.Application) directly; ensure ProjectReference exists and build succeeds. Clean bin/obj and rebuild.
•	CS0118 "X is a namespace but is used like a type"
•	Ensure no namespace conflicts with type names. Prefer fully-qualified namespaces for imports and ensure the domain type name is unambiguous (e.g., AssociationEntity). Keep using directives consistent: use Hivify.Association.Domain.Associations when importing the entity type.
•	CS1061 errors on EF mapping extensions (HasColumnName, OwnsOne, etc.)
•	Add Microsoft.EntityFrameworkCore.Relational to the Infrastructure project containing the DbContext.
•	CS0841 "Cannot use local variable before it is declared"
•	Avoid naming local variables the same as types (e.g., use associationEntity for instances of AssociationEntity).
Conventions
•	Layering: Domain (pure domain logic) -> Application (use-cases & DTOs) -> Infrastructure (persistence) -> UI (Blazor)
•	Use value objects for identities (e.g., AssociationID, HouseID)
•	Repositories live in Infrastructure and implement Application-layer abstractions (IAssociationRepo)
How to contribute
1.	Create a feature branch from development.
2.	Run dotnet build and fix compile issues locally.
3.	Add or update migrations in the responsible Infrastructure project.
4.	Open a PR against development with description and testing steps.
Debugging tips
•	Build individual projects to isolate compile errors.
•	Remove/regen bin/obj if metadata or stale references persist.
•	Search for malformed namespaces introduced by bulk refactors (e.g., duplicated segments like Hivify.Hivify.*) and correct using directives.
•	Use Visual Studio error list to jump to first failing errors.
Contact / further help
Open an issue or provide the top build error lines (first ~10) when you need help fixing compilation problems.
