using Xunit;
using System.Text.RegularExpressions;
using Osaka.Bot.Content.Textable;

namespace Osaka.Bot.Tests;

public class RegexTests
{
    [Fact]
    public void PhoneRegexTest()
    {
        Regex PhoneRegex = new(@"/^((8|\+374|\+994|\+995|\+375|\+7|\+380|\+38|\+996|\+998|\+993)[\- ]?)?\(?\d{3,5}\)?[\- ]?\d{1}[\- ]?\d{1}[\- ]?\d{1}[\- ]?\d{1}[\- ]?\d{1}(([\- ]?\d{1})?[\- ]?\d{1})?$/");

        var text = "   +7 342 565-33-23";
        var pText = string.Concat(text.Split('@', ',', '.', ';', '\'', ' ', '(', ')', '-'));
        var res = PhoneRegex.IsMatch(pText);

        Assert.True(res);
    }
}