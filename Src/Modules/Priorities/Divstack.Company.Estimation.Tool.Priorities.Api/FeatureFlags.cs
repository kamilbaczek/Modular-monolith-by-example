namespace Divstack.Company.Estimation.Tool.Priorities.Api;

using Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(PrioritiesModule));
}
