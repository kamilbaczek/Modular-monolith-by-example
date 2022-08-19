using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Reminders;

using Microsoft.Extensions.DependencyInjection;
using Priorities;
using Shared.Infrastructure.FeatureFlags;

internal static class RemindersModule
{
    internal static void AddRemindersModule(this IServiceCollection services)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!moduleEnabled) return;

        services.AddValuations();
    }
}
