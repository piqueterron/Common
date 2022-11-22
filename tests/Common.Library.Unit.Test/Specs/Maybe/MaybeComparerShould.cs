namespace Common.Library.Core.Unit.Test.Specs.Maybe;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Maybe.Comparer")]
public class MaybeComparerShould
{
	[Fact(DisplayName = "Maybe operator equality between maybes return equals")]
	public void Maybe_OperatorEqualityBetweenMaybes_ReturnEquals()
	{
		const string expected = "test";

		static Maybe<string> act() => expected;

		var left = act();
		var right = act();

		var result = left == right;

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Maybe operator equality between maybes return no equals")]
	public void Maybe_OperatorEqualityBetweenMaybes_ReturnNoEquals()
	{
		static Maybe<string> actLeft() => "test";
		static Maybe<string> actRight() => "test1";

		var left = actLeft();
		var right = actRight();

		var result = left != right;

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Maybe operator equality with value return equals")]
	public void Maybe_OperatorEqualityWithValue_ReturnEquals()
	{
		const string expected = "test";

		static Maybe<string> act() => expected;

		var left = act();

		var result = left == expected;

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Maybe operator equality with value return no equals")]
	public void Maybe_OperatorEqualityWithValue_ReturnNoEquals()
	{
		const string expected = "test";

		static Maybe<string> act() => expected;

		var left = act();

		var result = left != "test1";

		result.Should().BeTrue();
	}

	[Fact(DisplayName = "Maybe equals null return no equals")]
	public void Maybe_MaybeEqualsNull_ReturnNoEquals()
	{
		const string expected = "test";

		static Maybe<string> act() => expected;

		var left = act();

		var result = left.Equals(null);

		result.Should().BeFalse();
	}

	[Fact(DisplayName = "Maybe equals value return equals")]
	public void Maybe_MaybeEqualsValue_ReturnEquals()
	{
		const string expected = "test";

		static Maybe<string> act() => expected;

		var left = act();

		var result = left.Equals(expected);

		result.Should().BeTrue();
	}
}