using DesafioPicPay.Domain.Repositories;

namespace DesafioPicPay.Infrastructure.DataAccess.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DesafioPicPayDbContext _dbContext;
    public UnitOfWork(DesafioPicPayDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}