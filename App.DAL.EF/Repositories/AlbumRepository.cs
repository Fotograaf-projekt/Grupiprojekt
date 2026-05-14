using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface IAlbumRepository : IRepository<Album>
{
    Task<List<Album>> AllForPhotographerAsync(int photographerId);
    Task<Album?> GetWithPhotosAsync(int id);
    Task<List<Album>> AllByCategoryAsync(int categoryId);
}

public class AlbumRepository(AppDbContext db) : EFBaseRepository<Album>(db), IAlbumRepository
{
    public Task<List<Album>> AllForPhotographerAsync(int photographerId) =>
        Set.Where(a => a.PhotographerId == photographerId)
           .Include(a => a.Category)
           .Include(a => a.Photos)
           .ToListAsync();

    public Task<Album?> GetWithPhotosAsync(int id) =>
        Set.Include(a => a.Photos)
           .Include(a => a.Category)
           .FirstOrDefaultAsync(a => a.Id == id);
    public Task<List<Album>> AllByCategoryAsync(int categoryId) =>
        Set.Where(a => a.CategoryId == categoryId)
            .Include(a => a.Photos)
            .ToListAsync();
}