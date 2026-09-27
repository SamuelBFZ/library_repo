# Library Catalog (`sb.api.Library`)

Read-only library catalog on **.NET 10**, **SQL Server**, and **Entity Framework Core**. The API exposes paginated catalog reads for books, authors, and categories.

## Solution

```text
sb.api.Library.slnx
├── sb.api.Library                 API host (controllers, OpenAPI, migrate + seed)
├── sb.api.Library.Application     use cases, mediator, pagination, query contracts
├── sb.api.Library.Domain          Book, Author, Category
└── sb.api.Library.Persistence     EF Core, SQL Server, seeders, query repositories
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

Default URLs: `http://localhost:5127` and `https://localhost:7183`. OpenAPI in Development: `/openapi/v1.json`.

## Read endpoints

Query params on list routes: `pageNumber` (default 1), `pageSize` (default 15, max 50), optional `search`.

| Method | Route |
| --- | --- |
| GET | `/api/books` |
| GET | `/api/books/{id}` |
| GET | `/api/authors` |
| GET | `/api/authors/{id}` |
| GET | `/api/categories` |
| GET | `/api/categories/{id}` |

Missing resources return **404**. List and found resources return **200**.

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
