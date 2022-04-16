namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.HealthChecks.FeatureFlag;

using Azure.Configuration.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag HealthChecksIU => new(nameof(HealthChecksIU));
}
