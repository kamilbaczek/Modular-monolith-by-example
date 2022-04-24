namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Subscribe.Inquiries;

using Application.Valuations.Commands.SuggestProposal.Configuration;
using Shared.Infrastructure.EventBus;

internal sealed class InquiryEventSubscriber<TEvent> : IntegrationEventSubscriber<TEvent> where TEvent : class
{
    public InquiryEventSubscriber(
        IServiceProvider serviceProvider,
        InquiryTopicConfiguration topicConfiguration) :
        base(serviceProvider, topicConfiguration)
    {
    }
}
