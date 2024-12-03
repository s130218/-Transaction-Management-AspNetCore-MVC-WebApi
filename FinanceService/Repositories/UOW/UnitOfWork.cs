using FinanceService.Data;

namespace FinanceService.Repositories.UOW;

public class UnitOfWork : IUnitOfWork
{
    protected readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
    }

    public void Commit()
    {
        _db.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
