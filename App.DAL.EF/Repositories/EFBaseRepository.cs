using Base.Contracts;
using Base.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public abstract class EFBaseRepository<TEntity>(AppDbContext db) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly AppDbContext Db = db;
    protected readonly DbSet<TEntity> Set = db.Set<TEntity>();

    public virtual async Task<List<TEntity>> AllAsync() => await Set.ToListAsync();

    public virtual async Task<TEntity?> FindAsync(int id) => await Set.FindAsync(id);

    public async Task AddAsync(TEntity entity) => await Set.AddAsync(entity);

    public void Update(TEntity entity) => Set.Update(entity);

    public async Task RemoveAsync(int id)
    {
        var entity = await Set.FindAsync(id);
        if (entity != null) Set.Remove(entity);
    }

    public async Task<int> SaveChangesAsync() => await Db.SaveChangesAsync();
}
