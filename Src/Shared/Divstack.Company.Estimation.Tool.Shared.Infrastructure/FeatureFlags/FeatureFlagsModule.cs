[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.FeatureFlags;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

internal static class FeatureFlagsModule
{
    internal static void AddFeatureFlags(this IServiceCollection services)
    {
        services.AddFeatureManagement();
        services.AddSingleton<IFeatureFlagsChecker, FeatureFlagsChecker>();
    }
}
