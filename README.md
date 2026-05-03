# LibraryAPI — Clean Architecture Web API

Ett ASP.NET Core 8 Web API byggt med **Clean Architecture**, **CQRS**, **MediatR**, **Repository Pattern** och **Entity Framework Core** med SQLite.

## Projektstruktur

```
LibraryAPI/
├── LibraryAPI.sln
└── src/
    ├── LibraryAPI.API            # Controllers, Program.cs, Swagger
    ├── LibraryAPI.Application    # CQRS Commands/Queries, MediatR, Interfaces
    ├── LibraryAPI.Domain         # Entiteter: Author, Book
    └── LibraryAPI.Infrastructure # EF Core, Repositories, Migrations
```

## Domänmodell

- **Author** — Namn och bio
- **Book** — Titel, beskrivning, år och koppling till Author
- **Relation:** En Author kan ha många Books (1-till-många)

## Kom igång

### Krav
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Kör lokalt

```bash
git clone <ditt-repo-url>
cd LibraryAPI/src/LibraryAPI.API
dotnet run
```

Databasen (SQLite) skapas automatiskt vid första start.
Swagger finns på: `https://localhost:<PORT>/swagger`

### Skapa nya migrations (om du ändrat modellerna)

```bash
cd LibraryAPI/src/LibraryAPI.API
dotnet ef migrations add <NamnPåMigration> --project ../LibraryAPI.Infrastructure --startup-project .
dotnet ef database update
```

## API Endpoints

### Books (full CRUD)

| Method | Endpoint | Beskrivning |
|--------|----------|-------------|
| GET | /api/books | Hämta alla böcker |
| GET | /api/books/{id} | Hämta en bok |
| POST | /api/books | Skapa ny bok |
| PUT | /api/books/{id} | Uppdatera bok |
| DELETE | /api/books/{id} | Ta bort bok |

### Authors

| Method | Endpoint | Beskrivning |
|--------|----------|-------------|
| GET | /api/authors | Hämta alla författare |
| GET | /api/authors/{id} | Hämta en författare |
| POST | /api/authors | Skapa ny författare |

## Exempel — skapa en Author och en Book

```json
// POST /api/authors
{
  "name": "J.K. Rowling",
  "bio": "Brittisk författare, känd för Harry Potter-serien."
}

// POST /api/books
{
  "title": "Harry Potter och de vises sten",
  "description": "Den första boken i Harry Potter-serien.",
  "year": 1997,
  "authorId": 1
}
```

## Arkitektur

### Clean Architecture — beroenderegel
Beroenden pekar alltid **inåt**. Yttre lager känner till inre, aldrig tvärtom.

```
API → Application → Domain
Infrastructure → Application → Domain
```

### CQRS + MediatR
Alla läsoperationer är `Queries` och alla skrivoperationer är `Commands`.
Controllers använder aldrig repositories direkt — alltid via `IMediator`.

### Repository Pattern
`IBookRepository` och `IAuthorRepository` definieras i **Application**.
Implementationerna (`BookRepository`, `AuthorRepository`) bor i **Infrastructure** och injiceras via DI.

