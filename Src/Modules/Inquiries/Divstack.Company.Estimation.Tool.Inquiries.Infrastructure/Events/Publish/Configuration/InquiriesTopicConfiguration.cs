namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class InquiriesTopicConfiguration : IInquiriesTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Inquiries = "Inquiries";
    private const string InquiriesTopicKey = $"{Inquiries}:{nameof(TopicName)}";

    public InquiriesTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(InquiriesTopicKey, nameof(TopicName)));
}
