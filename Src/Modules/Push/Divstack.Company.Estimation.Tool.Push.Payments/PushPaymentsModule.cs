using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.Payments;

using System.Reflection;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class PushPaymentsModule
{
    internal static IServiceCollection AddPushPayments(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }

    internal static void UsePushPayments(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapHub<PaymentsHub>(PaymentsHub.HubUrlPattern);
        });
    }
}
