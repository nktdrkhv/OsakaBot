using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Osaka.Bot.Validation;

public abstract class PhoneValidator : RegexValidatorBase
{
    [NotMapped]
    private static readonly Regex PhoneRegex = new(@"/^((8|\+374|\+994|\+995|\+375|\+7|\+380|\+38|\+996|\+998|\+993)[\- ]?)?\(?\d{3,5}\)?[\- ]?\d{1}[\- ]?\d{1}[\- ]?\d{1}[\- ]?\d{1}[\- ]?\d{1}(([\- ]?\d{1})?[\- ]?\d{1})?$/");

    public override bool Validate(InnerMessage message)
    {
        if (message.Text?.OriginalText is string text)
        {
            var pText = string.Concat(text.Split('@', ',', '.', ';', '\'', ' ', '(', ')', '-'));
            if (PhoneRegex.IsMatch(pText))
            {
                if (DoFormatting)
                    message.Text.OriginalText = pText;
                return true;
            }
        }
        return false;
    }
}