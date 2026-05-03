using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Authors.Queries.GetAllAuthors;

public record GetAllAuthorsQuery : IRequest<IEnumerable<Author>>;
