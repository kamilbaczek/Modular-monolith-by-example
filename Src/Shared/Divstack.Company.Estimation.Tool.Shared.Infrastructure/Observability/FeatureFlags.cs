namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag ObservabilityModule => FeatureFlag.Define(nameof(ObservabilityModule));
}
