using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Books.Commands.CreateBook;

public record CreateBookCommand(string Title, string? Description, int Year, int AuthorId) : IRequest<Book>;
