namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Configuration;

using Microsoft.Extensions.Configuration;

internal sealed class InquiriesTopicConfiguration : IInquiriesTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Inquiries = "Inquiries";
    public InquiriesTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string TopicName => _configuration.GetValue<string>($"{Inquiries}:{nameof(TopicName)}");
}
