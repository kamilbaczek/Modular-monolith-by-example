namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Subscribe;

using Microsoft.Extensions.DependencyInjection;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Valuations;
using Valuations.Configuration;

internal static class SubscribersModule
{
    internal static void AddSubscribers(this IServiceCollection services)
    {
        services.AddSingleton<IValuationsTopicConfiguration, ValuationsTopicConfiguration>();

        services.Subscribe<ValuationRequested>();
        services.Subscribe<ProposalSuggested>();
    }
}
