using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Osaka.Bot.InputSystem;

public class DialogueService : IDialogueService
{
    private readonly IRepository _repository;

    public DialogueService(IRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<bool> IsThereAnyActiveDialogueAsync(InnerUser user) => await _repository.ExistsAsync<ActualDialogue>(ad => ad.Finished == null && ad.UserId == user.InnerUserId);

    public ValueTask EnterDataAsync(InnerUser user, ActiveIncludedPost reason, string? textData = null, InnerMessage? messageData = null, bool rewrite = true) =>
        EnterDataAsync(user, reason.ActualDialogue, reason.Variable, textData, messageData, rewrite);

    public async ValueTask EnterDataAsync(InnerUser user, ActualDialogue actualDialogue, Variable variable, string? textData = null, InnerMessage? messageData = null, bool rewrite = false)
    {
        var existed = await _repository.GetAsync<EnteredData>(ed =>
            ed.AuthorId == user.InnerUserId
            && ed.VariableId == variable.Name
            && ed.AttachedToId == actualDialogue.ActualDialogueId,
            ed => ed.Include(ed => ed.InnerMessage),
            asNoTracking: false);
        if (existed != null && rewrite)
        {
            existed.InnerMessage = messageData;
            existed.Text = textData;
            existed.DateTime = DateTime.UtcNow;
        }
        else if (existed == null)
        {
            var enteredData = new EnteredData()
            {
                Variable = variable,
                Author = user,
                AttachedTo = actualDialogue,
                InnerMessage = messageData,
                Text = textData
            };
            await _repository.AddAsync(enteredData);
        }
    }

    public async ValueTask<ActiveIncludedPost?> RetrieveActiveIncludedPost(InnerUser user, Trigger trigger)
    {
        var postId = await _repository.GetQueryable<ActiveKeyboardTrigger>().Include(akt => akt.ChatScope).Include(akt => akt.ShowedMessage)
            .Where(akt => akt.TriggerId == trigger.TriggerId && akt.ChatScope.InnerUserId == user.InnerUserId)
            .Select((akt, _) => akt.ShowedMessage.PostId)
            .LastAsync();
        if (postId == null)
            return null;
        var activeDialogues = _repository.GetQueryable<ActualDialogue>()
            .Where(ad => ad.UserId == user.InnerUserId && ad.Finished == null);
        var activeIncludedPost = from ip in _repository.GetQueryable<IncludedPost>().Include(ip => ip.DialogueField)
                                 join ad in activeDialogues on ip.DialogueField.AttachedToId equals ad.SourceId
                                 where ip.PostId == postId
                                 select new ActiveIncludedPost()
                                 {
                                     IncludedPost = ip,
                                     Variable = ip.DialogueField.AssignTo,
                                     ActualDialogue = ad,
                                 };
        return await activeIncludedPost.LastOrDefaultAsync();
    }
}