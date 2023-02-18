namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;

using Domain.Inquiries;
using Domain.Inquiries.Clients;
using Domain.Inquiries.Items.Services;
using Dtos;
using MediatR;
using Services.Core.Services.Contracts;
using Shared.DDD.ValueObjects.Emails;
using Shared.DDD.ValueObjects.PhoneNumbers;

internal sealed class MakeInquiryCommandHandler : IRequestHandler<MakeInquiryCommand, Guid>
{
    private readonly IClientCompanyFinder ClientCompanyFinder;
    private readonly IInquiriesRepository _inquiriesRepository;
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IServiceExistingChecker _serviceExistingChecker;
    private readonly IMapper<AskedServiceDto, Service> _serviceMapper;

    public MakeInquiryCommandHandler(IInquiriesRepository inquiriesRepository,
        IServiceExistingChecker serviceExistingChecker,
        IIntegrationEventPublisher integrationEventPublisher,
        IClientCompanyFinder clientCompanyFinder,
        IMapper<AskedServiceDto, Service> serviceMapper)
    {
        _inquiriesRepository = inquiriesRepository;
        _serviceExistingChecker = serviceExistingChecker;
        _integrationEventPublisher = integrationEventPublisher;
        ClientCompanyFinder = clientCompanyFinder;
        _serviceMapper = serviceMapper;
    }

    public async Task<Guid> Handle(MakeInquiryCommand makeInquiryCommand, CancellationToken cancellationToken)
    {
        var email = Email.Of(makeInquiryCommand.Email);
        var phoneNumber = PhoneNumber.Of(makeInquiryCommand.PhoneNumber);
        var clientCompany = await ClientCompanyFinder.FindCompany(email);
        var client = Client.Of(makeInquiryCommand.FirstName, makeInquiryCommand.LastName, email, phoneNumber, clientCompany);
        var services = makeInquiryCommand.AskedServiceDtos
            .Select(service => _serviceMapper.Map(service))
            .ToReadonly();

        var inquiry = await Inquiry.MakeAsync(services, client, _serviceExistingChecker);

        await _inquiriesRepository.PersistAsync(inquiry, cancellationToken);
        await _integrationEventPublisher.PublishAsync(inquiry.DomainEvents, cancellationToken);

        return inquiry.Id.Value;
    }
}
