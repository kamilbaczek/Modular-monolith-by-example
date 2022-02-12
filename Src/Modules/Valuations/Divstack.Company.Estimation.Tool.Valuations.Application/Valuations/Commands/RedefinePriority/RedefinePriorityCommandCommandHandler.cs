namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.RedefinePriority;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.Get;
using MediatR;

internal sealed class RedefinePriorityCommandCommandHandler : IRequestHandler<RedefinePriorityCommand>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IValuationsRepository _valuationsRepository;
    private readonly IInquiriesModule _inquiryModule;

    public RedefinePriorityCommandCommandHandler(
        IValuationsRepository valuationsRepository,
        IInquiriesModule inquiryModule,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _valuationsRepository = valuationsRepository;
        _inquiryModule = inquiryModule;
        _integrationEventPublisher = integrationEventPublisher;
    }
    public async Task<Unit> Handle(RedefinePriorityCommand command, CancellationToken cancellationToken)
    {
        var valuationId = new ValuationId(command.ValuationId);
        var valuation = await _valuationsRepository.GetAsync(valuationId, cancellationToken);
        if (valuation is null)
            throw new NotFoundException(command.ValuationId, nameof(Valuation));

        var companySize = await GetCompanySize(command.InquiryId);
        valuation.RedefinePriority(companySize);

        await _valuationsRepository.CommitAsync(valuation, cancellationToken);
        await _integrationEventPublisher.PublishAsync(valuation.DomainEvents, cancellationToken);

        return Unit.Value;
    }
    private async Task<int?> GetCompanySize(Guid inquiryId)
    {
        var inquiryQuery = new GetInquiryQuery(inquiryId);
        var inquiryVm = await _inquiryModule.ExecuteQueryAsync(inquiryQuery);
        var companySize = inquiryVm.InquiryDetails.Information.CompanySize;

        return companySize;
    }
}
