using FinanceService.Dtos;
using FinanceService.Models;

namespace FinanceService.Factories
{
    public interface ITransactionFactory
    {
        TransactionLogs MapCreateDtoToEntity(TransactionCreateDto dto);
        TransactionLogsDto MapEntityToDto(TransactionLogs entity);
    }
}
