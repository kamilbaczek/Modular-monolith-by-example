namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted.Configuration;

using Microsoft.Extensions.Configuration;
using PaymentInitialized.Configuration;
using Shared.Abstractions.Configuration;

internal class PaymentCompletedMailConfiguration : ConfigurationBase,
    IPaymentCompletedMailConfiguration
{
    public PaymentCompletedMailConfiguration(IConfiguration configuration) : base(configuration,
        nameof(PaymentInitializedMailConfiguration))
    {
    }

    public string Subject => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(Subject)), nameof(Subject));
    public string PathToTemplate => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(PathToTemplate)), nameof(PathToTemplate));
}
