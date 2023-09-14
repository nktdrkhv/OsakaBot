namespace Osaka.Bot.InputSystem;

public class InputService : IInputService
{
    private readonly IDialogueService _dialogeService;
    private readonly IAutoInputService _autoInput;
    private readonly IRepository _repository;

    public InputService(IDialogueService dialogeService, IAutoInputService autoInput, IRepository repository)
    {
        _dialogeService = dialogeService;
        _autoInput = autoInput;
        _repository = repository;
    }


    public ValueTask FromButtonTriggerAsync(InnerUser user, Trigger trigger) => ProcessInput(user, trigger);

    public ValueTask FromButtonTriggerAsync(InnerUser user, Trigger trigger, string text) => ProcessInput(user, trigger, text: text);

    public ValueTask FromMessageTriggerAsync(InnerUser user, Trigger trigger, InnerMessage message) => ProcessInput(user, trigger, message: message);

    private async ValueTask ProcessInput(InnerUser user, Trigger trigger, InnerMessage? message = null, string? text = null)
    {
        if (!await _dialogeService.IsThereAnyActiveDialogueAsync(user)) return;

        var activeIncludedPost = await _dialogeService.RetrieveActiveIncludedPost(user, trigger);
        if (activeIncludedPost == null) return;

        ICollection<AutoInputPair> autoInputed = activeIncludedPost.IncludedPost.AutoInputType switch
        {
            AutoInputType.Contact => message?.Contact != null ? await _autoInput.DecomposeAsync(message, activeIncludedPost.IncludedPost.AutoInputType.Value) : Array.Empty<AutoInputPair>(),
            AutoInputType.Date => text != null ? await _autoInput.DecomposeAsync(text, activeIncludedPost.IncludedPost.AutoInputType.Value) : Array.Empty<AutoInputPair>(),
            _ => Array.Empty<AutoInputPair>(),
        };

        switch (activeIncludedPost.IncludedPost.IncludingType)
        {
            case PostIncludingType.UserInput:
                if (autoInputed != null && autoInputed.Count > 0 && autoInputed.First().Text is string firstText)
                {
                    await _dialogeService.EnterDataAsync(user, activeIncludedPost, textData: firstText);
                    foreach (var inputed in autoInputed.Skip(1))
                        if (inputed.Variable != null && inputed.Text != null)
                            await _dialogeService.EnterDataAsync(user, activeIncludedPost.ActualDialogue, inputed.Variable, textData: inputed.Text);
                }
                else if (message != null)
                    await _dialogeService.EnterDataAsync(user, activeIncludedPost, messageData: message);
                else if (text != null)
                    await _dialogeService.EnterDataAsync(user, activeIncludedPost, textData: text);
                else
                {
                    var buttonText = await _repository.GetButtonText(trigger.TriggerId);
                    if (buttonText.Surrogates != null)
                        await _dialogeService.EnterDataAsync(user, activeIncludedPost, textData: "неподдерживается");
                    else
                        await _dialogeService.EnterDataAsync(user, activeIncludedPost, textData: buttonText.OriginalText);
                }
                break;
            case PostIncludingType.PostMeta:
                var postMeta = await _repository.GetPostMeta(activeIncludedPost.IncludedPost.PostId);
                await _dialogeService.EnterDataAsync(user, activeIncludedPost, textData: postMeta);
                break;
            case PostIncludingType.ContentMeta:
                var contentMeta = await _repository.GetContentMeta(user.InnerUserId, trigger.TriggerId);
                await _dialogeService.EnterDataAsync(user, activeIncludedPost, textData: contentMeta);
                break;
            case PostIncludingType.ButtonMeta:
                var buttonMeta = await _repository.GetButtonMeta(trigger.TriggerId);
                await _dialogeService.EnterDataAsync(user, activeIncludedPost, textData: buttonMeta);
                break;
        }
        await _repository.SaveChangesAsync();
    }
}