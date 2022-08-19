﻿namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.FeatureFlags;

public interface IFeatureFlagsChecker
{
    Task<bool> IsEnabledAsync(FeatureFlag featureFlag, CancellationToken cancellationToken = default);
    bool IsEnabled(FeatureFlag featureFlag);
}
