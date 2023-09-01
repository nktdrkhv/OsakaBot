using System.ComponentModel.DataAnnotations.Schema;
using Osaka.Bot.UserSpecific;

namespace Osaka.Bot.Content;

public class Post
{
    public int PostId { get; set; }
    public string PostLabel { get; set; } = null!;
    public InnerMessage PostContent { get; set; } = null!;
    public ICollection<RegularUserRole> Visibility { get; set; } = null!;
    public KeyboardBase? Keyboard { get; set; }
    public UserInput? UserInput { get; set; }
    public Trigger? OnUserScopeClear { get; set; }
}