using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramUpdater.Helpers;

namespace Osaka.Bot.Content.Markup.Keyboards;

[Table("Keyboard")]
public abstract class KeyboardBase : ITitled, IMarkupBuilder<KeyboardMarkup>
{
    [Key] public int KeyboardId { get; private set; }
    public KeyboardType Type { get; protected set; } = KeyboardType.None;
    public string? Title { get; protected set; }
    public ICollection<ButtonBase>? Buttons { get; protected set; }

    public abstract ValueTask<KeyboardMarkup> BuildMarkupAsync(CompositeArgument args);

    public async ValueTask FillAsync<TButton>(CompositeArgument arg, GridCollection<TButton> grid, ICollection<ActiveKeyboardTrigger> akts)
    {
        var buttons = Buttons!.OrderBy(b => b.RowPriority).GroupBy(b => b.ColumnPriority);
        foreach (var button in buttons.First())
        {
            var buttonMarkup = await button.BuildMarkupAsync(arg);
            grid.Add((TButton)buttonMarkup!.Button);
            if (buttonMarkup.Trigger != null)
                akts.Add(buttonMarkup.Trigger);
        }
        foreach (var row in buttons.Skip(1))
        {
            grid.AddRow();
            foreach (var button in row)
            {
                var buttonMarkup = await button.BuildMarkupAsync(arg);
                grid.Add((TButton)buttonMarkup!.Button);
                if (buttonMarkup.Trigger != null)
                    akts.Add(buttonMarkup.Trigger);
            }
        }
    }
}
