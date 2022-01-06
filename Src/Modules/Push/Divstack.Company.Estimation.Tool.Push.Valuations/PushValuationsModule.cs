using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Push")]

namespace Divstack.Company.Estimation.Tool.Push.Valuations;

using System.Reflection;
using Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

internal static class PushValuationsModule
{
    public static IServiceCollection AddPushValuations(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }

    public static void UsePushValuations(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapHub<ValuationsHub>(ValuationsHub.HubUrlPattern);
        });
    }
}
