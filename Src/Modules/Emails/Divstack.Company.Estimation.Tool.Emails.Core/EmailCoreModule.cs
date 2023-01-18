[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Core;

using Microsoft.Extensions.DependencyInjection;
using Sender;
using Sender.Configuration;
using Sender.TemplateReader;

public static class EmailCoreModule
{
    internal static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddSingleton<IMailConfiguration, MailConfiguration>();
        services.AddScoped<IMailTemplateReader, MailTemplateReader>();

        return services;
    }
}
