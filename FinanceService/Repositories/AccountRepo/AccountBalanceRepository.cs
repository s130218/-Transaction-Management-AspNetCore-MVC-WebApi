using FinanceService.Data;
using FinanceService.Models;
using FinanceService.Repositories.GenericRepository;
using FinanceService.Repositories.TransactionRepo;

namespace FinanceService.Repositories.AccountRepo;

public class AccountBalanceRepository : Repository<AccountBalance>, IAccountBalanceRepository
{
    public AccountBalanceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
