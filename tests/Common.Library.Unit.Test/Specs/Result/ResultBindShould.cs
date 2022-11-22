namespace Common.Library.Core.Unit.Test.Specs.Result;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Result.Bind")]
public class ResultBindShould
{
    [Fact(DisplayName = "Bind with same type return expected result")]
    public void Bind_WithSameType_ReturnExpectedResult()
    {
        const string expected = "test-x";

        static Result<string> act() => "test";

        var result = act()
            .Bind(s => $"{s}-x");

        result.Should().BeOfType<Result<string>>();
        result.Match(c => c)
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Bind with same type return expected error")]
    public void Bind_WithSameType_ReturnExpectedError()
    {
        const string expected = "error";

        static Result<string> act() => Error.Create("error");

        var result = act()
            .Bind(s => s);

        result.Should().BeOfType<Result<string>>();
        result.Match(c => c, e => e.Value.Description)
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Bind with same type return expected result")]
    public void Bind_WithOtherType_ReturnExpectedResult()
    {
        const string expected = "1";

        static Result<string> act() => expected;

        var result = act()
            .Bind<string, int>(s => int.Parse(s))
            .Bind<int, string>(s => s.ToString());

        result.Should().BeOfType<Result<string>>();
        result.Match(c => c)
            .Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Bind with same type return expected error")]
    public void Bind_WithOtherType_ReturnExpectedError()
    {
        const string expected = "error";

        static Result<string> act() => Error.Create("error");

        var result = act()
            .Bind<string, int>(s => int.Parse(s));

        result.Should().BeOfType<Result<int>>();
        result.Match(c => c.ToString(), e => e.Value.Description)
            .Should()
            .Be(expected);
    }
}