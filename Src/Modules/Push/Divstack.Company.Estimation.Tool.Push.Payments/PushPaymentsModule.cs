using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.Payments;

using System.Reflection;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.EventBus.Subscribe.Extensions;

internal static class PushPaymentsModule
{
    internal static IServiceCollection AddPayments(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddIntegrationEventsHandlers(typeof(PushPaymentsModule));

        return services;
    }

    internal static void UsePayments(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapHub<PaymentsHub>(PaymentsHub.HubUrlPattern);
        });
    }
}
