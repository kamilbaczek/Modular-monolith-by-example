namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Subscribe.Valuations.Configuration;

using Microsoft.Extensions.Configuration;

internal sealed class ValuationsTopicConfiguration : IValuationsTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Valuations = "Valuations";

    public ValuationsTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string TopicName => _configuration.GetValue<string>($"{Valuations}:{nameof(TopicName)}");
    public string SubscriptionName => _configuration.GetValue<string>($"{Valuations}:{nameof(SubscriptionName)}");
}
