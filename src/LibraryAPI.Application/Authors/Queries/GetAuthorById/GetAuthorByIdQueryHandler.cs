using LibraryAPI.Application.Common.Interfaces;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Authors.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author?>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<Author?> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        => await _authorRepository.GetByIdAsync(request.Id);
}
