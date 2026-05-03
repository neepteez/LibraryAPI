using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Authors.Queries.GetAuthorById;

public record GetAuthorByIdQuery(int Id) : IRequest<Author?>;
