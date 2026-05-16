using App.Domain;
using Base.Contracts;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.EF.Repositories;

public interface IInvoiceRepository : IRepository<Invoice> {
     Task<Invoice?> FindByBookingAsync(int bookingId);
    Task<Invoice?> FindWithDetailsAsync(int id);
    Task<List<Invoice>> AllWithDetailsAsync();
}

public class InvoiceRepository(AppDbContext db) 
    : EFBaseRepository<Invoice>(db), IInvoiceRepository
{
     public async Task<Invoice?> FindByBookingAsync(int bookingId) =>
        await Set
            .Include(i => i.Booking)
            .FirstOrDefaultAsync(i => i.BookingId == bookingId);

    public async Task<Invoice?> FindWithDetailsAsync(int id) =>
        await Set
            .Include(i => i.Booking)
                .ThenInclude(b => b!.Client)
            .FirstOrDefaultAsync(i => i.Id == id);

    public async Task<List<Invoice>> AllWithDetailsAsync() =>
        await Set
            .Include(i => i.Booking)
                .ThenInclude(b => b!.Client)
            .OrderByDescending(i => i.IssuedDate)
            .ToListAsync();
}
