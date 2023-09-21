namespace Osaka.Bot.Content.Textable;

public class WeatherTextSetter : TextSetterBase
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    protected WeatherTextSetter() => Type = TextSetterType.Weather;
    public WeatherTextSetter(double latitude, double longitude) : this() => (Latitude, Longitude) = (latitude, longitude);
}

public class WeatherTextSetterApplier : ITextSetterApplier<WeatherTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase effect)
    {
        throw new NotImplementedException();
    }
}