namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common;

using Application.Common.Interfaces;
using Domain.Valuations;
using Features.Proposals.Fakes;
using Inquiries.IntegrationsEvents.External;
using Moq;
using NServiceBus.Testing;
using Valuations.Commands.ApproveProposal;
using Valuations.Commands.Request;
using Valuations.Queries.GetAll;
using Valuations.Queries.GetProposalsById;
using Valuations.Queries.GetProposalsById.Dtos;
using static ValuationModule;

internal static class ValuationModuleTester
{
    internal static async Task RequestValuation(InquiryMadeEvent inquiryMadeEvent)
    {
        using var scope = TestEngine.ServiceScopeFactory?.CreateScope();

        var eventPublisher = Mock.Of<IIntegrationEventPublisher>();
        var valuationsRepository = scope?.ServiceProvider.GetRequiredService<IValuationsRepository>();

        var valuationEventHandler = new RequestValuationEventHandler(valuationsRepository!, eventPublisher);
        await valuationEventHandler.Handle(inquiryMadeEvent, new TestableMessageHandlerContext());
    }

    internal static async Task<ValuationListItemDto> GetByInquiryId(Guid inquiryId)
    {
        var query = GetAllValuationsQuery.Create();
        var result = await ExecuteQueryAsync(query);
        var valuationListItemDto = result.Valuations.FirstOrDefault(valuation => valuation.InquiryId == inquiryId);

        return valuationListItemDto;
    }

    internal static async Task RequestValuation(Guid inquiryId)
    {
        var inquiryMadeEvent = new InquiryMadeEvent(inquiryId);
        await RequestValuation(inquiryMadeEvent);
    }

    internal static async Task SuggestValuationProposal(Guid valuationId)
    {
        var suggestProposalCommand =
            ValuationSuggestionFaker.Create(valuationId);

        await ExecuteCommandAsync(suggestProposalCommand);
    }

    internal static async Task ApproveValuationProposal(Guid valuationId, Guid proposalId)
    {
        var approveProposal = new ApproveProposalCommand(proposalId, valuationId);
        await ExecuteCommandAsync(approveProposal);
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
