using FinanceService.Models;

namespace FinanceService.Services;

public interface ITransactionService
{
    Task<ServiceResult<TransactionLogs>> AddTransactionAsync(TransactionLogs entity);

    Task<ServiceResult<TransactionLogs>> CheckStatusByTransactionIdAsync(Guid transactionId);
}
