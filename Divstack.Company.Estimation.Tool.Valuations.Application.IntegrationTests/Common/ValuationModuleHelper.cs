using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;
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

        internal static async Task<RequestValuationCommand> RequestValuation()
        {
            var serviceId = await ValuationsSeeders.CreateService();
            var requestCommand = FakeValuationsRequests.GenerateFakeRequestValuationCommand(new List<Guid> {serviceId});
            await ValuationsTesting.ExecuteCommandAsync(requestCommand);

            return requestCommand;
        }

        internal static async Task<SuggestProposalCommand> SuggestValuationProposal(Guid valuationId)
        {
            var suggestProposalCommand =
                FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuationId);

            await ValuationsTesting.ExecuteCommandAsync(suggestProposalCommand);

            return suggestProposalCommand;
        }

        internal static async Task<ValuationProposalEntryDto> GetRecentProposal(Guid valuationId)
        {
            var valuationProposalsVm = await ValuationsTesting.ExecuteQueryAsync(new GetValuationProposalsByIdQuery(valuationId));
            var valuationProposalEntryDto = valuationProposalsVm.Proposals.First();

            return valuationProposalEntryDto;
        }
    }
}
