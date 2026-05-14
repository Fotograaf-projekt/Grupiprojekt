using App.Domain;
using Base.Contracts;

namespace App.DAL.EF.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
}

public class CategoryRepository(AppDbContext db) : EFBaseRepository<Category>(db), ICategoryRepository
{
}