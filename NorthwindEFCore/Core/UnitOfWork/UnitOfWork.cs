using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Core.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly NorthwindContext context;
    private IDbContextTransaction transaction;
    public UnitOfWork(NorthwindContext p_context)
    {
        context = p_context;
    }

    public async Task CommitAsync()
    {
        using (transaction =
                await context.Database.BeginTransactionAsync(IsolationLevel.ReadUncommitted))
        {
            try
            {
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
