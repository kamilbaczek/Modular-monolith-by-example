using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Clients;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make
{
    internal sealed class MakeInquiryCommandHandler : IRequestHandler<MakeInquiryCommand>
    {
        private readonly IIntegrationEventPublisher _integrationEventPublisher;
        private readonly IClientCompanyFinder _clientCompanyFinder;
        private readonly IServiceExistingChecker _serviceExistingChecker;
        private readonly IInquiriesRepository _inquiriesRepository;

        public MakeInquiryCommandHandler(IInquiriesRepository inquiriesRepository,
            IServiceExistingChecker serviceExistingChecker,
            IIntegrationEventPublisher integrationEventPublisher,
            IClientCompanyFinder clientCompanyFinder)
        {
            _inquiriesRepository = inquiriesRepository;
            _serviceExistingChecker = serviceExistingChecker;
            _integrationEventPublisher = integrationEventPublisher;
            _clientCompanyFinder = clientCompanyFinder;
        }

        public async Task<Unit> Handle(MakeInquiryCommand requestValuation, CancellationToken cancellationToken)
        {
            var email = Email.Of(requestValuation.Email);
            var clientCompany = await _clientCompanyFinder.FindCompany(email);
            var client = Client.Of(email, requestValuation.FirstName, requestValuation.LastName, clientCompany);
            var serviceIds = requestValuation.ServicesIds
                .Select(id => new ServiceId(id))
                .ToList();

            var inquiry = await Inquiry.MakeAsync(serviceIds, client, _serviceExistingChecker);
            await _inquiriesRepository.AddAsync(inquiry, cancellationToken);
            await _inquiriesRepository.CommitAsync(cancellationToken);
            _integrationEventPublisher.Publish(inquiry.DomainEvents);

            return Unit.Value;
        }
    }
}
