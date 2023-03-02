namespace Divstack.Company.Estimation.Tool.Users.Api;

using Shared.Infrastructure.FeatureFlags;

[ExcludeFromCodeCoverage]
internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(UsersModule));
}
