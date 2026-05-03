using LibraryAPI.Application.Common.Interfaces;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book?>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        => await _bookRepository.GetByIdAsync(request.Id);
}
