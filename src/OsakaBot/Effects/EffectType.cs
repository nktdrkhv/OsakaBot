namespace Osaka.Bot.Effects;

public enum EffectType
{
    None,
    SendPost,
    CarouselSpin,
    EditShowedMessage,
    RemoveShowedMessage,
    RemoveInlineKeyboard,
    RemoveUserInput,
    StartDialogue,
    FinishDialogue,
    SendReport,
    CleanScope,
    MakeInnerContact,
    SetPhrase,
    SendMedia,
    SendReportAssistantsContacts
}