using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF;

public static class AppDbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.MigrateAsync();

        if (await db.Photographers.AnyAsync()) return;

        var photographer = new Photographer
        {
            Name = "Test Fotograaf",
            Email = "test@fotograaf.ee",
            About = "Tere! Olen fotograaf, kes jäädvustab elu ilusaid hetki.",
            ProfileImageUrl = null,
            SocialLinks = new List<SocialLink>
            {
                new() { Platform = "Instagram", Url = "https://instagram.com/test" },
                new() { Platform = "Facebook", Url = "https://facebook.com/test" }
            },
            Services = new List<Service>
            {
                new() { Name = "Pulmafoto", Price = 500m, Description = "Täispäev pulmas" },
                new() { Name = "Portreesessioon", Price = 120m, Description = "1h stuudios või looduses" }
            }
        };

        db.Photographers.Add(photographer);
        await db.SaveChangesAsync();
    }
}
