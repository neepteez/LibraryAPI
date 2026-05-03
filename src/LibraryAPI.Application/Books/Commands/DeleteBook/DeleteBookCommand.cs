using MediatR;

namespace LibraryAPI.Application.Books.Commands.DeleteBook;

public record DeleteBookCommand(int Id) : IRequest<bool>;
