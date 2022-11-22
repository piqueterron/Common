namespace Common.Library.Mediatr;

using Common.Library.Core;
using MediatR;
using System.Threading.Tasks;

public sealed class UnitOfWorkResultBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse>>
    where TRequest : notnull, IRequest<Result<TResponse>>
{
    private readonly IEnumerable<IUnitOfWork> _unitOfWorks;

    public UnitOfWorkResultBehavior(IEnumerable<IUnitOfWork> unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<Result<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse>> next, CancellationToken cancellationToken)
    {
        var result = await next();

        foreach (var unitOfWork in _unitOfWorks)
        {
            await unitOfWork.CommitAsync(cancellationToken);
        }

        return result;
    }
}
