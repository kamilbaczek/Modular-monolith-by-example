namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common;

using System;
using System.Linq;
using System.Threading.Tasks;
using Fakes;
using Inquiries.IntegrationsEvents.External;
using Valuations.Queries.GetAll;
using Valuations.Queries.GetProposalsById;
using Valuations.Queries.GetProposalsById.Dtos;

internal static class ValuationModuleTester
{
    internal static async Task<ValuationListItemDto> GetFirstRequestedValuation()
    {
        var result = await ValuationsTesting.ExecuteQueryAsync(new GetAllValuationsQuery());
        var valuationListItemDto = result.Valuations.First();

        return valuationListItemDto;
    }

    internal static async Task RequestValuation()
    {
        var inquiryMadeEvent = new InquiryMadeEvent(Guid.NewGuid());
        await ValuationsTesting.ConsumeEvent(inquiryMadeEvent);
    }

    internal static async Task SuggestValuationProposal(Guid valuationId)
    {
        var suggestProposalCommand =
            FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuationId);

        await ValuationsTesting.ExecuteCommandAsync(suggestProposalCommand);
    }

    internal static Task<ValuationProposalEntryDto> GetRecentProposal(Guid valuationId)
    {
        // var query = new GetValuationProposalsByIdQuery(valuationId);
        // var valuationProposalsVm =
        //     await ValuationsTesting.ExecuteQueryAsync<ValuationProposalsVm>(query);
        // var valuationProposalEntryDto = valuationProposalsVm.Proposals.First();

        return Task.FromResult(new ValuationProposalEntryDto(Guid.Empty, Guid.Empty, "", "", Decimal.One, DateTime.Now, Guid.Empty, null, ""));
    }
}
