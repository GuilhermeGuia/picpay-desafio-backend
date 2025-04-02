using System.Linq.Expressions;

namespace DesafioPicPay.Domain.Repositories;

public interface IRepository<T> where T : class
{
    Task<IList<T>> Get();
    Task<IList<T>> Get(Expression<Func<T, bool>> predicate);
    Task<T> Find(Expression<Func<T, bool>> predicate);
    Task<T> GetById(long Id);
    Task Add(T entity);
    void Update(T entity);
    void UpdateRange(T[] entities);
    void Delete(T entity);
}