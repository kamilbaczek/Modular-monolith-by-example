using System;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common
{
    internal static class ValuationModuleHelper
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

        internal static async Task<ValuationProposalEntryDto> GetRecentProposal(Guid valuationId)
        {
            var valuationProposalsVm =
                await ValuationsTesting.ExecuteQueryAsync(new GetValuationProposalsByIdQuery(valuationId));
            var valuationProposalEntryDto = valuationProposalsVm.Proposals.First();

            return valuationProposalEntryDto;
        }
    }
}