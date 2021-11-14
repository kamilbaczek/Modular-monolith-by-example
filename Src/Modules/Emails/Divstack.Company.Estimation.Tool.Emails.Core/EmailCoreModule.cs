[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Core;

using Microsoft.Extensions.DependencyInjection;
using Modules.Emails.Core.Sender;
using Modules.Emails.Core.Sender.Configuration;
using Modules.Emails.Core.Sender.Contracts;
using Modules.Emails.Core.Sender.TemplateReader;

internal static class EmailCoreModule
{
    internal static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddSingleton<IMailConfiguration, MailConfiguration>();
        services.AddScoped<IMailTemplateReader, MailTemplateReader>();

        return services;
    }
}
