namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Subscribe.Valuations;

using Configuration;
using Shared.Infrastructure.EventBus.Subscribe;

internal sealed class ValuationsEventSubscriber<TEvent> : IntegrationEventSubscriber<TEvent> where TEvent : class
{
    public ValuationsEventSubscriber(
        IServiceProvider serviceProvider,
        IValuationsTopicConfiguration topicConfiguration) :
        base(serviceProvider, topicConfiguration)
    {
    }
}
