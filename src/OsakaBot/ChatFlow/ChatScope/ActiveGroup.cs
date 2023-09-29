using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Osaka.Bot.ChatFlow.ChatScope;

[Table("ActiveGroup")]
public class ActiveGroup
{
    public int ActiveGroupId { get; private set; }
    public string Text { get; private set; } = null!;

    private int _currentPosition;
    public int CurrentPosition
    {
        get => _currentPosition;
        set => _currentPosition = value < 0
            ? throw new ArgumentException("Position should be over zero", nameof(CurrentPosition))
            : value;
    }

    public int ChatScopeId { get; private set; }
    public ChatScope ChatScope { get; private set; } = null!;

    public int GroupId { get; private set; }
    public Group Group { get; private set; } = null!;

    public ActiveGroup(string text, Group group) => (Text, Group) = (text, group);
    protected ActiveGroup() { }


    public override bool Equals(object? obj) => obj is ActiveGroup ag && ActiveGroupId == ag.ActiveGroupId;

    public override int GetHashCode() => ActiveGroupId.GetHashCode();
}