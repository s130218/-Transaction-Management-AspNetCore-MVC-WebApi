using FinanceService.Data;
using FinanceService.Models;
using FinanceService.Repositories.GenericRepository;

namespace FinanceService.Repositories.TransactionRepo
{
    public class TransactionRepository : Repository<TransactionLogs>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
