using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface IServiceRepository : IRepository<Service>
{
    Task<List<Service>> AllForPhotographerAsync(int photographerId);
}

public class ServiceRepository(AppDbContext db) : EFBaseRepository<Service>(db), IServiceRepository
{
    public Task<List<Service>> AllForPhotographerAsync(int photographerId) =>
        Set.Where(s => s.PhotographerId == photographerId).ToListAsync();
}
