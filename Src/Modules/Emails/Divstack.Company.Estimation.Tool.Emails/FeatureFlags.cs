namespace Divstack.Company.Estimation.Tool.Modules.Emails.Bootstrapper;

using Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(EmailsModule));
}
