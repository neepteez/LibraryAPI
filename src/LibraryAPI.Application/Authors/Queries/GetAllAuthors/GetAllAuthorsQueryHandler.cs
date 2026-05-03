using LibraryAPI.Application.Common.Interfaces;
using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Authors.Queries.GetAllAuthors;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        => await _authorRepository.GetAllAsync();
}
