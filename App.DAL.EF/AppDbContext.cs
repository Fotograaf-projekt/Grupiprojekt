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
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
    public DbSet<Availability> Availabilities => Set<Availability>();
   

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

        builder.Entity<ContactMessage>()
            .HasOne(m => m.Client)
            .WithMany(c => c.ContactMessages)
            .HasForeignKey(m => m.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ContactMessage>()
            .HasOne(m => m.Service)
            .WithMany()
            .HasForeignKey(m => m.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Client>()
            .HasMany(c => c.Bookings)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Availability>()
            .HasOne(a => a.Booking)
            .WithOne()
            .HasForeignKey<Availability>(a => a.BookingId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
