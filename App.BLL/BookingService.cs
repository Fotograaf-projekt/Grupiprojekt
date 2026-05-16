using App.DAL.EF.Repositories;
using App.Domain;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
 
namespace App.BLL;
 
public class BookingService(
    IBookingRepository bookingRepo,
    AppDbContext db)
{
  
    public Task<List<Booking>> GetAllAsync() =>
        bookingRepo.AllWithDetailsAsync();
 
    public Task<List<Booking>> GetForClientAsync(int clientId) =>
        bookingRepo.AllForClientAsync(clientId);
 
    public Task<Booking?> FindAsync(int id) =>
        bookingRepo.FindWithDetailsAsync(id);

 
    public async Task<Booking> CreateAsync(
        string clientName,
        string clientEmail,
        DateTime date)
    {
        if (date.Date < DateTime.Today)
            throw new ArgumentException("Cannot book a past date.");
 
        
        var client = await db.Clients
            .FirstOrDefaultAsync(c => c.Email == clientEmail.Trim().ToLower());
 
        if (client == null)
        {
            client = new Client
            {
                Name  = clientName.Trim(),
                Email = clientEmail.Trim().ToLower()
            };
            db.Clients.Add(client);
            await db.SaveChangesAsync();
        }
 
        var booking = new Booking
        {
            ClientId = client.Id,
            Date     = date,
            Status   = "Pending",
            Total    = 0  // сумма будет выставлена через Invoice
        };
 
        await bookingRepo.AddAsync(booking);
        await bookingRepo.SaveChangesAsync();
 
        return booking;
    }
 
    public Task ConfirmAsync(int id)  => ChangeStatusAsync(id, "Confirmed");
    public Task CancelAsync(int id)   => ChangeStatusAsync(id, "Cancelled");
    public Task CompleteAsync(int id) => ChangeStatusAsync(id, "Completed");
 
    private async Task ChangeStatusAsync(int bookingId, string newStatus)
    {
        var booking = await bookingRepo.FindAsync(bookingId)
                      ?? throw new ArgumentException($"Booking #{bookingId} not found.");
        booking.Status = newStatus;
        bookingRepo.Update(booking);
        await bookingRepo.SaveChangesAsync();
    }
 

    public async Task DeleteAsync(int id)
    {
        await bookingRepo.RemoveAsync(id);
        await bookingRepo.SaveChangesAsync();
    }
}
