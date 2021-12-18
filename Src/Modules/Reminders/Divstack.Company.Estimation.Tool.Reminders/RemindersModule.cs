using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Reminders;

using Microsoft.Extensions.DependencyInjection;
using Valuations;

internal static class RemindersModule
{
    internal static IServiceCollection AddRemindersModule(this IServiceCollection services)
    {
        services.AddValuations();

        return services;
    }
}
