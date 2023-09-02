using System;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;
using System.Collections.Generic;

namespace Osaka.Bot.Tests;

public class WeatherTests
{
    [Fact]
    public async void ApiCallTest()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://api.openweathermap.org/data/2.5/weather?appid=7085c6e6fbe7ca04bcc6d09f16158d6a&lat=56.484645&lon=84.947649&units=metric&lang=ru");
        if (!response.IsSuccessStatusCode)
            throw new Exception("Error status code while requesting weather");
        var json = await response.Content.ReadFromJsonAsync<dynamic>() ?? throw new Exception("Json reading problem");
        Console.WriteLine($"{json!.main.temp}, {json!.weather.description}");
        Assert.True(true);
    }
}