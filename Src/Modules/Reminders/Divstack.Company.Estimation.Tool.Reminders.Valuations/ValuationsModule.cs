using System.Reflection;
using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Reminder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Reminders")]

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations;

internal static class ValuationsModule
{
    private const string Configuration = "Configuration";
    private const string Reminder = "Reminder";

    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.Scan(scan => scan.FromAssemblyOf<ValuationsDeadlineCloseReminder>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblyOf<ValuationsDeadlineCloseReminder>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Reminder)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
