using FinancePortal.Dtos;
using static FinancePortal.Dtos.ResponseDto;

namespace FinancePortal.Services;

public interface IBaseService
{
    Task<ServiceResult<object>> SendAsync(RequestDto requestDto);
}
