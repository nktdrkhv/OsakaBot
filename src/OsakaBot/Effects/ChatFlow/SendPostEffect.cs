using Microsoft.EntityFrameworkCore;
using Sqids;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Effects.ChatFlow;

public class SendPostEffect : ChatChangingEffectBase
{
    public SendPostEffect() => Type = EffectType.SendPost;
    public SendPostEffect(Post post) : base() => Target = new(post);

    public override void SetArguments(string[] args) { }
}

public class SendPostEffectApplier : IEffectApplier<SendPostEffect>
{
    private readonly ITelegramBotClient _botClient;
    private readonly IRepository _repository;
    private readonly SqidsEncoder _encoder;
    private readonly TextSetterDispatcher _dispatcher;

    public SendPostEffectApplier(ITelegramBotClient botClient, IRepository repository, SqidsEncoder encoder, TextSetterDispatcher dispatcher)
    {
        _botClient = botClient;
        _repository = repository;
        _encoder = encoder;
        _dispatcher = dispatcher;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (SendPostEffect)effect;

        var post = await _repository.GetPost(concrete.Target!.PostId!.Value);
        var scope = await _repository.GetUserScope(concrete.User);

        var preparedMessage = new PreparedMessage()
        {
            User = concrete.User,
            Type = post.Content.Type,
            Media = post.Content.Media?.First(),
            Text = post.Content.Text != null ? await post.Content.Text.ToStringAsync(concrete.User, _dispatcher, false) : null,
            Contact = post.Content.Contact,
            Geolocation = post.Content.Geolocation
        };

        if (post.Keyboard != null)
        {
            var compositeArgument = new CompositeArgument
            {
                Hasher = _encoder,
                TextDispatcher = _dispatcher,
                RoleId = concrete.User.RoleId!.Value,
                UserPhrase = scope.Phrase,
            };

            var concreteKeyboard = await post.Keyboard.BuildMarkupAsync(compositeArgument);
            preparedMessage.Markup = concreteKeyboard.Markup;
        };

        var realMessage = await _botClient.SendPreparedMessageAsync(preparedMessage);

        await _repository.SaveChangesAsync();
    }
}