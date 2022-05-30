namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class PaymentsTopicConfiguration : IPaymentsTopicConfiguration
{
    private const string Payments = "Payments";
    private const string PaymentsTopicKey = $"{Payments}:{nameof(TopicName)}";
    private readonly IConfiguration _configuration;
    public PaymentsTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(PaymentsTopicKey, nameof(TopicName)));
}
