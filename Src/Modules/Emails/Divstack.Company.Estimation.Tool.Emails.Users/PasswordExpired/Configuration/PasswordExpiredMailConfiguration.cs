using Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired.Configuration
{
    internal sealed class PasswordExpiredMailConfiguration : ConfigurationBase, IPasswordExpiredMailConfiguration
    {
        public PasswordExpiredMailConfiguration(IConfiguration configuration) : base(configuration,
            "PasswordExpiredMailConfiguration")
        {
        }

        public string Subject => configurationSection.GetValue<string>(nameof(Subject));

        public string Format => configurationSection.GetValue<string>(nameof(Format));
    }
}