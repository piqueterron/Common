namespace Common.Library.Mediatr.Unit.Test.Dummies;

using MediatR;
using System.Threading;
using Common.Library.Core;

public sealed class DummyCommandHandler : IRequestHandler<DummyCommand, Maybe<DummyCommandResponse>>
{
	public async Task<Maybe<DummyCommandResponse>> Handle(DummyCommand request, CancellationToken cancellationToken) =>
		new DummyCommandResponse(request.Id);
}