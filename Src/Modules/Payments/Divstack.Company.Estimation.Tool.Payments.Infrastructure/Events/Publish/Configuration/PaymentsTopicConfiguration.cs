namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class PaymentsTopicConfiguration : IPaymentsTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Payments = "Payments";
    public PaymentsTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private const string PaymentsTopicKey = $"{Payments}:{nameof(TopicName)}";

    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(PaymentsTopicKey, nameof(TopicName)));
}
