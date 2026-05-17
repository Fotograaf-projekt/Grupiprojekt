using System;
using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public interface IBookingRepository : IRepository<Booking>
{
     Task<List<Booking>> AllWithDetailsAsync();
    Task<List<Booking>> AllForClientAsync(int clientId);
    Task<Booking?> FindWithDetailsAsync(int id);
}

public class BookingRepository(AppDbContext db) 
    : EFBaseRepository<Booking>(db), IBookingRepository
{
     public async Task<List<Booking>> AllWithDetailsAsync() =>
        await Set
            .Include(b => b.Client)
            .Include(b => b.Availability)
            .Include(b => b.Invoice)
            .OrderByDescending(b => b.Date)
            .ToListAsync();
 
    public async Task<List<Booking>> AllForClientAsync(int clientId) =>
        await Set
            .Where(b => b.ClientId == clientId)
            .Include(b => b.Availability)
            .Include(b => b.Invoice)
            .OrderByDescending(b => b.Date)
            .ToListAsync();
 
    public async Task<Booking?> FindWithDetailsAsync(int id) =>
        await Set
            .Include(b => b.Client)
            .Include(b => b.Availability)
            .Include(b => b.Invoice)
            .Include(b => b.Reviews)
            .FirstOrDefaultAsync(b => b.Id == id);
}
