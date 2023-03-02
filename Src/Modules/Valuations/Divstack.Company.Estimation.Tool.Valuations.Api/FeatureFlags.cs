namespace Divstack.Company.Estimation.Tool.Valuations.Api;

using Shared.Infrastructure.FeatureFlags;

[ExcludeFromCodeCoverage]
internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(ValuationModule));
}
