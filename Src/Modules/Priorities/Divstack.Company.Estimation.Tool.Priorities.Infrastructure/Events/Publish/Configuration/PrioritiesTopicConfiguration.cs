namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class PrioritiesTopicConfiguration : IPrioritiesTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Priorities = "Priorities";
    public PrioritiesTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private const string PrioritiesTopicKey = $"{Priorities}:{nameof(TopicName)}";

    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(PrioritiesTopicKey, nameof(TopicName)));
}
