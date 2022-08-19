namespace Divstack.Company.Estimation.Tool.Sms;

using Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(SmsModule));
}
