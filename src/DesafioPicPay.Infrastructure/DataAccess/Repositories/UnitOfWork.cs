using DesafioPicPay.Domain.Repositories;

namespace DesafioPicPay.Infrastructure.DataAccess.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DesafioPicPayDbContext _dbContext;
    public UnitOfWork(DesafioPicPayDbContext dbContext) => _dbContext = dbContext;

    public async Task BeginTransactionAsync()
    {
        await _dbContext.Database.BeginTransactionAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    public async Task CommitAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();
    }
    public async Task RollbackAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}