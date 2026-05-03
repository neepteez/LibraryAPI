using LibraryAPI.Application.Common.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
        => await _context.Authors.Include(a => a.Books).ToListAsync();

    public async Task<Author?> GetByIdAsync(int id)
        => await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);

    public async Task<Author> CreateAsync(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return author;
    }
}
