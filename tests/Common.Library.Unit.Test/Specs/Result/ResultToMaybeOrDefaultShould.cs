namespace Common.Library.Core.Unit.Test.Specs.Result;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Result.ToMaybeOrDefault")]
public class ResultToMaybeOrDefaultShould
{
	[Fact(DisplayName = "ToMaybeOrDefault with value return expected value")]
	public void ToMaybeOrDefault_WithValue_ReturnExpectedValue()
	{
		const string expected = "test";

		static Result<string> act() => expected;

		var maybe = act().ToMaybeOrDefault("default");

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybeOrDefault with null return default value")]
	public void ToMaybeOrDefault_WithNull_ReturnDefaultValue()
	{
		const string expected = "default";

		static Result<string> act() => null;

		var maybe = act().ToMaybeOrDefault(expected);

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybeOrDefault with ValueTask return expected value")]
	public async Task ToMaybeOrDefault_WithValueTask_ReturnExpectedValue()
	{
		const string expected = "test";

		static async ValueTask<Result<string>> act() => await ValueTask.FromResult<Result<string>>(expected);

		var maybe = await act()
			.ToMaybeOrDefault("default");

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybeOrDefault with null return default value")]
	public async Task ToMaybeOrDefault_WithNullValueTask_ReturnDefaultValue()
	{
		const string expected = "default";

		static async ValueTask<Result<string>> act() => await ValueTask.FromResult<Result<string>>(null);

		var maybe = await act()
			.ToMaybeOrDefault(expected);

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybeOrDefault with Task return expected value")]
	public async Task ToMaybeOrDefault_WithTask_ReturnExpectedValue()
	{
		const string expected = "test";

		static async Task<Result<string>> act() => await Task.FromResult<Result<string>>(expected);

		var maybe = await act()
			.ToMaybeOrDefault("default");

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToMaybeOrDefault with null return default value")]
	public async Task ToMaybeOrDefault_WithNullTask_ReturnDefaultValue()
	{
		const string expected = "default";

		static async Task<Result<string>> act() => await Task.FromResult<Result<string>>(null);

		var maybe = await act()
			.ToMaybeOrDefault(expected);

		maybe.Should().BeOfType<Maybe<string>>();
		maybe.Value.Should().Be(expected);
	}
}