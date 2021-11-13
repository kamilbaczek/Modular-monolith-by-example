namespace Divstack.Company.Estimation.Tool.Emails.Users.PasswordExpired.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class PasswordExpiredMailConfiguration : ConfigurationBase, IPasswordExpiredMailConfiguration
{
    public PasswordExpiredMailConfiguration(IConfiguration configuration) : base(configuration,
        "PasswordExpiredMailConfiguration")
    {
    }

    public string Subject => configurationSection.GetValue<string>(nameof(Subject));

    public string Format => configurationSection.GetValue<string>(nameof(Format));
}
