using FinancePortal.Dtos;
using FinancePortal.Enum;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static FinancePortal.Dtos.ResponseDto;
namespace FinancePortal.Services;

public class BaseService : IBaseService
{

    #region Ctor & Properties

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string BaseUrl = "https://localhost:7029";

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    #endregion


    #region Methods
    public async Task<ServiceResult<object>> SendAsync(RequestDto requestDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();

        client.Timeout = TimeSpan.FromSeconds(10);

        HttpRequestMessage message = new();

        message.Headers.Add("Accept", "application/json");

        requestDto.Url = BaseUrl + requestDto.Url;

        message.RequestUri = new Uri(requestDto.Url);

        if (requestDto.Url != null)
        {
            message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
        }

        HttpResponseMessage apiResponse = null;

        message.Method = requestDto.ApiType switch
        {
            ApiType.POST => HttpMethod.Post,
            ApiType.DELETE => HttpMethod.Delete,
            ApiType.PUT => HttpMethod.Put,
            _ => HttpMethod.Get,
        };

        try
        {
            apiResponse = await client.SendAsync(message);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { Status = false, Message = ["Not Found"] };
                case HttpStatusCode.Forbidden:
                    return new() { Status = false, Message = ["Access Denied"] };
                case HttpStatusCode.Unauthorized:
                    return new() { Status = false, Message = ["Unauthorized"] };
                case HttpStatusCode.InternalServerError:
                    return new() { Status = false, Message = ["Internal Server Error"] };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ServiceResult<object>>(apiContent);
                    return apiResponseDto;
            }
        }

        catch (HttpRequestException ex)
        {
            return new ServiceResult<object>
            {
                Status = false,
                Message = new List<string> { "Connection refused" },
                MessageType = "ConnectionRefused"
            };
        }

        catch (TaskCanceledException)
        {
            return new ServiceResult<object>
            {
                Status = false,
                Message = new List<string> { "Connection timeout" },
                MessageType = "Timeout"
            };
        }

        catch (Exception)
        {

            throw;
        }
    }
    #endregion
}
