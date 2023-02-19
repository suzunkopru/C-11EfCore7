using Business.Interfaces;
using DataAccess.Interfaces;
using System.Linq.Expressions;
namespace Business.Classes;
public class Service<T> : IService<T>
                where T : class, new()
{
    private readonly IEntityRepo<T> entityRepo;
    public Service(IEntityRepo<T> p_entityRepo) => entityRepo = p_entityRepo;
    public IQueryable<T> GetAll() => entityRepo.GetAll();
    public IQueryable<T> Where
        (Expression<Func<T, bool>> predicate)
        => entityRepo.Where(predicate);
    public async Task<T> GetByIdAsync(int id)
        => await entityRepo.GetByIdAsync(id);
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        => await entityRepo.AnyAsync(predicate);
    public async Task AddAsync(T entity)
        => await entityRepo.AddAsync(entity);
    public async Task AddRangeAsync(IQueryable<T> entities)
    {
        foreach (var x in entities) await AddAsync(x);
    }
    public async Task UpdateAsync(T entity)
        => await entityRepo.UpdateAsync(entity);
    public async Task RemoveAsync(T entity)
        => await entityRepo.RemoveAsync(entity);
    public async Task RemoveRangeAsync(IQueryable<T> entities)
        => entities.ToList().ForEach(async x => await RemoveAsync(x));
}