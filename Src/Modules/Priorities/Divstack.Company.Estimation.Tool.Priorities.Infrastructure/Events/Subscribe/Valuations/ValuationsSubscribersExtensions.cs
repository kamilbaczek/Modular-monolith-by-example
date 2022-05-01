namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Subscribe.Inquiries;

using Microsoft.Extensions.DependencyInjection;
using Priorities.Infrastructure.Events.Subscribe.Inquiries;

internal static class ValuationsSubscribersExtensions
{
    internal static void Subscribe<TEvent>(this IServiceCollection services) where TEvent : class
    {
        services.AddHostedService<ValuationsEventSubscriber<TEvent>>();
    }
}
