using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration
{
    public abstract class ConfigurationBase
    {
        private IConfiguration _configuration;
        protected IConfigurationSection configurationSection;

        protected ConfigurationBase(IConfiguration configuration, string sectionName)
        {
            _configuration = configuration;
            configurationSection = configuration.GetSection(sectionName);
        }
    }
}