using FinancePortal.Enum;

namespace FinancePortal.Dtos;

public class RequestDto
{
    public ApiType ApiType { get; set; } = ApiType.GET;

    public string Url { get; set; }

    public object Data { get; set; }
}
