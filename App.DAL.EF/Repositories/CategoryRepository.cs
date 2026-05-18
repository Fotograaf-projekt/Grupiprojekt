using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<List<Category>> AllWithAlbumsAsync();
}

public class CategoryRepository(AppDbContext db) : EFBaseRepository<Category>(db), ICategoryRepository
{
    public Task<List<Category>> AllWithAlbumsAsync() =>
        Set.Include(c => c.Albums!)
           .ThenInclude(a => a.Photos)
           .ToListAsync();
}