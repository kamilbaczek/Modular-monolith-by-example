using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.Payments;

using Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class PushPaymentsModule
{
    internal static IServiceCollection AddPayments(this IServiceCollection services)
    {
        services.AddSignalR();

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
