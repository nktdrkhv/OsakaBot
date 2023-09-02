using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Osaka.Bot.Effects;

namespace Osaka.Bot.Tests;

public class TestEffect : EffectBase
{
    public int Foo { get; set; }
}

public class TestEffectApplier : IEffectApplier<TestEffect>
{
    public Task Apply(TestEffect effect)
    {
        Console.WriteLine("Foo is {0}", effect.Foo);
        return Task.CompletedTask;
    }

    public Task Apply(EffectBase effect)
    {
        var effect1 = (TestEffect)effect;
        Console.WriteLine("Foo is {0}", effect1.Foo);
        return Task.CompletedTask;
    }
}

public class EffectDispatcherTests
{

    [Fact]
    public async void ResolveAsync1()
    {
        var sc = new ServiceCollection();
        sc.AddScoped<IEffectApplier<TestEffect>, TestEffectApplier>();
        var sp = sc.BuildServiceProvider();

        EffectBase effect = new TestEffect { Foo = 1 };
        //var effect = new TestEffect { Foo = 1 };
        var effectDispatcher = new EffectDispatcher(sp);
        await effectDispatcher.ResolveAsync(effect);
    }
}