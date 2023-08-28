namespace Osaka.Bot.UserSpecific;

public class InnerUserState
{
    public InnerUserType CurrentType { get; set; }
    public ChatFlowType ChatFlowType { get; set; }
    public SpecialFlowType? SpecialFlowType { get; set; }
}