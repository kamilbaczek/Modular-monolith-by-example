namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Telemetry;

using System.Security.Claims;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;

internal static class RequestTelemetryExtensions
{
    private const string UserPropertyName = "User";
    private const string AnonymousUser = "Anonymous";

    internal static void AddUser(this RequestTelemetry requestTelemetry, IHttpContextAccessor _httpContextAccessor)
    {
        var userId = GetPublicUserId(_httpContextAccessor);
        var userIdAsString = userId == Guid.Empty ? AnonymousUser : userId.ToString();
        requestTelemetry.Context.GlobalProperties.Add(UserPropertyName, userIdAsString);
    }
    private static Guid GetPublicUserId(IHttpContextAccessor _httpContextAccessor)
    {
        var userPublicId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return !string.IsNullOrEmpty(userPublicId?.Value) ? Guid.Parse(userPublicId.Value) : Guid.Empty;
    }


    internal static async Task AddRequestBody(this RequestTelemetry requestTelemetry, IHttpContextAccessor httpContextAccessor)
    {
        var request = httpContextAccessor.HttpContext.Request;
        if (request.Method != HttpMethod.Post.ToString()) return;
        using var streamReader = new StreamReader(request.Body);
        string requestBody = await streamReader.ReadToEndAsync();
        requestTelemetry.Properties.Add("body", requestBody);
    }
}
