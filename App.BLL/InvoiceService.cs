using App.DAL.EF.Repositories;
using App.Domain;

namespace App.BLL;

public class InvoiceService(IInvoiceRepository invoiceRepo)
{
    
    public Task<List<Invoice>> GetAllAsync() =>
        invoiceRepo.AllWithDetailsAsync();

    public Task<Invoice?> FindAsync(int id) =>
        invoiceRepo.FindWithDetailsAsync(id);

    public Task<Invoice?> FindByBookingAsync(int bookingId) =>
        invoiceRepo.FindByBookingAsync(bookingId);

    public async Task<Invoice> CreateAsync(int bookingId, decimal amount)
    {
        var existing = await invoiceRepo.FindByBookingAsync(bookingId);
        if (existing != null)
            throw new ArgumentException("Sellel broneeringul on juba arve.");

        var invoice = new Invoice
        {
            BookingId  = bookingId,
            Amount     = amount,
            IssuedDate = DateTime.Today,
            Status     = "Unpaid"
        };

        await invoiceRepo.AddAsync(invoice);
        await invoiceRepo.SaveChangesAsync();

        return invoice;
    }

    public Task MarkAsPaidAsync(int id)       => ChangeStatusAsync(id, "Paid");
    public Task MarkAsCancelledAsync(int id)  => ChangeStatusAsync(id, "Cancelled");

    private async Task ChangeStatusAsync(int id, string newStatus)
    {
        var invoice = await invoiceRepo.FindAsync(id)
                      ?? throw new ArgumentException($"Arve #{id} ei leitud.");
        invoice.Status = newStatus;
        invoiceRepo.Update(invoice);
        await invoiceRepo.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await invoiceRepo.RemoveAsync(id);
        await invoiceRepo.SaveChangesAsync();
    }
}
