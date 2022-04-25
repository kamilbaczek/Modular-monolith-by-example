namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Subscribe.Inquiries;

using Configuration;
using Shared.Infrastructure.EventBus;

internal sealed class InquiryEventSubscriber<TEvent> : IntegrationEventSubscriber<TEvent> where TEvent : class
{
    public InquiryEventSubscriber(
        IServiceProvider serviceProvider,
        IInquiryTopicConfiguration topicConfiguration) :
        base(serviceProvider, topicConfiguration)
    {
    }
}
