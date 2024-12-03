using FinancePortal.Data;
using FinancePortal.Models;
using FinancePortal.Repositories.GenericRepository;

namespace FinancePortal.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

}
