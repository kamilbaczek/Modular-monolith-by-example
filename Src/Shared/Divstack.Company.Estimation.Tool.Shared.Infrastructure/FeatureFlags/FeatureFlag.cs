namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.FeatureFlags;

public record struct FeatureFlag(string Value)
{
    public static FeatureFlag Define(string name) => new(name);
}
