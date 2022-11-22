namespace Common.Library.Mediatr;

using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

public sealed class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
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