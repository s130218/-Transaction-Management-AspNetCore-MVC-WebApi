using FinanceService.Factories;
using FinanceService.Repositories.AccountRepo;
using FinanceService.Repositories.GenericRepository;
using FinanceService.Repositories.TransactionRepo;
using FinanceService.Repositories.UOW;
using FinanceService.Services;

namespace FinanceService.DependencyRegistration
{
    public class DependencyRegistrar
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //Common
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //Repository
            services.AddScoped(typeof(ITransactionRepository), typeof(TransactionRepository));
            services.AddScoped(typeof(IAccountBalanceRepository), typeof(AccountBalanceRepository));

            //Service
            services.AddScoped(typeof(ITransactionService), typeof(TransactionService));

            //Factory
            services.AddScoped(typeof(ITransactionFactory), typeof(TransactionFactory));


        }
    }
}
