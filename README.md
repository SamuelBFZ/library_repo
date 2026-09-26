# Library Catalog (`sb.api.Library`)

Read-only library catalog on **.NET 10**, **SQL Server**, and **Entity Framework Core**. This step delivers the database schema, migrations, and seed data. Catalog HTTP endpoints are not implemented yet.

## Solution

```text
sb.api.Library.slnx
├── sb.api.Library                 API host (startup, OpenAPI, migrate + seed)
├── sb.api.Library.Application     contracts and DI registry
├── sb.api.Library.Domain          Book, Author, Category
└── sb.api.Library.Persistence     EF Core, SQL Server, seeders
```

ER model: [sb.api.Library/docs/er-model.md](sb.api.Library/docs/er-model.md)

## Local SQL Server

Edit `ConnectionStrings:MyConnection` in `sb.api.Library/appsettings.json`. The placeholder uses LocalDB and Windows authentication:

```text
Server=$"{CONNECTION_STRING}"
```

Change the server name if you use a full SQL Server instance. As this will be use as cloud repo in the future, no credentials were provided. If you need them please contact with Repo master :b

## Run

From `library_repo`:

```bash
dotnet tool restore
dotnet restore
dotnet build sb.api.Library.slnx
dotnet run --project sb.api.Library
```

Startup applies EF migrations and loads seed data if the tables are empty.

Create later migrations with `ef.cmd add <Name>` and apply them with `ef.cmd update`.

## SSMS checks

```sql
USE LibraryCatalogDb;
GO

SELECT COUNT(*) AS Authors FROM Authors;
SELECT COUNT(*) AS Categories FROM Categories;
SELECT COUNT(*) AS Books FROM Books;

SELECT b.Title, COUNT(ba.AuthorId) AS AuthorCount
FROM Books b
INNER JOIN BookAuthors ba ON ba.BookId = b.Id
GROUP BY b.Title
HAVING COUNT(ba.AuthorId) > 1;

SELECT b.Title, COUNT(bc.CategoryId) AS CategoryCount
FROM Books b
INNER JOIN BookCategories bc ON bc.BookId = b.Id
GROUP BY b.Title
HAVING COUNT(bc.CategoryId) > 1;
```
