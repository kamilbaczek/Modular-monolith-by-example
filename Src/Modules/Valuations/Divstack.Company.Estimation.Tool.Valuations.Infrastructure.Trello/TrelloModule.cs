using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello;

using Core;
using Extensions;
using Features.ValuationRequest;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.EventBus.Subscribe.Extensions;

internal static class TrelloModule
{
    private const string Configuration = "Configuration";
    private const string EventHandler = "EventHandler";

    internal static IServiceCollection AddTrello(this IServiceCollection services)
    {
        services.AddIntegrationEventsHandlers(typeof(TrelloModule));
        services.Scan(scan => scan.FromAssemblyOf<ValuationRequestCreatedTrelloEventHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        services.Scan(scan => scan.FromAssemblyOf<ValuationRequestCreatedTrelloEventHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(EventHandler)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.AddScoped<ITrelloTaskCreator, TrelloTaskCreator>();

        return services;
    }

    internal static void UseTrello(this IApplicationBuilder app)
    {
        app.UseTrelloAuthentication();
    }
}
