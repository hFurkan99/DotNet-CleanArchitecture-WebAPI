using App.Domain.Entities.Common;
using System.Linq.Expressions;

namespace App.Application.Contracts.Persistence;

public interface IGenericRepository<T, TId> where T : class where TId : struct
{
    Task<List<T>> GetAllAsync();
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(TId id);
    ValueTask<T?> GetByIdAsync(TId id);
    Task<PaginatedResult<T>> GetPagedAsync(int pageNumber, int pageSize);
    ValueTask AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
