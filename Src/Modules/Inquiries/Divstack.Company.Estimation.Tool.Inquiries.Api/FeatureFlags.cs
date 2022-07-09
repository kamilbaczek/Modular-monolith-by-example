namespace Divstack.Company.Estimation.Tool.Inquiries.Api;

using Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(InquiriesModule));
}
