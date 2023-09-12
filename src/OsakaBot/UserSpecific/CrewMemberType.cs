namespace Osaka.Bot.UserSpecific;

[Flags]
public enum CrewMemberType
{
    None = 0,
    Support = 1,
    Admin = 2,
    SupporAdmin = Support | Admin
}