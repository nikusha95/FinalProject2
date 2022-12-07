using System.Linq.Expressions;

namespace Repository.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
        Expression<Func<T, object>>[] includes = null);

    Task<T> GetByIdAsync(int id);
    Task AddAsync(T obj);
    void Update(T obj);
    void Delete(int id);
    Task SaveAsync();
}