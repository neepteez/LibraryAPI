using LibraryAPI.Application.Common.Interfaces;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Description = request.Description,
            Year = request.Year,
            AuthorId = request.AuthorId
        };
        return await _bookRepository.CreateAsync(book);
    }
}
