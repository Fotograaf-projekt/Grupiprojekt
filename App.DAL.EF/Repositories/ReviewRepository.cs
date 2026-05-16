using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<List<Review>> AllForBookingAsync(int bookingId);
    Task<List<Review>> AllWithDetailsAsync();
}

public class ReviewRepository(AppDbContext db) 
    : EFBaseRepository<Review>(db), IReviewRepository
{
    public async Task<List<Review>> AllForBookingAsync(int bookingId) =>
        await Set
            .Where(r => r.BookingId == bookingId)
            .ToListAsync();

    public async Task<List<Review>> AllWithDetailsAsync() =>
        await Set
            .Include(r => r.Booking)
            .OrderByDescending(r => r.Id)
            .ToListAsync();
}
