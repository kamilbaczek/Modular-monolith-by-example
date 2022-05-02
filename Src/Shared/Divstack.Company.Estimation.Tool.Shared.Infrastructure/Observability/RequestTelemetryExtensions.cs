namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;

internal static class RequestTelemetryExtensions
{
    private static string Env = "Env";
    private const string UserPropertyName = "User";
    internal static void AddUser(this RequestTelemetry requestTelemetry, Guid userId)
    {
        requestTelemetry.Context.GlobalProperties.Add(UserPropertyName, userId.ToString());
    }

    internal async static Task AddRequestBody(this RequestTelemetry requestTelemetry, IHttpContextAccessor httpContextAccessor)
    {
        var request = httpContextAccessor.HttpContext.Request;
        if (request.Method != HttpMethod.Post.ToString() && request.Method != HttpMethod.Put.ToString() && request.Method != HttpMethod.Patch.ToString()) return;
        using var streamReader = new StreamReader(request.Body);
        string requestBody = await streamReader.ReadToEndAsync();
        requestTelemetry.Properties.Add("body", requestBody);

    }

    internal static void AddEnv(this RequestTelemetry requestTelemetry)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        requestTelemetry.Context.GlobalProperties.Add(Env, environmentName);
    }
}
