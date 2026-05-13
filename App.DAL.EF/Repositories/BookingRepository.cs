using System;
using App.Domain;
using Base.Contracts;

namespace App.DAL.EF.Repositories;

public interface IBookingRepository : IRepository<Booking>
{
}

public class BookingRepository(AppDbContext db) 
    : EFBaseRepository<Booking>(db), IBookingRepository
{
}
