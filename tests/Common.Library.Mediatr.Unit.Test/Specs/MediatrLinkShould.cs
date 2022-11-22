namespace Common.Library.Mediatr.Unit.Test.Specs;

using Common.Library.Core;
using Common.Library.Mediatr;
using Common.Library.Mediatr.Unit.Test.Dummies;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

[Trait("Unit", "Mediatr.Link")]
public class MediatrLinkShould
{
	[Fact(DisplayName = "Link with value return value")]
	public async Task Link_WithValue_ReturnValue()
	{
		var requestId = Guid.NewGuid();
		var responseId = Guid.NewGuid();

		var mock = new Mock<IMediator>();

		mock.Setup(m => m.Send(It.IsAny<DummyCommand>(), default))
			.ReturnsAsync(new DummyCommandResponse(responseId));

		var result = await mock.Object.Send(new DummyCommand(requestId))
			.Link(v => new DummyCommandResponse(responseId));

		result.Value.Id.Should().Be(responseId);
	}

	[Fact(DisplayName = "Link without value return Maybe.None")]
	public async Task Link_WithoutValue_ReturnMaybeNone()
	{
		var requestId = Guid.NewGuid();
		var responseId = Guid.NewGuid();

		var mock = new Mock<IMediator>();

		mock.Setup(m => m.Send(It.IsAny<DummyCommand>(), default))
			.ReturnsAsync(Maybe<DummyCommandResponse>.None);

		var result = await mock.Object.Send(new DummyCommand(requestId))
			.Link(v => new DummyCommandResponse(responseId));

		result.HasValue.Should().BeFalse();
		result.Value.Should().BeNull();
	}

	[Fact(DisplayName = "Link with value return other value")]
	public async Task Link_WithValue_ReturnOtherValue()
	{
		var requestId = Guid.NewGuid();
		var responseId = Guid.NewGuid();
		var expected = "test";

		var mock = new Mock<IMediator>();

		mock.Setup(m => m.Send(It.IsAny<DummyCommand>(), default))
			.ReturnsAsync(new DummyCommandResponse(responseId));

		var result = await mock.Object.Send(new DummyCommand(requestId))
			.Link<DummyCommandResponse, string>(v => expected);

		result.Value.Should().Be(expected);
	}

	[Fact(DisplayName = "Link with value return other Maybe.None")]
	public async Task Link_WithValue_ReturnOtherMaybeNone()
	{
		var requestId = Guid.NewGuid();
		var expected = "test";

		var mock = new Mock<IMediator>();

		mock.Setup(m => m.Send(It.IsAny<DummyCommand>(), default))
			.ReturnsAsync(Maybe<DummyCommandResponse>.None);

		var result = await mock.Object.Send(new DummyCommand(requestId))
			.Link<DummyCommandResponse, string>(v => expected);

		result.HasValue.Should().BeFalse();
		result.Value.Should().BeNull();
	}
}