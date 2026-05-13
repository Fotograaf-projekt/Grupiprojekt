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
    public DbSet<Album> Albums { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Category> Categories { get; set; }

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

        builder.Entity<Album>()
            .HasOne(a => a.Photographer)
            .WithMany()
            .HasForeignKey(a => a.PhotographerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Album>()
            .HasOne(a => a.Category)
            .WithMany(c => c.Albums)
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Photo>()
            .HasOne(p => p.Album)
            .WithMany(a => a.Photos)
            .HasForeignKey(p => p.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Photo>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Photos)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
            }
}
