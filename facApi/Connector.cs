namespace FacApi;

public class FACConnector
{
    private readonly string _powerTranzId;
    private readonly string _powerTranzPassword;
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;

    public FACConnector(string powerTranzId, string powerTranzPassword, string baseurl)
    {
        _powerTranzId = powerTranzId;
        _powerTranzPassword = powerTranzPassword;
        _baseUrl = baseurl;
        _httpClient = new HttpClient();
    }

    public async Task<HttpResponseMessage> Auth(AuthRequest model)
    {
        var jsonContent = JsonSerializer.Serialize(requestModel);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Add("PowerTranz-PowerTranzId", _powerTranzId);
        _httpClient.DefaultRequestHeaders.Add("PowerTranz-PowerTranzPassword", _powerTranzPassword);

        // Hacer la solicitud POST
        var response = await _httpClient.PostAsync(_baseUrl+"auth", content);
        return response;
    }
}