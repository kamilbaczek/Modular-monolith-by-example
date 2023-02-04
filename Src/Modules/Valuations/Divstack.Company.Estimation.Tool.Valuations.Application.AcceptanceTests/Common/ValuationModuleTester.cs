namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common;

using AcceptanceTests;
using Application.Common.Interfaces;
using Domain.Valuations;
using Inquiries.IntegrationsEvents.External;
using NServiceBus.Testing;
using Valuations.Commands.Request;
using Valuations.Queries.GetAll;
using Valuations.Queries.GetProposalsById;
using Valuations.Queries.GetProposalsById.Dtos;
using static ValuationModule;

internal static class ValuationModuleTester
{
    internal static async Task RequestValuation(InquiryMadeEvent inquiryMadeEvent)
    {
        using var scope = TestEngine.ServiceScopeFactory.CreateScope();

        var eventPublisher = Mock.Of<IIntegrationEventPublisher>();
        var valuationsRepository = scope.ServiceProvider.GetRequiredService<IValuationsRepository>();

        var valuationEventHandler = new RequestValuationEventHandler(valuationsRepository, eventPublisher);
        await valuationEventHandler.Handle(inquiryMadeEvent, new TestableMessageHandlerContext());
    }

    internal static async Task<ValuationListItemDto> GetByInquiryId(Guid inquiryId)
    {
        var query = GetAllValuationsQuery.Create();
        var result = await ExecuteQueryAsync(query);
        var valuationListItemDto = result.Valuations.FirstOrDefault(valuation => valuation.InquiryId == inquiryId);

        return valuationListItemDto!;
    }

    internal static async Task<ValuationProposalEntryDto> GetRecentProposal(Guid valuationId)
    {
        var query = new GetValuationProposalsByIdQuery(valuationId);
        var valuationProposalsVm =
            await ExecuteQueryAsync(query);
        var valuationProposalEntryDto = valuationProposalsVm.Proposals.First();

        return valuationProposalEntryDto;
    }
}
