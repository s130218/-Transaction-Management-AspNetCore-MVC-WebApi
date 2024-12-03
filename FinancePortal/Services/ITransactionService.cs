using FinancePortal.Dtos;
using FinancePortal.Models;
using static FinancePortal.Dtos.ResponseDto;

namespace FinancePortal.Services
{
    public interface ITransactionService
    {
        Task<ServiceResult<Transaction>> AddTransactionAsync(Transaction transaction);
        Task<ServiceResult<List<Transaction>>> GetAllAsync();
        Task<ServiceResult> CheckStatusAsync(CheckStatusDto dto);
    }
}
