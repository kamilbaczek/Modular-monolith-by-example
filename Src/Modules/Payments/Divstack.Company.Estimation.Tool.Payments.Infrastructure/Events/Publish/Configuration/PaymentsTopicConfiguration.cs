namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Publish.Configuration;

using Microsoft.Extensions.Configuration;

internal sealed class PaymentsTopicConfiguration : IPaymentsTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Payments = "Payments";
    public PaymentsTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string TopicName => _configuration.GetValue<string>($"{Payments}:{nameof(TopicName)}");
}
