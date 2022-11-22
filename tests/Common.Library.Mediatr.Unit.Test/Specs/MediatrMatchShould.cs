namespace Common.Library.Mediatr.Unit.Test.Specs;

using Common.Library.Core;
using Common.Library.Mediatr.Unit.Test.Dummies;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;

[Trait("Unit", "Mediatr.Match")]
public class MediatrMatchShould
{
	[Fact(DisplayName = "Match with value return other value")]
	public async Task Match_WithValue_ReturnOtherValue()
	{
		var requestId = Guid.NewGuid();
		var responseId = Guid.NewGuid();

		var mock = new Mock<IMediator>();

		mock.Setup(m => m.Send(It.IsAny<DummyCommand>(), default))
			.ReturnsAsync(new DummyCommandResponse(responseId));

		var result = await mock.Object.Send(new DummyCommand(requestId))
			.Match(v => v.Id.ToString(), e => Error.Create("error").Description);

		result.Should().Be(responseId.ToString());
	}

	[Fact(DisplayName = "Match with value return other error")]
	public async Task Match_WithValue_ReturnOtherError()
	{
		var requestId = Guid.NewGuid();
		var responseId = Guid.NewGuid();

		var mock = new Mock<IMediator>();

		mock.Setup(m => m.Send(It.IsAny<DummyCommand>(), default))
			.ReturnsAsync(Maybe<DummyCommandResponse>.None);

		var result = await mock.Object.Send(new DummyCommand(requestId))
			.Match(v => v.Id.ToString(), e => Error.Create("error").Description);

		result.Should().Be("error");
	}
}