namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal class AdminAccountConfiguration : ConfigurationBase, IAdminAccountConfiguration
{
    private const string SectionName = "AdminAccount";

    public AdminAccountConfiguration(IConfiguration configuration) : base(configuration, SectionName)
    {
    }

    public bool Init =>
        configurationSection.GetValue<bool>(nameof(Init));

    public string UserName =>
        configurationSection.GetValue<string>(nameof(UserName));

    public string Email =>
        configurationSection.GetValue<string>(nameof(Email));

    public string Password =>
        configurationSection.GetValue<string>(nameof(Password));
}
