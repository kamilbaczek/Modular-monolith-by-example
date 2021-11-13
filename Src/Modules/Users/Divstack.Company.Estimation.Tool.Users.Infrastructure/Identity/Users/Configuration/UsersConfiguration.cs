namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Configuration;

using Domain.Users.Interfaces;
using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal class UsersConfiguration : ConfigurationBase, IUsersConfiguration
{
    private const string SectionName = "Users";

    public UsersConfiguration(IConfiguration configuration) : base(configuration, SectionName)
    {
    }

    public int PasswordExpirationFrequency =>
        configurationSection.GetValue<int>(nameof(PasswordExpirationFrequency));
}
