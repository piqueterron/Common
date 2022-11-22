namespace Common.Library.Core.Unit.Test.Specs.Maybe;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Maybe.Bind")]
public class MaybeBindShould
{
    [Fact(DisplayName = "Bind with same type return new with same type")]
    public void Bind_WithSameType_ReturnNewWithSameType()
    {
        var expected = "otherValue";

        static Maybe<string> act() => "orValue";

        var maybeBind = act()
            .Bind(s => expected);

        maybeBind.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with same type nullable return Maybe.None")]
    public void Bind_WithNullableSameType_ReturnMaybeNone()
    {
        var expected = Maybe<string>.None;

        static Maybe<string> act() => null;

        var maybeBind = act()
            .Bind(s => "otherValue");

        maybeBind.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with other type return new other type")]
    public void Bind_WithOtherType_ReturnNewOtherType()
    {
        var expected = 1;

        static Maybe<string> act() => "1";

        var maybeBind = act()
            .Bind<string, int>(s => int.Parse(s));

        maybeBind.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with nullable other type return Maybe.None other type")]
    public void Bind_WithNullableOtherType_ReturnMaybeNone()
    {
        var expected = Maybe<int>.None;

        static Maybe<string> act() => null;

        var maybeBind = act()
            .Bind<string, int>(s => 0);

        maybeBind.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with ValueTask same type return new same type")]
    public async Task Bind_WithValueTaskSameType_ReturnNewMaybeSameType()
    {
        var expected = "otherValue";

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>("orValue");

        var maybeBind = await act()
            .Bind(s => expected);

        maybeBind.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with ValueTask same type return Maybe.None same type")]
    public async Task Bind_WithValueTaskSameType_ReturnMaybeNone()
    {
        var expected = Maybe<string>.None;

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(null);

        var maybeBind = await act()
            .Bind(s => "otherValue");

        maybeBind.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with ValueTask other type return new other type")]
    public async Task Bind_WithValueTaskOtherType_ReturnNewOtherType()
    {
        var expected = 1;

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>("1");

        var maybeBind = await act()
            .Bind<string, int>(s => int.Parse(s));

        maybeBind.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with ValueTask other type return Maybe.None other type")]
    public async Task Bind_WithValueTaskOtherType_ReturnMaybeNone()
    {
        var expected = Maybe<int>.None;

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(null);

        var maybeBind = await act()
            .Bind<string, int>(s => 0);

        maybeBind.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with Task same type return new same type")]
    public async Task Bind_WithTaskSameType_ReturnNewSameType()
    {
        var expected = "otherValue";

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>("orValue");

        var maybeBind = await act()
            .Bind(s => expected);

        maybeBind.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with Task same type return Maybe.None same type")]
    public async Task Bind_WithTaskSameType_ReturnMaybeNone()
    {
        var expected = Maybe<string>.None;

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(null);

        var maybeBind = await act()
            .Bind(s => "otherValue");

        maybeBind.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with Task other type return new other type")]
    public async Task Bind_WithTaskOtherType_ReturnNewOtherType()
    {
        var expected = 1;

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>("1");

        var maybeBind = await act()
            .Bind<string, int>(s => int.Parse(s));

        maybeBind.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Bind with Task other type return Maybe.None other type")]
    public async Task Bind_WithTaskOtherType_ReturnMaybeNone()
    {
        var expected = Maybe<int>.None;

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(null);

        var maybeBind = await act()
            .Bind<string, int>(s => 0);

        maybeBind.Should().Be(expected);
    }
}