namespace Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Commands.Define;

using Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Domain;
using Domain.Deadlines;

internal sealed class DefinePrioritiesEventHandler : IHandleMessages<ValuationRequested>
{
    private readonly IDeadlinesConfiguration _deadlinesConfiguration;
    private readonly IInquiriesModule _inquiryModule;
    private readonly IPrioritiesRepository _prioritiesRepository;

    public DefinePrioritiesEventHandler(IPrioritiesRepository prioritiesRepository,
        IDeadlinesConfiguration deadlinesConfiguration,
        IInquiriesModule inquiryModule)
    {
        _prioritiesRepository = prioritiesRepository;
        _deadlinesConfiguration = deadlinesConfiguration;
        _inquiryModule = inquiryModule;
    }
    
    public async Task Handle(ValuationRequested message, IMessageHandlerContext context)
    {
        var deadline = Deadline.Create(_deadlinesConfiguration);
        var companySize = await GetCompanySizeAsync(message.InquiryId);
        var valuationId = ValuationId.Create(message.ValuationId);
        var inquiryId = InquiryId.Create(message.InquiryId);

        var priority = Priority.Define(valuationId, inquiryId, companySize, deadline);

        await _prioritiesRepository.AddAsync(priority, context.CancellationToken);
    }

    private async Task<int?> GetCompanySizeAsync(Guid inquiryId)
    {
        var inquiryQuery = new GetInquiryClientQuery(inquiryId);
        var client = await _inquiryModule.ExecuteQueryAsync(inquiryQuery);

        return client.CompanySize;
    }
}
