using FinanceService.Models;
using FinanceService.Repositories.AccountRepo;
using FinanceService.Repositories.TransactionRepo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinanceService.Services;

public class TransactionService : ITransactionService
{
    #region Ctor & Properties
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountBalanceRepository _accountBalanceRepository;

    public TransactionService(ITransactionRepository transactionRepository, IAccountBalanceRepository accountBalanceRepository)
    {
        _transactionRepository = transactionRepository;
        _accountBalanceRepository = accountBalanceRepository;
    }

    #endregion

    public async Task<ServiceResult<TransactionLogs>> AddTransactionAsync(TransactionLogs entity)
    {
        var isExist = await _transactionRepository.GetAsync(x => x.TransactionId == entity.TransactionId).ConfigureAwait(false);

        if (isExist != null)
            return ServiceResult<TransactionLogs>.Fail("Record Already Exist");

        Random random = new Random();
        int randomNumber = random.Next(1, 4); 

        switch (randomNumber)
        {
            case 1:
                await Task.Delay(TimeSpan.FromSeconds(15));
                entity.Status = TransactionStatus.FAILED;
                break;
            case 2:
                await Task.Delay(TimeSpan.FromSeconds(30));
                entity.Status = TransactionStatus.FAILED;
                break;
            case 3:
                await Task.Delay(TimeSpan.FromSeconds(30));
                entity.Status = TransactionStatus.SUCCESS;
                break;
            default:
                entity.Status = TransactionStatus.SUCCESS;
                break;
        }

        if (randomNumber == 1 || randomNumber == 2 || randomNumber == 3)
        {
            await _transactionRepository.AddAsync(entity).ConfigureAwait(false);
            await _transactionRepository.CommitAsync().ConfigureAwait(false);

            return new ServiceResult<TransactionLogs>(false) { Data = entity };
        }

        await _transactionRepository.AddAsync(entity).ConfigureAwait(false);
        await _transactionRepository.CommitAsync().ConfigureAwait(false);

        return ServiceResult<TransactionLogs>.Success("Transaction done successfully");
    }

    public async Task<ServiceResult<TransactionLogs>> CheckStatusByTransactionIdAsync(Guid transactionId)
    {
        var data = await _transactionRepository.GetAsync(x => x.TransactionId == transactionId).ConfigureAwait(false);

        if (data == null)
            return ServiceResult<TransactionLogs>.Fail("Record Not Found");

        return new ServiceResult<TransactionLogs>(true) { Data = data };
    }

    public async Task<ServiceResult<AccountBalance>> GetBalanceByAccountNumber(string AccountNumber)
    {
        var data = await _accountBalanceRepository.GetAsync(x => x.AccountNumber == AccountNumber).ConfigureAwait(false);

        if (data == null)
            return ServiceResult<AccountBalance>.Fail("Record Not Found");

        return new ServiceResult<AccountBalance>(true) { Data = data };
    }

}
