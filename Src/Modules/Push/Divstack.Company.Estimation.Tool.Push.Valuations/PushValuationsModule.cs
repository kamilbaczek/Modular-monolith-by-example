using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.Valuations;

using System.Reflection;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.EventBus.Publish.Extensions;

internal static class PushValuationsModule
{
    public static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddIntegrationEventsHandlers(typeof(PushValuationsModule));

        return services;
    }

    public static void UseValuations(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapHub<ValuationsHub>(ValuationsHub.HubUrlPattern);
        });
    }
}
