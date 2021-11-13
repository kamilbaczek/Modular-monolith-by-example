namespace Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration;

using Microsoft.Extensions.Configuration;

public abstract class ConfigurationBase
{
    protected IConfigurationSection configurationSection;

    protected ConfigurationBase(IConfiguration configuration, string sectionName)
    {
        configurationSection = configuration.GetSection(sectionName);
    }
}
