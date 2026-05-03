using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Books.Queries.GetBookById;

public record GetBookByIdQuery(int Id) : IRequest<Book?>;
