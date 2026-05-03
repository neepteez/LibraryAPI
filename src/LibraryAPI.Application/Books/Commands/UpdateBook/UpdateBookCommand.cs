using MediatR;

namespace LibraryAPI.Application.Books.Commands.UpdateBook;

public record UpdateBookCommand(int Id, string Title, string? Description, int Year, int AuthorId) : IRequest<bool>;
