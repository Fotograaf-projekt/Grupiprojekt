using Base.Domain;

namespace Base.Contracts;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> AllAsync();
    Task<TEntity?> FindAsync(int id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task RemoveAsync(int id);
    Task<int> SaveChangesAsync();
}
