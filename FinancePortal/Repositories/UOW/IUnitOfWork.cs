namespace FinancePortal.Repositories.UOW;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    Task CommitAsync();
}
