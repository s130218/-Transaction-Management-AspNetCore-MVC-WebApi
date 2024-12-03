using FinancePortal.Dtos;
using FinancePortal.Models;

namespace FinancePortal.Factories;

public interface ITransactionFactory
{
    Transaction MapCreateDtoToEntity(TransactionDto dto);
}
