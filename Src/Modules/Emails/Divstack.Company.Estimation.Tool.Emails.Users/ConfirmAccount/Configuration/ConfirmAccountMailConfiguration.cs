namespace Divstack.Company.Estimation.Tool.Emails.Users.ConfirmAccount.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class ConfirmAccountMailConfiguration : ConfigurationBase, IConfirmAccountMailConfiguration
{
    public ConfirmAccountMailConfiguration(IConfiguration configuration) : base(configuration,
        "ConfirmAccountMailConfiguration")
    {
    }

    public string Subject => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(Subject)));

    public string Format => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(Format)));
}
