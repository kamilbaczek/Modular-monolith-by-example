namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;

using System.Threading;
using System.Threading.Tasks;
using Domain.Valuations;
using Domain.Valuations.Deadlines;
using Inquiries.IntegrationsEvents.External;
using Interfaces;
using MediatR;

internal sealed class RequestValuationEventHandler : INotificationHandler<InquiryMadeEvent>
{
    private readonly IDeadlinesConfiguration _deadlinesConfiguration;
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IValuationsRepository _valuationsRepository;

    public RequestValuationEventHandler(IValuationsRepository valuationsRepository,
        IIntegrationEventPublisher integrationEventPublisher,
        IDeadlinesConfiguration deadlinesConfiguration)
    {
        _valuationsRepository = valuationsRepository;
        _integrationEventPublisher = integrationEventPublisher;
        _deadlinesConfiguration = deadlinesConfiguration;
    }

    public async Task Handle(InquiryMadeEvent notification, CancellationToken cancellationToken)
    {
        var deadline = Deadline.Create(_deadlinesConfiguration);
        var inquiryId = new InquiryId(notification.InquiryId);
        var valuation = Valuation.Request(inquiryId, deadline);
        await _valuationsRepository.AddAsync(valuation, cancellationToken);
        _integrationEventPublisher.Publish(valuation.DomainEvents);
    }
}
