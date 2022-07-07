namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.FeatureFlags;

public record FeatureFlag(string Value)
{
    public static FeatureFlag Define(string name) => new(name);
}
