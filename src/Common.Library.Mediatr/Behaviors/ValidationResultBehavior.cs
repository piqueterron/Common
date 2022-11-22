namespace Common.Library.Mediatr;

using Common.Library.Core;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public sealed class ValidationResultBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse>>
    where TRequest : notnull, IRequest<Result<TResponse>>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationResultBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<Result<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Result<TResponse>> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var errors = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (errors.Any())
            {
                return Error.Create("Request validation fail", new ValidationException(errors));
            }
        }

        return await next();
    }
}