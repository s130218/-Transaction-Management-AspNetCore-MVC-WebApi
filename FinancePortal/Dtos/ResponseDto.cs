using FinancePortal.Enum;

namespace FinancePortal.Dtos;

public class ResponseDto
{
    public class ServiceResult
    {
        public string MessageType { get; set; }
        public List<string> Message { get; set; }
        public bool Status { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        private T ResposeData { get; set; }
        public T Data
        {
            get => ResposeData;
            set => ResposeData = value;
        }
    }

}
