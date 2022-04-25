namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Subscribe.Inquiries.Configuration;

using Microsoft.Extensions.Configuration;

internal sealed class InquiryTopicConfiguration : IInquiryTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string InquiryTopic = "InquiryTopic";

    public InquiryTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string TopicName => _configuration.GetValue<string>($"{InquiryTopic}:{nameof(TopicName)}");
    public string SubscriptionName => _configuration.GetValue<string>($"{InquiryTopic}:{nameof(SubscriptionName)}");
}
