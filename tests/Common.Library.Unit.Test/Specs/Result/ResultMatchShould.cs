namespace Common.Library.Core.Unit.Test.Specs.Result;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Result.Match")]
public class ResultMatchShould
{
    [Fact(DisplayName = "Match with null act throw NullReferenceException")]
    public void Match_WithNullact_ThrowNullReferenceException()
    {
        static Result<string> act() => "test";
        FluentActions.Invoking(() => act().Match(null)).Should().Throw<NullReferenceException>();
    }

    [Fact(DisplayName = "Match with null action throw NullReferenceException")]
    public void Match_WithNullAction_ThrowNullReferenceException()
    {
        static Result<string> act() => "test";
        FluentActions.Invoking(() => act().Match(null)).Should().Throw<NullReferenceException>();
    }

    [Fact(DisplayName = "Match with error action no throw NullReferenceException")]
    public void Match_WithErrorAction_NoThrowNullReferenceException()
    {
        static Result<string> act() => Error.Create("error");
        FluentActions.Invoking(() => act().Match(null, null)).Should().NotThrow<NullReferenceException>();
    }
}