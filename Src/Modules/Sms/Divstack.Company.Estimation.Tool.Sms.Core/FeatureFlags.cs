namespace Divstack.Company.Estimation.Tool.Sms.Core;

using Divstack.Company.Estimation.Tool.Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(SmsModule));
}
