using Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration;
using Divstack.Company.Estimation.Tool.Users.Domain.Users.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Configuration
{
    internal class UsersConfiguration : ConfigurationBase, IUsersConfiguration
    {
        private const string SectionName = "Users";

        public UsersConfiguration(IConfiguration configuration) : base(configuration, SectionName)
        {
        }

        public int PasswordExpirationFrequency =>
            configurationSection.GetValue<int>(nameof(PasswordExpirationFrequency));
    }
}