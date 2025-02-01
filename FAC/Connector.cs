using FAC.Models;
using System.Text;
using System.Text.Json;

namespace FacApi;

public class FACConnector
{
    private readonly string _powerTranzId;
    private readonly string _powerTranzPassword;
    private readonly string _powerTranzCurrency;
    private readonly string _baseUrl;

    public FACConnector(FacParameters parameters)
    {
        _powerTranzCurrency = "320";
        _powerTranzId = parameters.PowerTranzId;
        _powerTranzPassword = parameters.PowerTranzPassword;
        _baseUrl = string.IsNullOrWhiteSpace(parameters.BaseUrl) ? "https://staging.ptranz.com/api/" : parameters.BaseUrl;
    }

    private void SetHeaders(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("PowerTranz-PowerTranzId", _powerTranzId);
        httpClient.DefaultRequestHeaders.Add("PowerTranz-PowerTranzPassword", _powerTranzPassword);
        httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
    }

    public Task<AliveResponse> CheckGatewayStatus() => SendRequestAsync<AliveResponse>("alive", HttpMethod.Get);

    public Task<TransactionResponse> Auth(TransactionRequest model)
    {
        model.CurrencyCode = _powerTranzCurrency;
        model.OrderIdentifier = $"HCB-{Guid.NewGuid()}";
        return SendRequestAsync<TransactionResponse>("spi/auth", HttpMethod.Post, model);
    }

    public Task<TransactionResponse> RiskManagement(TransactionRequest model) => SendRequestAsync<TransactionResponse>("spi/riskmgmt", HttpMethod.Post, model);

    public Task<TransactionResponse> Sale(TransactionRequest model) => SendRequestAsync<TransactionResponse>("spi/sale", HttpMethod.Post, model);

    public Task<TransactionResponse> Payment(string spiToken) => SendRequestAsync<TransactionResponse>("spi/payment", HttpMethod.Post, spiToken);

    public Task<TransactionResponse> Capture(TransactionCaptureRequest model) => SendRequestAsync<TransactionResponse>("capture", HttpMethod.Post, model);

    public Task<TransactionResponse> Refund(TransactionRefundRequest model) => SendRequestAsync<TransactionResponse>("refund", HttpMethod.Post, model);

    public Task<TransactionResponse> Void(TransactionVoidRequest model) => SendRequestAsync<TransactionResponse>("void", HttpMethod.Post, model);

    private async Task<T> SendRequestAsync<T>(string endpoint, HttpMethod method, object? payload = null)
    {
        using (var httpClient = new HttpClient())
        {
            SetHeaders(httpClient);
            HttpResponseMessage response;

            if (method == HttpMethod.Get)
            {
                response = await httpClient.GetAsync(_baseUrl + endpoint);
            }
            else
            {
                var jsonContent = payload != null ? JsonSerializer.Serialize(payload) : string.Empty;
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(_baseUrl + endpoint, content);
            }

            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonResponse)!;
        }
    }
}
