using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;

namespace Osaka.Bot.Services;

public class WeatherService : BackgroundService
{
    private readonly ILogger<WeatherService> _logger;
    private readonly IHttpClientFactory _factory;
    private readonly string _apiToken = null!;
    private readonly bool _doFakes;

    public string CachedWeather { get; private set; } = null!;

    public WeatherService(ILogger<WeatherService> logger, IHttpClientFactory factory, IOptions<BotConfiguration> conf)
    {
        _logger = logger;
        _factory = factory;
        _apiToken = conf.Value.WeatherToken;
        _doFakes = conf.Value.FakeWeather;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                CachedWeather = _doFakes ? "—°" : await GetInstantWeatherAsync(56.478517, 85.047436);
                _logger.LogInformation(message: "Current is {CachedWeather}", CachedWeather ?? "unknown");
                await Task.Delay(TimeSpan.FromMinutes(20), stoppingToken);
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The was en error, during weather updating");
                await Task.Delay(TimeSpan.FromMinutes(1), CancellationToken.None);
            }
        }
    }

    public async Task<string> GetInstantWeatherAsync(double latitude, double longitude, string? apiToken = null)
    {
        using var httpClient = _factory.CreateClient();
        var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?appid={apiToken ?? _apiToken}&lat={latitude}&lon={longitude}&units=metric&lang=ru");
        if (!response.IsSuccessStatusCode)
            return string.Empty;
        var json = await response.Content.ReadFromJsonAsync<Temperatures>() ?? throw new Exception("Json reading problem");
        var temp = (int)Math.Round(json.Main.Temp);
        return $"{temp}°, {json.Weather[0].Description}";
    }

    public class Temperatures
    {
        [JsonPropertyName("weather")] public Weather[] Weather { get; set; } = null!;
        [JsonPropertyName("main")] public Main Main { get; set; } = null!;
    }

    public class Main
    {
        [JsonPropertyName("temp")] public double Temp { get; set; }
        [JsonPropertyName("feels_like")] public double FeelsLike { get; set; }
        [JsonPropertyName("temp_min")] public double TempMin { get; set; }
        [JsonPropertyName("temp_max")] public double TempMax { get; set; }
        [JsonPropertyName("pressure")] public long Pressure { get; set; }
        [JsonPropertyName("humidity")] public long Humidity { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")] public long? Id { get; set; }
        [JsonPropertyName("main")] public string? Main { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("icon")] public string? Icon { get; set; }
    }
}