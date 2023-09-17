using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Osaka.Bot.Extensions;

public static class TelegramBotClientExtensions
{
    public static async ValueTask<Message> SendPreparedMessageAsync(this ITelegramBotClient client, PreparedMessage preparedMessage, CancellationToken ct = default)
    {
        switch (preparedMessage.Type)
        {
            case InnerMessageType.Text:
                return await client.SendTextMessageAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    text: preparedMessage.Text!,
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct);
            case InnerMessageType.Photo:
                var photo = preparedMessage.InputFile;
                return await client.SendPhotoAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    photo: photo!,
                    caption: preparedMessage.Text,
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.Video:
                var video = preparedMessage.InputFile;
                return await client.SendVideoAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    video: video!,
                    caption: preparedMessage.Text,
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.VideoNote:
                var videoNote = preparedMessage.InputFile;
                return await client.SendVideoNoteAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    videoNote: videoNote!,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.Voice:
                var voice = preparedMessage.InputFile;
                return await client.SendVoiceAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    voice: voice!,
                    caption: preparedMessage.Text,
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.Audio:
                var audio = preparedMessage.InputFile;
                return await client.SendAudioAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    audio: audio!,
                    caption: preparedMessage.Text,
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.Animation:
                var animation = preparedMessage.InputFile;
                return await client.SendAnimationAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    animation: animation!,
                    caption: preparedMessage.Text,
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.Sticker:
                var sticker = preparedMessage.InputFile;
                return await client.SendStickerAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    sticker: sticker!,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.Document:
                var document = preparedMessage.InputFile;
                return await client.SendDocumentAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    document: document!,
                    caption: preparedMessage.Text,
                    parseMode: ParseMode.MarkdownV2,
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            case InnerMessageType.Geolocation:
                if (preparedMessage.Geolocation!.Address is string address &&
                    preparedMessage.Geolocation!.Title is string title)
                    return await client.SendVenueAsync(
                        chatId: preparedMessage.User.TelegramUserId,
                        latitude: preparedMessage.Geolocation!.Latitude,
                        longitude: preparedMessage.Geolocation!.Longitude,
                        title: title,
                        address: address,
                        replyMarkup: preparedMessage.Markup,
                        cancellationToken: ct
                    );
                else
                    return await client.SendLocationAsync(
                        chatId: preparedMessage.User.TelegramUserId,
                        latitude: preparedMessage.Geolocation!.Latitude,
                        longitude: preparedMessage.Geolocation!.Longitude,
                        replyMarkup: preparedMessage.Markup,
                        cancellationToken: ct
                    );
            case InnerMessageType.Contact:
                return await client.SendContactAsync(
                    chatId: preparedMessage.User.TelegramUserId,
                    phoneNumber: preparedMessage.Contact!.PhoneNumber,
                    firstName: preparedMessage.Contact.FullName,
                    vCard: preparedMessage.Contact.ConvertToVcard(),
                    replyMarkup: preparedMessage.Markup,
                    cancellationToken: ct
                );
            default:
                throw new ArgumentException("InnerMessageType is unsupported");
        }
    }

    public static ValueTask<Message[]> SendPreparedAlbumAsync(this ITelegramBotClient client, PreparedAlbum preparedAlbum)
    {
        throw new NotImplementedException();
    }
}