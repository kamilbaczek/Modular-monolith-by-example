using Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword.Configuration;

internal sealed class ForgotPasswordMailConfiguration : ConfigurationBase, IForgotPasswordMailConfiguration
{
    public ForgotPasswordMailConfiguration(IConfiguration configuration) : base(configuration,
        "ForgotPasswordMailConfiguration")
    {
    }

    public string Subject => configurationSection.GetValue<string>(nameof(Subject));

    public string Format => configurationSection.GetValue<string>(nameof(Format));
}
