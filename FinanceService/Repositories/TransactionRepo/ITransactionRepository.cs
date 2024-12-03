using FinanceService.Models;
using FinanceService.Repositories.GenericRepository;

namespace FinanceService.Repositories.TransactionRepo;

public interface ITransactionRepository : IRepository<TransactionLogs>
{

}
