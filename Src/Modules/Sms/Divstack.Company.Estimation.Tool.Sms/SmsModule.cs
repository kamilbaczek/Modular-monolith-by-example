using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Sms;

using Core;
using Divstack.Estimation.Tool.Sms.Payments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class SmsModule
{
    internal static IServiceCollection AddSmsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSmsCoreModule(configuration);
        services.AddPayments();

        return services;
    }
}
