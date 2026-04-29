using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface ISocialLinkRepository : IRepository<SocialLink>
{
    Task<List<SocialLink>> AllForPhotographerAsync(int photographerId);
}

public class SocialLinkRepository(AppDbContext db) : EFBaseRepository<SocialLink>(db), ISocialLinkRepository
{
    public Task<List<SocialLink>> AllForPhotographerAsync(int photographerId) =>
        Set.Where(s => s.PhotographerId == photographerId).ToListAsync();
}
