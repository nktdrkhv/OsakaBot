namespace Osaka.Bot.Content.Textable;

public class UserRoleTextSetter : TextSetterBase
{
    public UserRoleTextSetter() => Type = TextSetterType.UserRole;
}

public class UserRoleTextSetterApplier : ITextSetterApplier<UserRoleTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase setter)
    {
        var concrete = (UserRoleTextSetter)setter;
        throw new NotImplementedException();
    }
}