namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;

using Domain.Valuations.States;
using Inquiries.IntegrationsEvents.External;
using NServiceBus;

public sealed class RequestValuationEventHandler : IHandleMessages<InquiryMadeEvent>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IValuationsRepository _valuationsRepository;

    public RequestValuationEventHandler(IValuationsRepository valuationsRepository,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _valuationsRepository = valuationsRepository;
        _integrationEventPublisher = integrationEventPublisher;
    }

    public async Task Handle(InquiryMadeEvent @event, IMessageHandlerContext context)
    {
        var inquiryId = InquiryId.Create(@event.InquiryId);
        var valuation = ValuationRequested.Request(inquiryId);
        await _valuationsRepository.AddAsync(valuation, context.CancellationToken);
        await _integrationEventPublisher.PublishAsync(valuation.DomainEvents, context.CancellationToken);
    }
}
