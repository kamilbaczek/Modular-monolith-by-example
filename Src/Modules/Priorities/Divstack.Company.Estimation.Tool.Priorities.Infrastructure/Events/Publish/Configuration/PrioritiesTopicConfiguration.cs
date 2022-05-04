namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Publish.Configuration;

using Microsoft.Extensions.Configuration;

internal sealed class PrioritiesTopicConfiguration : IPrioritiesTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Priorities = "Priorities";
    public PrioritiesTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string TopicName => _configuration.GetValue<string>($"{Priorities}:{nameof(TopicName)}");
}
