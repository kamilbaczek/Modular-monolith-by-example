using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Bootstrapper;

using Microsoft.Extensions.DependencyInjection;
using Tool.Emails.Core;
using Tool.Emails.Payments;
using Tool.Emails.Users;
using Tool.Emails.Valuations;

internal static class EmailsModule
{
    internal static IServiceCollection AddEmailsModule(this IServiceCollection services)
    {
        services.AddCore();
        services.AddUsers();
        services.AddValuations();
        services.AddPayments();

        return services;
    }
}
