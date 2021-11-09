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
            await ValuationModuleTester.RequestValuation();
            var valuationBeforeApproval = await ValuationModuleTester.GetFirstRequestedValuation();
            await ValuationModuleTester.SuggestValuationProposal(valuationBeforeApproval.Id);
            var recentProposal = await ValuationModuleTester.GetRecentProposal(valuationBeforeApproval.Id);
            var approveCommand = new ApproveProposalCommand
            {
                ProposalId = recentProposal.Id,
                ValuationId = valuationBeforeApproval.Id
            };

            await ExecuteCommandAsync(approveCommand);

            var valuationAfterApproval = await ValuationModuleTester.GetFirstRequestedValuation();
            valuationAfterApproval.Status.Should().Be("Approved");
        }
    }
}