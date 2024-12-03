using System.Linq.Expressions;

namespace FinancePortal.Repositories.GenericRepository;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetAsync(Expression<Func<T, bool>> where);

    void Update(T entity);

}