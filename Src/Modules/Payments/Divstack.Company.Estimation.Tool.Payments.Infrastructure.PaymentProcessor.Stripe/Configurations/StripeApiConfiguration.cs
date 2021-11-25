namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Configurations;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class StripeApiConfiguration
{
    private const string StripeConfigurationSectionName = "StripeApi";
    private readonly IConfigurationSection _configurationSection;

    internal StripeApiConfiguration(IConfiguration configuration)
    {
        _configurationSection = configuration.GetSection(StripeConfigurationSectionName);
    }

    internal string ApiKey => Guard.Against.Null(_configurationSection.GetValue<string>(nameof(ApiKey)), nameof(ApiKey));
}
