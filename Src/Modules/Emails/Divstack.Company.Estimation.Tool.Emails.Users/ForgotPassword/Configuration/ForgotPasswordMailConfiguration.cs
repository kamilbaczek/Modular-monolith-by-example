namespace Divstack.Company.Estimation.Tool.Emails.Users.ForgotPassword.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class ForgotPasswordMailConfiguration : ConfigurationBase, IForgotPasswordMailConfiguration
{
    public ForgotPasswordMailConfiguration(IConfiguration configuration) : base(configuration,
        "ForgotPasswordMailConfiguration")
    {
    }

    public string Subject => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(Subject), nameof(Subject));

    public string Format => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(Format), nameof(Format));
}
