using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content;

public record PreparedMessage() : IDisposable
{
    public InnerUser User { get; set; } = null!;
    public InnerMessageType Type { get; set; }
    public string? Text { get; set; }
    public Media? Media { get; set; }
    public InnerContact? Contact { get; set; }
    public Geolocation? Geolocation { get; set; }
    public IReplyMarkup? Markup { get; set; }

    // todo: dispose pattern
    // private bool _disposed;

    private Stream? _newFile;
    private InputFile? _inputFile;

    public InputFile? InputFile
    {
        get
        {
            if (_inputFile != null)
                return _inputFile;
            else if (Media?.FileId is string fileId)
            {
                _inputFile = InputFile.FromFileId(fileId);
                return _inputFile;
            }
            else if (Media?.Path is string path)
            {
                _newFile = System.IO.File.OpenRead(path);
                _inputFile = InputFile.FromStream(_newFile);
                return _inputFile;
            }
            else
                return null;
        }
    }

    public virtual void Dispose() => _newFile?.Dispose();
}

public record PreparedAlbum : PreparedMessage, IDisposable
{
    public ICollection<Media> MediaAlbum { get; set; } = null!;
    private readonly bool _isOnlyUploaded = false;

    public PreparedAlbum(bool doNotUpload) => _isOnlyUploaded = doNotUpload;

    public override void Dispose() { }
}