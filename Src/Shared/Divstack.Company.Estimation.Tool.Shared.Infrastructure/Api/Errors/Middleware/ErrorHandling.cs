namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Api.Errors.Middleware;

using System.Net;
using Environments;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

internal sealed class ErrorHandling
{
    private readonly ILogger<ErrorHandling> _logger;
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ErrorHandling(RequestDelegate next,
        IWebHostEnvironment webHostEnvironment, ILogger<ErrorHandling> logger)
    {
        _next = next;
        _webHostEnvironment = webHostEnvironment;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var message = GetMessage(exception);
        _logger.LogError(message);
        var code = HttpStatusCode.InternalServerError;
        if (exception.IsNotFoundException())
        {
            code = HttpStatusCode.NotFound;
        }

        if (exception.IsValidationException())
        {
            code = HttpStatusCode.BadRequest;
        }

        var response = _webHostEnvironment.IsProduction() ? ExceptionDto.CreateInternalServerError() : ExceptionDto.CreateWithMessage(message);

        return SendResponse(context, code, response);
    }

    private static Task SendResponse(HttpContext context, HttpStatusCode code, ExceptionDto response)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        var jsonResponseBody = JsonSerializer.Serialize(response);

        return context.Response.WriteAsync(jsonResponseBody);
    }

    private static string GetMessage(Exception exception) => $"{exception.Message} {exception.StackTrace}";
}
