namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;

using Inquiries.IntegrationsEvents.External;
using MediatR;

internal sealed class RequestValuationEventHandler : INotificationHandler<InquiryMadeEvent>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IValuationsRepository _valuationsRepository;

    public RequestValuationEventHandler(IValuationsRepository valuationsRepository,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _valuationsRepository = valuationsRepository;
        _integrationEventPublisher = integrationEventPublisher;
    }

    public async Task Handle(InquiryMadeEvent notification, CancellationToken cancellationToken)
    {
        var inquiryId = new InquiryId(notification.InquiryId);
        var valuation = Valuation.Request(inquiryId);
        await _valuationsRepository.AddAsync(valuation, cancellationToken);
        await _integrationEventPublisher.PublishAsync(valuation.DomainEvents, cancellationToken);
    }
}
