namespace Divstack.Company.Estimation.Tool.Push;

using Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(PushModule));
}
