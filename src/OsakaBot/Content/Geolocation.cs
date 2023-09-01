namespace Osaka.Bot.Content;

public class Geolocation
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string? Title { get; set; }
    public string? Address { get; set; }

    public Geolocation(double longitude, double latitude) => (Longitude, Latitude) = (longitude, latitude);
    public Geolocation(double longitude, double latitude, string title, string address)
    {
        Longitude = longitude;
        Latitude = latitude;
        Title = title;
        Address = address;
    }
}