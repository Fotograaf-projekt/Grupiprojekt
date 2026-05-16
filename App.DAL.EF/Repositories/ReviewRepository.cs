using App.Domain;
using Base.Contracts;

namespace App.DAL.EF.Repositories;

public interface IReviewRepository : IRepository<Review>
{
}

public class ReviewRepository(AppDbContext db) 
    : EFBaseRepository<Review>(db), IReviewRepository
{
}
