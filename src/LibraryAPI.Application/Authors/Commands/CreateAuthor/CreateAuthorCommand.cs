using LibraryAPI.Domain.Entities;
using MediatR;

namespace LibraryAPI.Application.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(string Name, string? Bio) : IRequest<Author>;
