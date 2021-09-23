using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    internal sealed class RequestValuationCommandHandler : INotificationHandler<InquiryMadeEvent>
    {
        private readonly IDeadlinesConfiguration _deadlinesConfiguration;
        private readonly IIntegrationEventPublisher _integrationEventPublisher;
        private readonly IValuationsRepository _valuationsRepository;

        public RequestValuationCommandHandler(IValuationsRepository valuationsRepository,
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
            await _valuationsRepository.CommitAsync(cancellationToken);
            _integrationEventPublisher.Publish(valuation.DomainEvents);
        }
    }
}