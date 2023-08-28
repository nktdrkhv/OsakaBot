using System.Net.Http.Json;

namespace Osaka.Bot.Services;

public class WeatherService : BackgroundService
{
    private readonly IHttpClientFactory _factory;
    private readonly string _apiToken;

    public WeatherService(IHttpClientFactory factory) // 
    {
        _factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                await Task.Delay(TimeSpan.FromMinutes(20));
            }
        }
        catch { }
    }

    public async Task<string> GetInstantWeatherAsync(double latitude, double longitude, string? apiToken = null)
    {
        // using var httpClient = _factory.CreateClient();
        // var request = new HttpRequestMessage()
        // {
        //     Method = HttpMethod.Get,
        //     RequestUri = new Uri("https://api.openweathermap.org/data/2.5/"),
        // };
        // request.Options.Set(new("lat"), latitude);
        // request.Options.Set(new("lon"), longitude);
        // request.Options.Set(new("units"), "metric");
        // request.Options.Set(new("lang"), "ru");
        // request.Options.Set(new("appid"), string.IsNullOrWhiteSpace(apiToken) ? _apiToken : apiToken);
        // var response = await httpClient.SendAsync(request);
        // if (!response.IsSuccessStatusCode)
        //     throw new Exception("Error status code while requesting weather");
        // var json = await response.Content.ReadFromJsonAsync<dynamic>() ?? throw new Exception("Json reading problem");
        // return $"{json!.main.temp}, {json!.weather.description}";
        throw new NotImplementedException();
    }
}