using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Features
{
    using static ValuationsTesting;

    public class ApproveProposalTests : ValuationsTestBase
    {
        [Test]
        public async Task
            Given_SuggestProposal_When_CommandIsValid_Then_ValuationStateIsChangedToApproved()
        {
            await ValuationModuleHelper.RequestValuation();
            var valuationBeforeApproval = await ValuationModuleHelper.GetFirstRequestedValuation();
            await ValuationModuleHelper.SuggestValuationProposal(valuationBeforeApproval.Id);
            var recentProposal = await ValuationModuleHelper.GetRecentProposal(valuationBeforeApproval.Id);

            var approveCommand = new ApproveProposalCommand
            {
                ProposalId = recentProposal.Id,
                ValuationId = valuationBeforeApproval.Id
            };

            await ExecuteCommandAsync(approveCommand);

            var valuationAfterApproval = await ValuationModuleHelper.GetFirstRequestedValuation();
            valuationAfterApproval.Status.Should().Be("Approved");
        }
    }
}
