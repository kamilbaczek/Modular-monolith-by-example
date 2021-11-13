namespace Divstack.Company.Estimation.Tool.Emails.Users.ConfirmAccount.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class ConfirmAccountMailConfiguration : ConfigurationBase, IConfirmAccountMailConfiguration
{
    public ConfirmAccountMailConfiguration(IConfiguration configuration) : base(configuration,
        "ConfirmAccountMailConfiguration")
    {
    }

    public string Subject => configurationSection.GetValue<string>("Subject");

    public string Format => configurationSection.GetValue<string>("Format");
}
