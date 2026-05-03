using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Common.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task<Author> CreateAsync(Author author);
}
