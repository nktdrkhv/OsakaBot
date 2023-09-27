namespace Osaka.Bot.Content.Textable;

public class WeatherTextSetter : TextSetterBase
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public WeatherTextSetter(double latitude, double longitude)
    {
        Type = TextSetterType.Weather;
        (Latitude, Longitude) = (latitude, longitude);
    }

    protected WeatherTextSetter() { }
}

public class WeatherTextSetterApplier : ITextSetterApplier<WeatherTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase setter)
    {
        var concrete = (WeatherTextSetter)setter;
        throw new NotImplementedException();
    }
}