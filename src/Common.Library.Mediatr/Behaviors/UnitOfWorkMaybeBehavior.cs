namespace Common.Library.Mediatr;

using Common.Library.Core;
using MediatR;
using System.Threading.Tasks;

public sealed class UnitOfWorkMaybeBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Maybe<TResponse>>
    where TRequest : notnull, IRequest<Maybe<TResponse>>
{
    private readonly IEnumerable<IUnitOfWork> _unitOfWorks;

    public UnitOfWorkMaybeBehavior(IEnumerable<IUnitOfWork> unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<Maybe<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Maybe<TResponse>> next, CancellationToken cancellationToken)
    {
        var result = await next();

        foreach (var unitOfWork in _unitOfWorks)
        {
            await unitOfWork.CommitAsync(cancellationToken);
        }

        return result;
    }
}
