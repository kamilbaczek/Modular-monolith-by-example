using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Features;

using static ValuationsTesting;

public class SuggestValuationProposalTests : ValuationsTestBase
{
    private readonly TimeSpan OneMinuteInMs = new(60000);

    [Test]
    public async Task
        Given_SuggestProposal_When_CommandIsValid_Then_ValuationStateIsChangedToWaitForClientDecision()
    {
        await ValuationModuleTester.RequestValuation();
        var valuationBeforeSuggestProposal = await ValuationModuleTester.GetFirstRequestedValuation();
        var suggestProposalCommand =
            FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuationBeforeSuggestProposal.ValuationId);

        await ExecuteCommandAsync(suggestProposalCommand);

        var valuationAfterSuggestProposal = await ValuationModuleTester.GetFirstRequestedValuation();
        valuationAfterSuggestProposal.Status.Should().Be("WaitForClientDecision");
    }

    [Test]
    public async Task
        Given_SuggestProposal_When_CommandIsValid_Then_ProposalIsCorrectlySavedInDatabase()
    {
        await ValuationModuleTester.RequestValuation();
        var valuation = await ValuationModuleTester.GetFirstRequestedValuation();
        var suggestProposalCommand =
            FakeValuationSuggestion.GenerateFakeSuggestProposalCommand(valuation.ValuationId);

        await ExecuteCommandAsync(suggestProposalCommand);

        var proposal = await ValuationModuleTester.GetRecentProposal(valuation.ValuationId);
        proposal.Should().BeEquivalentTo(suggestProposalCommand, opt => opt.ExcludingMissingMembers());
        proposal.SuggestedBy.Should().Be(CurrentUserId);
        proposal.DecisionDate.Should().BeCloseTo(DateTime.Now, OneMinuteInMs);
    }
}
