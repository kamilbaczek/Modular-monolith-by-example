using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Sms;

using Core;
using Divstack.Estimation.Tool.Sms.Payments;
using Divstack.Estimation.Tool.Sms.Valuations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.FeatureFlags;

internal static class SmsModule
{
    internal static void AddSmsModule(this IServiceCollection services, IConfiguration configuration)
    {
        var moduleEnabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!moduleEnabled) return;

        services.AddSmsCoreModule(configuration);
        services.AddPayments();
        services.AddValuations();
    }
}
