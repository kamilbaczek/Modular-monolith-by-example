using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.TemplateReader;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core
{
    internal static class EmailCoreModule
    {
        internal static IServiceCollection AddEmailCore(this IServiceCollection services)
        {
            services.AddScoped<IEmailModule, EmailModule>();
            services.AddSingleton<IMailConfiguration, MailConfiguration>();
            services.AddScoped<IMailTemplateReader, MailTemplateReader>();

            return services;
        }
    }
}
