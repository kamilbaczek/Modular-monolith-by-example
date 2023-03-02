namespace Divstack.Company.Estimation.Tool.Payments.Api;

using Shared.Infrastructure.FeatureFlags;

[ExcludeFromCodeCoverage]
internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(PaymentsModule));
}
