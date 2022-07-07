namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features;

using Common;
using Valuations.Commands.ApproveProposal;
using static IntegrationTests.Common.ValuationModule;
using static IntegrationTests.Common.ValuationModuleTester;

public class ApproveProposalTests
{
    private static readonly Guid FakeInquiryId = Guid.NewGuid();

    [Test]
    public async Task
        Given_Approve_Then_ValuationStateIsApproved()
    {
        await RequestValuation(FakeInquiryId);
        var valuationBeforeApproval = await GetByInquiryId(FakeInquiryId);
        await SuggestValuationProposal(valuationBeforeApproval.Id);
        var recentProposal = await GetRecentProposal(valuationBeforeApproval.Id);
        var approveCommand = new ApproveProposalCommand(recentProposal.ProposalId, valuationBeforeApproval.Id);

        await ExecuteCommandAsync(approveCommand);

        var valuationAfterApproval = await GetByInquiryId(FakeInquiryId);
        valuationAfterApproval.Status.Should().BeApproved();
    }
}
