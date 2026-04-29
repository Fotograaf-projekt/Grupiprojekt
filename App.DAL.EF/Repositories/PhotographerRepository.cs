using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface IPhotographerRepository : IRepository<Photographer>
{
    Task<Photographer?> GetWithDetailsAsync(int id);
    Task<Photographer?> GetFirstAsync();
}

public class PhotographerRepository(AppDbContext db) : EFBaseRepository<Photographer>(db), IPhotographerRepository
{
    public Task<Photographer?> GetWithDetailsAsync(int id) =>
        Set.Include(p => p.SocialLinks)
           .Include(p => p.Services)
           .FirstOrDefaultAsync(p => p.Id == id);

    public Task<Photographer?> GetFirstAsync() =>
        Set.Include(p => p.SocialLinks)
           .Include(p => p.Services)
           .FirstOrDefaultAsync();
}
