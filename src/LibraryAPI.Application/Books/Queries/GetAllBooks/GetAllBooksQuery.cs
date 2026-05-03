using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Books.Queries.GetAllBooks;

public record GetAllBooksQuery : IRequest<IEnumerable<Book>>;
