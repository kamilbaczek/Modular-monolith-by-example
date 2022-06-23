namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features;

using System;
using System.Threading.Tasks;
using Common;
using Common.Fakes;
using FluentAssertions;
using NUnit.Framework;
using static ValuationsTesting;

public class SuggestValuationProposalTests : ValuationsTestBase
{
    private readonly TimeSpan _oneMinuteInMs = new(60000);

    [Ignore("Wait for  new database mock mechanism")]
    public async Task
        Given_SuggestProposal_When_CommandIsValid_Then_ValuationStateIsChangedToWaitForClientDecision()
    {
        await ValuationModuleTester.RequestValuation();
        var valuationBeforeSuggestProposal = await ValuationModuleTester.GetFirstRequestedValuation();
        var suggestProposalCommand =
            FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuationBeforeSuggestProposal.Id);

        await ExecuteCommandAsync(suggestProposalCommand);

        var valuationAfterSuggestProposal = await ValuationModuleTester.GetFirstRequestedValuation();
        valuationAfterSuggestProposal.Status.Should().Be("WaitForClientDecision");
    }

    [Ignore("Wait for  new database mock mechanism")]
    public async Task
        Given_SuggestProposal_When_CommandIsValid_Then_ProposalIsCorrectlySavedInDatabase()
    {
        await ValuationModuleTester.RequestValuation();
        var valuation = await ValuationModuleTester.GetFirstRequestedValuation();
        var suggestProposalCommand =
            FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuation.Id);

        await ExecuteCommandAsync(suggestProposalCommand);

        var proposal = await ValuationModuleTester.GetRecentProposal(valuation.Id);
        proposal.Should().BeEquivalentTo(suggestProposalCommand, opt => opt.ExcludingMissingMembers());
        proposal.SuggestedBy.Should().Be(CurrentUserId);
        proposal.DecisionDate.Should().BeCloseTo(DateTime.Now, _oneMinuteInMs);
    }
}
