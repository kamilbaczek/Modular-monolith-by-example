namespace Divstack.Company.Estimation.Tool.Emails.Users.PasswordExpired.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class PasswordExpiredMailConfiguration : ConfigurationBase, IPasswordExpiredMailConfiguration
{
    public PasswordExpiredMailConfiguration(IConfiguration configuration) : base(configuration,
        "PasswordExpiredMailConfiguration")
    {
    }

    public string Subject => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(Subject)));

    public string Format => Guard.Against.NullOrEmpty(configurationSection.GetValue<string>(nameof(Format)));
}
