using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Modules.Emails.Bootstrapper;

using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.FeatureFlags;
using Tool.Emails.Core;
using Tool.Emails.Payments;
using Tool.Emails.Priorities;
using Tool.Emails.Users;
using Tool.Emails.Valuations;

internal static class EmailsModule
{
    internal static void AddEmailsModule(this IServiceCollection services)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!moduleEnabled) return;

        services.AddCore();
        services.AddUsers();
        services.AddValuations();
        services.AddPayments();
        services.AddPriorities();
    }
}
