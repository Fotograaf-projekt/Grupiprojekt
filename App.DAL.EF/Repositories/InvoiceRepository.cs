using App.Domain;
using Base.Contracts;

namespace App.DAL.EF.Repositories;

public interface IInvoiceRepository : IRepository<Invoice>
{
}

public class InvoiceRepository(AppDbContext db) 
    : EFBaseRepository<Invoice>(db), IInvoiceRepository
{
}
