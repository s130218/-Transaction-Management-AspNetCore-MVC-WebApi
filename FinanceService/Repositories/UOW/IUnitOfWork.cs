namespace FinanceService.Repositories.UOW;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    Task CommitAsync();
}
