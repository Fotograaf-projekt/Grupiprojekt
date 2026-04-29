using App.DAL.EF.Repositories;
using App.Domain;

namespace App.BLL;

public class PhotographerService(
    IPhotographerRepository photographerRepo,
    ISocialLinkRepository socialLinkRepo,
    IServiceRepository serviceRepo)
{
    public Task<Photographer?> GetMainAsync() => photographerRepo.GetFirstAsync();

    public async Task UpdateProfileAsync(Photographer p)
    {
        photographerRepo.Update(p);
        await photographerRepo.SaveChangesAsync();
    }

    public Task<SocialLink?> FindSocialLinkAsync(int id) => socialLinkRepo.FindAsync(id);

    public Task<List<SocialLink>> SocialLinksForAsync(int photographerId) =>
        socialLinkRepo.AllForPhotographerAsync(photographerId);

    public async Task AddSocialLinkAsync(SocialLink link)
    {
        if (!Uri.TryCreate(link.Url, UriKind.Absolute, out _))
            throw new ArgumentException("Vigane URL", nameof(link.Url));
        await socialLinkRepo.AddAsync(link);
        await socialLinkRepo.SaveChangesAsync();
    }

    public async Task UpdateSocialLinkAsync(SocialLink link)
    {
        socialLinkRepo.Update(link);
        await socialLinkRepo.SaveChangesAsync();
    }

    public async Task RemoveSocialLinkAsync(int id)
    {
        await socialLinkRepo.RemoveAsync(id);
        await socialLinkRepo.SaveChangesAsync();
    }

    public Task<Service?> FindServiceAsync(int id) => serviceRepo.FindAsync(id);

    public Task<List<Service>> ServicesForAsync(int photographerId) =>
        serviceRepo.AllForPhotographerAsync(photographerId);

    public async Task AddServiceAsync(Service service)
    {
        if (service.Price < 0) throw new ArgumentException("Hind ei saa olla negatiivne");
        await serviceRepo.AddAsync(service);
        await serviceRepo.SaveChangesAsync();
    }

    public async Task UpdateServiceAsync(Service service)
    {
        serviceRepo.Update(service);
        await serviceRepo.SaveChangesAsync();
    }

    public async Task RemoveServiceAsync(int id)
    {
        await serviceRepo.RemoveAsync(id);
        await serviceRepo.SaveChangesAsync();
    }
}
