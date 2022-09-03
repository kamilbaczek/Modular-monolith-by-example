namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Mediation.Decorators.Logging;

using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

internal sealed class LoggingDecorator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<LoggingDecorator<TRequest, TResponse>> _logger;
    private readonly bool _debugMode;

    public LoggingDecorator(ILogger<LoggingDecorator<TRequest, TResponse>> logger)
    {
        _logger = logger;
        _debugMode = _logger.IsEnabled(LogLevel.Debug);
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_debugMode)
            LogRequest(request);

        var response = await next();

        if (_debugMode)
            LogResponse(response);

        return response;
    }

    private void LogResponse(TResponse response)
    {
        var responseAsString = JsonSerializer.Serialize(response);
        _logger.LogDebug("[{Command}] Handling Finished {Response}", typeof(TResponse).Name, responseAsString);
    }

    private void LogRequest(TRequest request)
    {
        var requestAsString = JsonSerializer.Serialize(request);
        _logger.LogDebug("[{Command}] Handling started request: {Request}", typeof(TRequest).Name, requestAsString);
    }
}
