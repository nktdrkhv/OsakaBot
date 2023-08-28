using Osaka.Bot.UserSpecific;

namespace Osaka.Bot.Content;

public class Post
{
    public int PostId { get; set; }
    public string PostLabel { get; set; } = null!;
    public ICollection<RegularUserRole> Visibility { get; set; } = null!;
    //public Keyboard? Keyboard {get;set;}
    public UserInput? UserInput { get; set; }


    // buttons
    // user input
    // clear scope
}