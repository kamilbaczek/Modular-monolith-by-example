namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class MailConfiguration : ConfigurationBase, IMailConfiguration
{
    public MailConfiguration(IConfiguration configuration) : base(configuration, "Mail")
    {
    }

    public string ServerAddress => configurationSection[nameof(ServerAddress)];

    public int ServerPort => int.Parse(configurationSection[nameof(ServerPort)]);

    public string ServerLogin => configurationSection[nameof(ServerLogin)];

    public string ServerPassword => configurationSection[nameof(ServerPassword)];

    public string MailFrom => configurationSection[nameof(MailFrom)];
    public bool DisableSsl => bool.Parse(configurationSection[nameof(DisableSsl)]);
}
