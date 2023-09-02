using System;
using System.Diagnostics;
using Sqids;
using Xunit;

namespace Osaka.Bot.Tests;

public class SqidsTests
{
    [Fact]
    public void EncodeTest()
    {
        var sqids = new SqidsEncoder();
        var a = sqids.Encode(0);
        var b = sqids.Encode(1);
        var c = sqids.Encode(2);
        var d = sqids.Encode(1000);
        var a1 = sqids.Decode(a);
        var b1 = sqids.Decode(b);
        var c1 = sqids.Decode(c);
        var d1 = sqids.Decode(d);
    }
}