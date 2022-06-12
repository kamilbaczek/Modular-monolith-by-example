using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.Valuations;

using Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class PushValuationsModule
{
    public static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.AddSignalR();

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
