using Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Configuration;

internal sealed class ConfirmAccountMailConfiguration : ConfigurationBase, IConfirmAccountMailConfiguration
{
    public ConfirmAccountMailConfiguration(IConfiguration configuration) : base(configuration,
        "ConfirmAccountMailConfiguration")
    {
    }

    public string Subject => configurationSection.GetValue<string>("Subject");

    public string Format => configurationSection.GetValue<string>("Format");
}
