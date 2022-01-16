namespace Divstack.Company.Estimation.Tool.Sms.Core.Configurations.Sms;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class SmsConfiguration : ISmsConfiguration
{
    private const string Twillo = "Twillo";

    private readonly IConfigurationSection _configuration;
    public SmsConfiguration(IConfiguration configuration)
    {
        _configuration = configuration.GetSection(Twillo);
    }

    public string AccountSid => Guard.Against.NullOrEmpty(_configuration.GetValue<string>(nameof(AccountSid)), nameof(AccountSid));
    public string AuthToken => Guard.Against.NullOrEmpty(_configuration.GetValue<string>(nameof(AuthToken)), nameof(AuthToken));
}
