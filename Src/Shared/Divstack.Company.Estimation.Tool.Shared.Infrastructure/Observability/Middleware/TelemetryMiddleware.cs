namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability.Middleware;

using System.Text;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;

internal sealed class TelemetryMiddleware
{
    public TelemetryMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    private const string Responsebody = "ResponseBody";
    private const string Requestbody = "RequestBody";

    private static IReadOnlyCollection<string> AllowedMethodsToReadResponse = new List<string>
    {
        HttpMethods.Post,
        HttpMethods.Put,
        HttpMethods.Patch,
        HttpMethods.Get
    };
    private static IReadOnlyCollection<string> AllowedMethodsToReadRequest = new List<string>
    {
        HttpMethods.Post,
        HttpMethods.Put,
        HttpMethods.Patch,
    };

    private readonly RequestDelegate _next;

    public async Task Invoke(HttpContext context)
    {
        var method = context.Request.Method;
        context.Request.EnableBuffering();

        var requestTelemetry = context.Features.Get<RequestTelemetry>();

        var allowedReadRequest = IsMethodAllowToReadRequest(method);
        if (context.Request.Body.CanRead && allowedReadRequest)
        {
            await ReadRequestBody(context, requestTelemetry);
        }

        var allowedReadResponse = IsMethodAllowToReadResponse(method);
        if (allowedReadResponse)
        {
            await ExecuteAndReadResponseBody(context, requestTelemetry);
            return;
        }

        await _next(context);
    }
    private static async Task ReadRequestBody(HttpContext context, RequestTelemetry? requestTelemetry)
    {
        using var reader = new StreamReader(
            context.Request.Body,
            Encoding.UTF8,
            detectEncodingFromByteOrderMarks: false,
            bufferSize: 512, leaveOpen: true);

        var requestBody = await reader.ReadToEndAsync();

        context.Request.Body.Position = 0;
        requestTelemetry?.Properties.Add(Requestbody, requestBody);
    }
    private async Task ExecuteAndReadResponseBody(HttpContext context, RequestTelemetry? requestTelemetry)
    {
        var originalBodyStream = context.Response.Body;

        await using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        await _next(context);

        memoryStream.Seek(0, SeekOrigin.Begin);
        var responseBodyText = await new StreamReader(memoryStream).ReadToEndAsync();
        requestTelemetry?.Properties.Add(Responsebody, responseBodyText);
        memoryStream.Seek(0, SeekOrigin.Begin);
        context.Response.Body = originalBodyStream;
        await context.Response.Body.WriteAsync(memoryStream.ToArray());
    }

    private static bool IsMethodAllowToReadResponse(string method)
    {
        return AllowedMethodsToReadResponse.Contains(method);
    }

    private static bool IsMethodAllowToReadRequest(string method)
    {
        return AllowedMethodsToReadRequest.Contains(method);
    }
}
