namespace Osaka.Bot.Content.Textable;

public class WeatherTextSetter : TextSetterBase
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public WeatherTextSetter() => Type = TextSetterType.Weather;
}

public class WeatherTextSetterApplier : ITextSetterApplier<WeatherTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase effect)
    {
        throw new NotImplementedException();
    }
}