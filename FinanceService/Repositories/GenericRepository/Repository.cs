using FinanceService.Data;
using FinanceService.Repositories.UOW;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceService.Repositories.GenericRepository
{
    public class Repository<T> : UnitOfWork, IRepository<T> where T : class
    {
        #region Ctor & Properties

        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        #endregion

        #region Implementation

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        #endregion
    }
}
