namespace Divstack.Company.Estimation.Tool.Emails.Core.Sender.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class MailConfiguration : ConfigurationBase, IMailConfiguration
{
    public MailConfiguration(IConfiguration configuration) : base(configuration, "Mail")
    {
    }

    public string MailFrom => configurationSection[nameof(MailFrom)];
    public string ApiKey => configurationSection[nameof(ApiKey)];
}
