namespace Common.Library.Mediatr;

using Common.Library.Core;
using MediatR;
using System.Threading.Tasks;

public sealed class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
{
    private readonly IEnumerable<IUnitOfWork> _unitOfWorks;

    public UnitOfWorkBehavior(IEnumerable<IUnitOfWork> unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await next();

        foreach (var unitOfWork in _unitOfWorks)
        {
            await unitOfWork.CommitAsync(cancellationToken);
        }

        return result;
    }
}