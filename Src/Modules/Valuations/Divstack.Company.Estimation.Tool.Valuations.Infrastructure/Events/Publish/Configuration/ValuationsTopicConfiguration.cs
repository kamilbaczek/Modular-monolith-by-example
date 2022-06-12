namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class ValuationsTopicConfiguration : IValuationsTopicConfiguration
{
    private const string Valuations = "Valuations";
    private const string ValuationsTopicKey = $"{Valuations}:{nameof(TopicName)}";
    private readonly IConfiguration _configuration;
    public ValuationsTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(ValuationsTopicKey, nameof(TopicName)));
}
