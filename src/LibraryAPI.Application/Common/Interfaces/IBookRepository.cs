using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Common.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Book book);
}
