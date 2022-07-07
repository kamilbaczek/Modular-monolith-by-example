namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Proposals;

using Common;
using Fakes;
using FluentAssertions;
using IntegrationTests.Common.Engine.Mocks;
using NUnit.Framework;
using static IntegrationTests.Common.ValuationModule;
using static IntegrationTests.Common.ValuationModuleTester;

public class SuggestValuationProposalTests
{
    private static readonly Guid FakeInquiryId = Guid.NewGuid();

    [Test]
    public async Task
        Given_SuggestProposal_When_CommandIsValid_Then_ValuationStateIsChangedToWaitForClientDecision()
    {
        await RequestValuation(FakeInquiryId);
        var valuationBeforeSuggestProposal = await GetByInquiryId(FakeInquiryId);
        var suggestProposalCommand =
            ValuationSuggestionFaker.Create(valuationBeforeSuggestProposal.Id);

        await ExecuteCommandAsync(suggestProposalCommand);

        var valuationAfterSuggestProposal = await GetByInquiryId(FakeInquiryId);
        valuationAfterSuggestProposal.Status.Should().BeWaitForClientDecision();
        valuationAfterSuggestProposal.CompletedBy.Should().BeNull();
    }

    [Test]
    public async Task
        Given_SuggestProposal_Then_ProposalIsSuggested()
    {
        await RequestValuation(FakeInquiryId);
        var valuation = await GetByInquiryId(FakeInquiryId);
        var suggestProposalCommand =
            ValuationSuggestionFaker.Create(valuation.Id);

        await ExecuteCommandAsync(suggestProposalCommand);

        var proposal = await GetRecentProposal(valuation.Id);
        proposal.Should().BeEquivalentTo(suggestProposalCommand, opt => opt.ExcludingMissingMembers());
        proposal.SuggestedBy.Should().Be(CurrentUserMock.CurrentUserId);
    }
}
