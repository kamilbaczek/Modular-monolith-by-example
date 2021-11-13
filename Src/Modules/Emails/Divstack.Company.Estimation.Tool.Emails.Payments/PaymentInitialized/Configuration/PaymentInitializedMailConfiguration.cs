namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal class PaymentInitializedMailConfiguration : ConfigurationBase,
    IPaymentInitializedMailConfiguration
{
    public PaymentInitializedMailConfiguration(IConfiguration configuration) : base(configuration,
        nameof(PaymentInitializedMailConfiguration))
    {
    }

    public string Subject => configurationSection.GetValue<string>(nameof(Subject));
    public string PaymentUrl => configurationSection.GetValue<string>(nameof(PaymentUrl));
    public string PathToTemplate => configurationSection.GetValue<string>(nameof(PathToTemplate));
}
