[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Priorities;

using DeadlineClose.Sender;
using Microsoft.Extensions.DependencyInjection;

internal static class PrioritiesModule
{
    private const string Configuration = "Configuration";
    private const string Sender = "Sender";

    internal static IServiceCollection AddPriorities(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<IPriorityCloseToDeadlineMailSender>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        services.Scan(scan => scan.FromAssemblyOf<IPriorityCloseToDeadlineMailSender>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Sender)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
