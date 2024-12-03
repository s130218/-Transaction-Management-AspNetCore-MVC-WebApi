using FinancePortal.Data;
using FinancePortal.Repositories.UOW;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinancePortal.Repositories.GenericRepository;

public class Repository<T> : IRepository<T> where T : class
{
    #region Ctor & Properties

    private readonly DbSet<T> _dbSet;
    public Repository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    #endregion

    #region Method

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity).ConfigureAwait(false);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync().ConfigureAwait(false);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> where)
    {
        return await _dbSet.Where(where).FirstOrDefaultAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;
    }

    #endregion
}
