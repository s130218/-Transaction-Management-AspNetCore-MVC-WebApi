using FinancePortal.Dtos;
using FinancePortal.Models;

namespace FinancePortal.Factories;

public class TransactionFactory : ITransactionFactory
{
    public Transaction MapCreateDtoToEntity(TransactionDto dto)
    {
        Transaction entity = new()
        {
            TransactionId = Guid.NewGuid(),
            AccountNumber = dto.AccountNumber,
            Amount = dto.Amount,
            Status = dto.Status,
            CreatedDate = DateTime.Now,
            CreatedBy = Guid.NewGuid()
        };

        return entity;
    }
}
