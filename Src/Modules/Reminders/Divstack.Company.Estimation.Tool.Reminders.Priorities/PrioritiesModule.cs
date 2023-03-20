using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Reminders")]
namespace Divstack.Company.Estimation.Tool.Reminders.Priorities;

using System.Diagnostics.CodeAnalysis;
using DeadlineClose.Reminder;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
internal static class PrioritiesModule
{
    private const string Configuration = "Configuration";
    private const string Reminder = "Reminder";

    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<PriorityDeadlineCloseReminder>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblyOf<PriorityDeadlineCloseReminder>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Reminder)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
