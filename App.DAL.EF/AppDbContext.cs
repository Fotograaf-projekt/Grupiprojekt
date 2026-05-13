using System.Drawing;
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
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Print> Print => Set<Print>();
    public DbSet<PhotoTag> PhotoTags => Set<PhotoTag>();
    public DbSet<Tag> Tags => Set<Tag>();

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

        builder.Entity<Print>()
            .HasOne(p => p.Photographer)
            .WithMany(ph => ph.Print)
            .HasForeignKey(p => p.PrintId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Tag>()
            .HasOne(p => p.Photographer)
            .WithMany(ph => ph.Tags)
            .HasForeignKey(p => p.TagId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<PhotoTag>()
            .HasOne(pt => pt.Photographer)
            .WithMany(p => p.PhotoTags)
            .HasForeignKey(pt => pt.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
