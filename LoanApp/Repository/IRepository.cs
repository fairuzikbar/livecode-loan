using System.Linq.Expressions;

namespace LoanApp.Repository;

public interface IRepository<TEntity>
{
    Task<TEntity> SaveAsync(TEntity entity);
    TEntity Attach(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, string[] includes);
    Task<List<TEntity>> FindAllAsync();
    Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria);
    Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
}