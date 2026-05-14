using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface IPhotoRepository : IRepository<Photo>
{
    Task<List<Photo>> AllForAlbumAsync(int albumId);
}

public class PhotoRepository(AppDbContext db) : EFBaseRepository<Photo>(db), IPhotoRepository
{
    public Task<List<Photo>> AllForAlbumAsync(int albumId) =>
        Set.Where(p => p.AlbumId == albumId)
           .Include(p => p.Category)
           .ToListAsync();
}