namespace Core.UnitOfWork;
public interface IUnitOfWork
{
    Task CommitAsync();
}
