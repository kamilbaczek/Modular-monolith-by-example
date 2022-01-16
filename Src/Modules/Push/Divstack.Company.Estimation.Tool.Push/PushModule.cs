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
    internal static IServiceCollection AddPushModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApi();
        services.AddDataAccess(configuration);

        services.AddValuations();
        services.AddPayments();

        return services;
    }

    internal static void UsePushModule(this IApplicationBuilder app)
    {
        app.UseValuations();
        app.UsePayments();
    }
}
