namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Events.Subscribe.Inquiries;

using Shared.Infrastructure.EventBus.Subscribe;
using Valuations.Configuration;

internal sealed class ValuationsEventSubscriber<TEvent> : IntegrationEventSubscriber<TEvent> where TEvent : class
{
    public ValuationsEventSubscriber(
        IServiceProvider serviceProvider,
        IValuationsTopicConfiguration topicConfiguration) :
        base(serviceProvider, topicConfiguration)
    {
    }
}
