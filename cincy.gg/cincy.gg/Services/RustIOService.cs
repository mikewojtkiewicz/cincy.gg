using cincy.gg.Configuration;
using cincy.gg.domain.RustIOEntities;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace cincy.gg.Services;

public class RustIOService : IRustIOService
{
    private HttpClient _httpClient;
    private string _token = string.Empty;
    public RustIOService(IOptions<RustIO> rustIOOptions)
    {
        var rustIO = rustIOOptions.Value;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri($"{rustIO.BaseAddress}:{rustIO.Port}"),
        };

        _token = rustIO.Token;
    }

    public async Task<string> GetPlayerData()
    {
        var data = await _httpClient.GetAsync($"players.json?apiKey={_token}");
        var returnData = await data.Content.ReadAsStringAsync();
        return returnData;
    }

    public async Task<Status?> GetServiceStatus()
    {
        return await _httpClient.GetFromJsonAsync<Status>($"status.json");
    }

    public async Task<bool> CanConnectToServer()
    {
        try
        {
            var response = await _httpClient.GetAsync("status.json");

            // Return true if the response is successful
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            // Handle any exceptions that occur during the request
            return false;
        }
    }
}
