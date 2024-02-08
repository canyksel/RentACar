using System.Linq.Expressions;

namespace Core.Repositories;

public interface IAsyncRepository<T> where T : Entity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
