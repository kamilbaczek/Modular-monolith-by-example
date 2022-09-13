using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello;

using Core;
using Extensions;
using Features.ValuationRequest;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.FeatureFlags;

internal static class TrelloModule
{
    private const string Configuration = "Configuration";

    internal static IServiceCollection AddTrello(this IServiceCollection services)
    {
        var enabled = services.IsModuleEnabled(FeatureFlags.Module);
        if (!enabled) return services;

        services.Scan(scan => scan.FromAssemblyOf<ValuationRequestCreatedTrelloEventHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        services.AddScoped<ITrelloTaskCreator, TrelloTaskCreator>();

        return services;
    }

    internal static void UseTrello(this IApplicationBuilder app)
    {
        var enabled = app.IsModuleEnabled(FeatureFlags.Module);
        if (!enabled) return;
        app.UseTrelloAuthentication();
    }
}
