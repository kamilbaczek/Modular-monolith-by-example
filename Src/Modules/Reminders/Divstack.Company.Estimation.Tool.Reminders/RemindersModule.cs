using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Reminders.Valuations;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Reminders
{
    internal static class RemindersModule
    {
        internal static IServiceCollection AddRemindersModule(this IServiceCollection services)
        {
            services.AddValuations();

            return services;
        }
    }
}