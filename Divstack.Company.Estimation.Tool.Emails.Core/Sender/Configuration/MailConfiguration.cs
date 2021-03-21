using System;
using System.IO;
using Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Configuration
{
    internal sealed class MailConfiguration : ConfigurationBase, IMailConfiguration
    {
        public MailConfiguration(IConfiguration configuration) : base(configuration, "Mail")
        {
        }

        public string ServerAddress => configurationSection.GetValue<string>(nameof(ServerAddress));

        public int ServerPort => configurationSection.GetValue<int>(nameof(ServerPort));

        public string ServerLogin => configurationSection.GetValue<string>(nameof(ServerLogin));

        public string ServerPassword => configurationSection.GetValue<string>(nameof(ServerPassword));

        public string MailFrom => configurationSection.GetValue<string>(nameof(MailFrom));
        public bool DisableSsl => configurationSection.GetValue<bool>(nameof(DisableSsl));

        public string MailTemplate
        {
            get
            {
                var path = configurationSection.GetValue<string>("MailTemplatePath");
                var pathToTemplate = Path.Combine($"{AppDomain.CurrentDomain.BaseDirectory}", path);

                return File.ReadAllText(pathToTemplate);
            }
        }
    }
}