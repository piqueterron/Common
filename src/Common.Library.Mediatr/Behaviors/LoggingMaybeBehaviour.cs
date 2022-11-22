namespace Common.Library.Mediatr;

using Common.Library.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

public sealed class LoggingMaybeBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, Maybe<TResponse>>
    where TRequest : notnull, IRequest<Maybe<TResponse>>
{
    private readonly ILogger<LoggingMaybeBehaviour<TRequest, TResponse>> _logger;

    public LoggingMaybeBehaviour(ILogger<LoggingMaybeBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<Maybe<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Maybe<TResponse>> next, CancellationToken cancellationToken)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            Trace(request);
        }

        var response = await next();

        if (_logger.IsEnabled(LogLevel.Debug))
        {
            Trace(response);
        }

        return response;
    }

    private void Trace<T>(T @object)
    {
        var type = @object.GetType();

        var props = new List<PropertyInfo>(type.GetProperties());

        foreach (var prop in props)
        {
            var propValue = prop.GetValue(@object, null);

            _logger.LogDebug("{Name} => {Property} : {@Value}", typeof(T).Name, prop.Name, propValue);
        }
    }
}
