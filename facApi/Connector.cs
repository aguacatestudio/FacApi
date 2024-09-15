using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace FacApi;

public class FACConnector
{
    private readonly string _powerTranzId;
    private readonly string _powerTranzPassword;
    private readonly string _baseUrl;

    public FACConnector(string powerTranzId, string powerTranzPassword, string baseurl)
    {
        _powerTranzId = powerTranzId;
        _powerTranzPassword = powerTranzPassword;
        _baseUrl = string.IsNullOrWhiteSpace(baseurl) ? "https://staging.ptranz.com/api/" : baseurl;
    }

    private void SetHeaders(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("PowerTranz-PowerTranzId", _powerTranzId);
        httpClient.DefaultRequestHeaders.Add("PowerTranz-PowerTranzPassword", _powerTranzPassword);
        httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
    }

    private async Task<TransactionResponse> SendRequestAsync<T>(string endpoint, T model)
    {
        using (var httpClient = new HttpClient())
        {
            SetHeaders(httpClient);
            var jsonContent = JsonSerializer.Serialize(model);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(_baseUrl + endpoint, content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TransactionResponse>(jsonResponse);
        }
    }

    public Task<TransactionResponse> Auth(TransactionRequest model)
    {
        return SendRequestAsync("auth", model);
    }

    public Task<TransactionResponse> Capture(TransactionDetail model)
    {
        return SendRequestAsync("capture", model);
    }

    public Task<TransactionResponse> RiskManagement(TransactionRequest model)
    {
        return SendRequestAsync("riskmgmt", model);
    }

    public Task<TransactionResponse> Payment(string spiToken)
    {
        return SendRequestAsync("payment", spiToken);
    }

    public Task<TransactionResponse> Sale(TransactionRequest model)
    {
        return SendRequestAsync("sale", model);
    }

    public Task<TransactionResponse> Refund(TransactionRequest model)
    {
        return SendRequestAsync("refund", model);
    }

    public Task<TransactionResponse> Void(TransactionDetail model)
    {
        return SendRequestAsync("void", model);
    }
}
