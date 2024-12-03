using FinanceService.Dtos;
using FinanceService.Models;

namespace FinanceService.Factories
{
    public class TransactionFactory : ITransactionFactory
    {
        public TransactionLogs MapCreateDtoToEntity(TransactionCreateDto dto)
        {
            TransactionLogs entity = new()
            {
                TransactionId = dto.TransactionId,
                AccountNumber = dto.AccountNumber,
                Amount = dto.Amount,
                Status = dto.Status,
                CreatedDate = DateTime.Now,
                CreatedBy = Guid.NewGuid()
            };

            return entity;
        }

        public TransactionLogsDto MapEntityToDto(TransactionLogs entity)
        {
            TransactionLogsDto dto = new();
            {
                dto.TransactionId = entity.TransactionId;
                dto.Status = entity.Status;
                dto.Amount = entity.Amount;
            }
            return dto;
        }
    }
}
