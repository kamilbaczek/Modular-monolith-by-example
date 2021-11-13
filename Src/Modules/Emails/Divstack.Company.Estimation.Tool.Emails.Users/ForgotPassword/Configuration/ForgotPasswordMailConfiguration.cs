namespace Divstack.Company.Estimation.Tool.Emails.Users.ForgotPassword.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class ForgotPasswordMailConfiguration : ConfigurationBase, IForgotPasswordMailConfiguration
{
    public ForgotPasswordMailConfiguration(IConfiguration configuration) : base(configuration,
        "ForgotPasswordMailConfiguration")
    {
    }

    public string Subject => configurationSection.GetValue<string>(nameof(Subject));

    public string Format => configurationSection.GetValue<string>(nameof(Format));
}
