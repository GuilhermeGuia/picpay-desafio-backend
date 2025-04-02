namespace DesafioPicPay.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}