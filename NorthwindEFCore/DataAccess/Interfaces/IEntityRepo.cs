using System.Linq.Expressions;
namespace DataAccess.Interfaces;
public interface IEntityRepo<T>
            where T : class, new()
{
    IQueryable<T> GetAll();
    IQueryable<T> Where
        (Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(int id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IQueryable<T> entities);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task RemoveRange(IQueryable<T> entities);
}