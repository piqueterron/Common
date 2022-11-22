namespace Common.Library.Core.Unit.Test.Specs.Result;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Result.ToMaybe")]
public class ResultToMaybeShould
{
	[Fact(DisplayName = "ToMaybe with value return expected value")]
	public void ToMaybe_WithValue_ReturnExpectedValue()
	{
		const string expected = "test";

		static Result<string> act() => expected;

		var maybe = act()
			.ToMaybe();

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybe with null return Maybe.None")]
	public void ToMaybe_WithNull_ReturnMaybeNone()
	{
		var expected = Maybe<string>.None;

		static Result<string> act() => null;

		var maybe = act()
			.ToMaybe();

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybe with ValueTask return expected value")]
	public async Task ToMaybe_WithValueTask_ReturnExpectedValue()
	{
		const string expected = "test";

		static async ValueTask<Result<string>> act() => await ValueTask.FromResult<Result<string>>(expected);

		var maybe = await act()
			.ToMaybe();

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybe with null ValueTask return Maybe.None")]
	public async Task ToMaybe_WithNullValueTask_ReturnMaybeNone()
	{
		var expected = Maybe<string>.None;

		static async ValueTask<Result<string>> act() => await ValueTask.FromResult<Result<string>>(null);

		var maybe = await act()
			.ToMaybe();

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybe with Task return expected value")]
	public async Task ToMaybe_WithTask_ReturnExpectedValue()
	{
		const string expected = "test";

		static async Task<Result<string>> act() => await Task.FromResult<Result<string>>(expected);

		var maybe = await act()
			.ToMaybe();

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybe with null Task return Maybe.None")]
	public async Task ToMaybe_WithNullTask_ReturnMaybeNone()
	{
		var expected = Maybe<string>.None;

		static async Task<Result<string>> act() => await Task.FromResult<Result<string>>(null);

		var maybe = await act()
			.ToMaybe();

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Should().Be(expected);
	}
}