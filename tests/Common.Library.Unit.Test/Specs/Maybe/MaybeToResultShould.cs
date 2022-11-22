namespace Common.Library.Core.Unit.Test.Specs.Maybe;

using Common.Library.Core;
using FluentAssertions;
using Xunit;

[Trait("Unit", "Maybe.ToResult")]
public class MaybeToResultShould
{
	[Fact(DisplayName = "ToResult with object return expected result")]
	public void ToResult_WithObject_ReturnResultObject()
	{
		const string expected = "orValue";

		static Maybe<string> act() => expected;

		var result = act()
			.ToResult();

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with error return expected error")]
	public void ToResult_WithError_ReturnExpectedError()
	{
		const string expected = "Maybe has not value to convert.";

		static Maybe<string> act() => null;

		var result = act()
			.ToResult();

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with custome error return expected custome error")]
	public void ToResult_WithCustomeError_ReturnExpectedCustomeError()
	{
		const string expected = nameof(Exception);

		static Maybe<string> act() => null;

		var result = act()
			.ToResult(Error.Create(nameof(Exception), new Exception()));

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with custome error return expected result")]
	public void ToResult_WithCustomeError_ReturnExpectedResult()
	{
		const string expected = "orValue";

		static Maybe<string> act() => expected;

		var result = act()
			.ToResult(Error.Create(nameof(Exception), new Exception()));

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with ValueTask return expected result")]
	public async Task ToResult_WithValueTask_ReturnExpectedResult()
	{
		const string expected = "orValue";

		static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(expected);

		var result = await act()
			.ToResult();

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with ValueTask error return error")]
	public async Task ToResult_WithValueTaskError_ReturnError()
	{
		const string expected = "Maybe has not value to convert.";

		static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(null);

		var result = await act()
			.ToResult();

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with ValueTask custome error return error")]
	public async Task ToResult_WithValueTaskCustomeError_ReturnError()
	{
		const string expected = nameof(Exception);

		static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(null);

		var result = await act().ToResult(Error.Create(nameof(Exception), new Exception()));

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with ValueTask custome error return expected result")]
	public async Task ToResult_WithValueTaskCustomeError_ReturnExpectedResult()
	{
		const string expected = "orValue";

		static async ValueTask<Maybe<string>> act() => await ValueTask.FromResult<Maybe<string>>(expected);

		var result = await act()
			.ToResult(Error.Create(nameof(Exception), new Exception()));

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with Task return expected result")]
	public async Task ToResult_WithTask_ReturnExpectedResult()
	{
		const string expected = "orValue";

		static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(expected);

		var result = await act()
			.ToResult();

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with Task error return error")]
	public async Task ToResult_WithTaskError_ReturnError()
	{
		const string expected = "Maybe has not value to convert.";

		static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(null);

		var result = await act()
			.ToResult();

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with Task custome error return error")]
	public async Task ToResult_WithTaskCustomeError_ReturnError()
	{
		const string expected = nameof(Exception);

		static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(null);

		var result = await act()
			.ToResult(Error.Create(nameof(Exception), new Exception()));

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}

	[Fact(DisplayName = "ToResult with Task custome error return expected result")]
	public async Task ToResult_WithTaskCustomeError_ReturnExpectedResult()
	{
		const string expected = "orValue";

		static async Task<Maybe<string>> act() => await Task.FromResult<Maybe<string>>(expected);

		var result = await act()
			.ToResult(Error.Create(nameof(Exception), new Exception()));

		result.Should().BeOfType<Result<string>>();

		var value = result.Match(ok => ok, ko => ko.Value.Description);

		value.Should().Be(expected);
	}
}