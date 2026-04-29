using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Photographer> Photographers => Set<Photographer>();
    public DbSet<SocialLink> SocialLinks => Set<SocialLink>();
    public DbSet<Service> Services => Set<Service>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Photographer>()
            .HasIndex(p => p.Email)
            .IsUnique();

        builder.Entity<SocialLink>()
            .HasOne(s => s.Photographer)
            .WithMany(p => p.SocialLinks)
            .HasForeignKey(s => s.PhotographerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Service>()
            .HasOne(s => s.Photographer)
            .WithMany(p => p.Services)
            .HasForeignKey(s => s.PhotographerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
