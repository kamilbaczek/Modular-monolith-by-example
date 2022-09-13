namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello;

using Divstack.Company.Estimation.Tool.Shared.Infrastructure.FeatureFlags;

internal static class FeatureFlags
{
    internal static FeatureFlag Module => FeatureFlag.Define(nameof(TrelloModule));
}
