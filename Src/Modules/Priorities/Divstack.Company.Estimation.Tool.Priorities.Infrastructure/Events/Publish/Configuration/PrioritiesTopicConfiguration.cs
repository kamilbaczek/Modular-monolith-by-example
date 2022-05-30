namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class PrioritiesTopicConfiguration : IPrioritiesTopicConfiguration
{
    private const string Priorities = "Priorities";
    private const string PrioritiesTopicKey = $"{Priorities}:{nameof(TopicName)}";
    private readonly IConfiguration _configuration;
    public PrioritiesTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(PrioritiesTopicKey, nameof(TopicName)));
}
