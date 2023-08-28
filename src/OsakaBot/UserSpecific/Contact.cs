namespace Osaka.Bot.UserSpecific;

public class Contact
{
    public int ContactId { get; set; }
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Title { get; set; }
    public string? Organization { get; set; }
}