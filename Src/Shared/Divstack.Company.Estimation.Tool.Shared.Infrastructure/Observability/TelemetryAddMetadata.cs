namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using System.Security.Claims;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;

internal sealed class TelemetryAddMetadata : ITelemetryInitializer
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TelemetryAddMetadata(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry is not RequestTelemetry requestTelemetry) return;
        requestTelemetry.AddEnv();

        requestTelemetry.AddRequestBody(_httpContextAccessor);

        var userId = GetPublicUserId();
        requestTelemetry.AddUser(userId);
    }


    public Guid GetPublicUserId()
    {
        var userPublicId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return !string.IsNullOrEmpty(userPublicId?.Value) ? Guid.Parse(userPublicId.Value) : Guid.Empty;
    }
}
