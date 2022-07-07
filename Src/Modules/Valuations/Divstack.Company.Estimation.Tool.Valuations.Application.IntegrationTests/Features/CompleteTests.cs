namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features;

using Common;
using Valuations.Commands.Complete;
using static IntegrationTests.Common.ValuationModule;
using static IntegrationTests.Common.ValuationModuleTester;

public class CompleteValuationTests
{
    private static readonly Guid FakeInquiryId = Guid.NewGuid();

    [Test]
    public async Task Given_Complete_Then_ValuationHasCompletedState()
    {
        await RequestValuation(FakeInquiryId);
        var valuation = await GetByInquiryId(FakeInquiryId);
        await SuggestValuationProposal(valuation.Id);
        var proposal = await GetRecentProposal(valuation.Id);
        await ApproveValuationProposal(valuation.Id, proposal.ProposalId);
        var command = new CompleteCommand(valuation.Id);

        await ExecuteCommandAsync(command);

        valuation.Status.Should().BeCompleted();
    }
}
