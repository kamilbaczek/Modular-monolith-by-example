using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Push;

using Api;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payments;
using Valuations;

internal static class PushModule
{
    internal static IServiceCollection AddPushNotificationsModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDataAccess(configuration);
        services.AddPushValuations();
        services.AddPushPayments();
        services.AddPushNotificationsApi();

        return services;
    }

    internal static void UsePushNotificationsModule(this IApplicationBuilder app)
    {
        app.UsePushValuations();
        app.UsePushPayments();
    }
}
