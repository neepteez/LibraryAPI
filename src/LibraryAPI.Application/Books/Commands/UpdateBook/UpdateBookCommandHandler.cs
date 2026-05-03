using LibraryAPI.Application.Common.Interfaces;
using MediatR;

namespace LibraryAPI.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        if (book is null) return false;

        book.Title = request.Title;
        book.Description = request.Description;
        book.Year = request.Year;
        book.AuthorId = request.AuthorId;

        await _bookRepository.UpdateAsync(book);
        return true;
    }
}
