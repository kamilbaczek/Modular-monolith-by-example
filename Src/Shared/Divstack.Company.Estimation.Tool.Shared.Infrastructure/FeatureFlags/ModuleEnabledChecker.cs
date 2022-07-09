namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.FeatureFlags;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class ModuleEnabledChecker
{
    public static bool IsModuleEnabled(this IServiceCollection services, FeatureFlag featureFlag)
    {
        var buildServiceProvider = services.BuildServiceProvider();
        var featureFlagsChecker = buildServiceProvider.GetRequiredService<IFeatureFlagsChecker>();
        var enabled = featureFlagsChecker.IsEnabled(featureFlag);

        return enabled;
    }

    public static bool IsModuleEnabled(this IApplicationBuilder applicationBuilder, FeatureFlag featureFlag)
    {
        var buildServiceProvider = applicationBuilder.ApplicationServices;
        var featureFlagsChecker = buildServiceProvider.GetRequiredService<IFeatureFlagsChecker>();
        var enabled = featureFlagsChecker.IsEnabled(featureFlag);

        return enabled;
    }
}
