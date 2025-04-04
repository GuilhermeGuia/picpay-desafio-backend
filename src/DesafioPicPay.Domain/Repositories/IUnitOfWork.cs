namespace DesafioPicPay.Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    Task RollbackAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
}