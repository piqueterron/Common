namespace Common.Library.Mediatr.Unit.Test.Dummies;

using MediatR;
using Common.Library.Core;

public record DummyCommand(Guid Id) : IRequest<Maybe<DummyCommandResponse>>;
