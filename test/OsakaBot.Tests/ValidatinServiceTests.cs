using System.Linq;
using Xunit;

namespace Osaka.Bot.Tests;

public class ValidationServiceTests
{
    [Fact]
    public void SimpleValidateTest()
    {
        var scope = new (int group, bool val)[] { (3, true), (3, true), (5, false) };
        var res = scope.GroupBy(v => v.group).Select(group =>
        {
            var result = true;
            foreach (var elem in group)
                result &= elem.val;
            return result;
        }).Any(conjunction => conjunction);
        Assert.True(res);
    }
}