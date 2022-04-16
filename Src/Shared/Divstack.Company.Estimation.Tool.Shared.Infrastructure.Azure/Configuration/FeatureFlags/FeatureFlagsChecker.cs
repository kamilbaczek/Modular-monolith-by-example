namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Configuration.FeatureFlags;

using Microsoft.FeatureManagement;
using Utils;

internal sealed class FeatureFlagsChecker : IFeatureFlagsChecker
{
    private readonly IFeatureManager _featureManager;

    public FeatureFlagsChecker(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }
    public async Task<bool> IsEnabledAsync(FeatureFlag featureFlag, CancellationToken cancellationToken = default)
    {
        return await _featureManager.IsEnabledAsync(featureFlag.Value);
    }
    public bool IsEnabled(FeatureFlag featureFlag)
    {
        return AsyncUtil.RunSync(() => _featureManager.IsEnabledAsync(featureFlag.Value));
    }
}
