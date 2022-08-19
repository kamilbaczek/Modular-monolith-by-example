namespace Divstack.Company.Estimation.Tool.Reminders;

using Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(RemindersModule));
}
