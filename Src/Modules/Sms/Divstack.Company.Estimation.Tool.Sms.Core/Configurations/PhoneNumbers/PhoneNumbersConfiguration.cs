namespace Divstack.Company.Estimation.Tool.Sms.Core.Configurations.PhoneNumbers;

using Microsoft.Extensions.Configuration;

internal sealed class PhoneNumbersConfiguration : IPhoneNumbersConfiguration
{
    private readonly IConfigurationSection _configurationSection;
    private const string PhoneNumbers = "PhoneNumbers";
    public PhoneNumbersConfiguration(IConfiguration configuration)
    {
        _configurationSection = configuration.GetSection(PhoneNumbers);
    }
    public string From => _configurationSection.GetValue<string>(nameof(From));
}
