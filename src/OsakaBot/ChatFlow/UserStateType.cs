namespace Osaka.Bot.ChatFlow;

public enum UserStateType
{
    None = 0,
    Regular = 1,
    Support = 2,
    Admin = 4,
    SuperSupport = Regular | Support,
    SuperAdmin = Regular | Support | Admin
}