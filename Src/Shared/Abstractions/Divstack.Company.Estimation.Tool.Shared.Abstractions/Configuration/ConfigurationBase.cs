using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration
{
    public abstract class ConfigurationBase
    {
        protected IConfigurationSection configurationSection;

        protected ConfigurationBase(IConfiguration configuration, string sectionName)
        {
            configurationSection = configuration.GetSection(sectionName);
        }
    }
}
