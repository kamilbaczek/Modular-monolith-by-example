namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class InquiriesTopicConfiguration : IInquiriesTopicConfiguration
{
    private const string Inquiries = "Inquiries";
    private const string InquiriesTopicKey = $"{Inquiries}:{nameof(TopicName)}";
    private readonly IConfiguration _configuration;

    public InquiriesTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(InquiriesTopicKey, nameof(TopicName)));
}
