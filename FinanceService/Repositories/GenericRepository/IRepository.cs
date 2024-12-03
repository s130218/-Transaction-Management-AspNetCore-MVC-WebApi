using FinanceService.Repositories.UOW;
using System.Linq.Expressions;

namespace FinanceService.Repositories.GenericRepository
{
    public interface IRepository<T> : IUnitOfWork where T : class
    {
        Task AddAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> GetAsync(Expression<Func<T, bool>> where);
    }
}
