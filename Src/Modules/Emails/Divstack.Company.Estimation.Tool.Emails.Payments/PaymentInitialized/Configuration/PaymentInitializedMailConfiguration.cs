namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal class PaymentInitializedMailConfiguration : ConfigurationBase,
    IPaymentInitializedMailConfiguration
{
    public PaymentInitializedMailConfiguration(IConfiguration configuration) : base(configuration,
        nameof(PaymentInitializedMailConfiguration))
    {
    }

    public string Subject => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(Subject)), nameof(Subject));
    public string PaymentUrl => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(PaymentUrl)), nameof(PaymentUrl));
    public string PathToTemplate => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(PathToTemplate)), nameof(PathToTemplate));
}
