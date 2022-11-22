namespace Common.Library.Core.Unit.Test.Specs.Maybe;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Maybe.Or")]
public class MaybeOrShould
{
    [Fact(DisplayName = "Or with param null return default value")]
    public void Or_WithParamNull_ReturnDefaultValue()
    {
        var expected = "orValue";

        static Maybe<string> act() => null;

        var maybeOr = act()
            .Or(() => expected);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with param return value")]
    public void Or_WithParam_ReturnValue()
    {
        const string expected = "orValue";

        static Maybe<string> act() => expected;

        var maybeOr = act()
            .Or(() => string.Empty);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with param none return default value")]
    public void Or_WithParamNone_ReturnDefaultValue()
    {
        var expected = "orValue";

        static Maybe<string> act() => Maybe<string>.None;

        var maybeOr = act()
            .Or(expected);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with param empty return value")]
    public void Or_WithParamEmpty_ReturnValue()
    {
        const string expected = "orValue";

        static Maybe<string> act() => expected;

        var maybeOr = act()
            .Or(string.Empty);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with action param return expected value")]
    public async Task Or_WithactParam_ReturnExpectedValue()
    {
        const string expected = "orValue";

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(expected);

        var maybeOr = await act()
            .Or(() => string.Empty);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with action param null return default value")]
    public async Task Or_WithactParamNull_ReturnDefaultValue()
    {
        const string expected = "orValue";

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(null);

        var maybeOr = await act()
            .Or(() => expected);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with value param return expected value")]
    public async Task Or_WithValueParam_ReturnExpectedValue()
    {
        const string expected = "orValue";

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(expected);

        var maybeOr = await act()
            .Or(string.Empty);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with value param null return default value")]
    public async Task Or_WithValueParamNull_ReturnDefaultValue()
    {
        const string expected = "orValue";

        static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(null);

        var maybeOr = await act()
            .Or(expected);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with action param return expected value")]
    public async Task Or_WithActionParam_ReturnExpectedValue()
    {
        const string expected = "orValue";

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(expected);

        var maybeOr = await act()
            .Or(() => string.Empty);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with action param null return default value")]
    public async Task Or_WithActionParamNull_ReturnDefault()
    {
        const string expected = "orValue";

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(null);

        var maybeOr = await act()
            .Or(() => expected);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with implicit param return expected value")]
    public async Task Or_WithImplicitParam_ReturnExpectedValue()
    {
        const string expected = "orValue";

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(expected);

        var maybeOr = await act()
            .Or(string.Empty);

        maybeOr.Value.Should().Be(expected);
    }

    [Fact(DisplayName = "Or with value param null return default value")]
    public async Task Or_WithValueParamNull_ReturnDefault()
    {
        const string expected = "orValue";

        static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(null);

        var maybeOr = await act()
            .Or(expected);

        maybeOr.Value.Should().Be(expected);
    }
}