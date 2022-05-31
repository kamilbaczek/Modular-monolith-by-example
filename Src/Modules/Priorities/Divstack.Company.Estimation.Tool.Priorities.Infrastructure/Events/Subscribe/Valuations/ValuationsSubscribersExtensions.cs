namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Subscribe.Valuations;

using Microsoft.Extensions.DependencyInjection;

internal static class ValuationsSubscribersExtensions
{
    internal static void Subscribe<TEvent>(this IServiceCollection services) where TEvent : class
    {
        services.AddHostedService<ValuationsEventSubscriber<TEvent>>();
    }
}
