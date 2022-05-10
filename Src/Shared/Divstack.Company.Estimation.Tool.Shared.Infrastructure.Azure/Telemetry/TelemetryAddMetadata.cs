namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Telemetry;

using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;
using Utils;

internal sealed class TelemetryAddMetadata : ITelemetryInitializer
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TelemetryAddMetadata(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Initialize(ITelemetry telemetry)
    {
        if (telemetry is not RequestTelemetry requestTelemetry) return;
        requestTelemetry.AddUser(_httpContextAccessor);
        // AsyncUtil.RunSync(() => requestTelemetry.AddRequestBody(_httpContextAccessor));
    }
}
