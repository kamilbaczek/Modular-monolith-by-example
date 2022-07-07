namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Proposals.Suggest;

using Common;
using Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Common.Engine.Mocks;
using Fakes;
using static IntegrationTests.Common.ValuationModule;
using static IntegrationTests.Common.ValuationModuleTester;

public class SuggestValuationProposalTests
{
    // private static readonly Guid FakeInquiryId = Guid.NewGuid();
    //
    // [Test]
    // public async Task
    //     Given_SuggestProposal_When_CommandIsValid_Then_ValuationStateIsChangedToWaitForClientDecision()
    // {
    //     await RequestValuation(FakeInquiryId);
    //     var valuationBeforeSuggestProposal = await GetByInquiryId(FakeInquiryId);
    //     var suggestProposalCommand =
    //         ValuationSuggestionFaker.Create(valuationBeforeSuggestProposal.Id);
    //
    //     await ExecuteCommandAsync(suggestProposalCommand);
    //
    //     var valuationAfterSuggestProposal = await GetByInquiryId(FakeInquiryId);
    //     valuationAfterSuggestProposal.Status.Should().BeWaitForClientDecision();
    //     valuationAfterSuggestProposal.CompletedBy.Should().BeNull();
    // }

    // [Test]
    // public async Task
    //     Given_SuggestProposal_Then_ProposalIsSuggested()
    // {
    //     await RequestValuation(FakeInquiryId);
    //     var valuation = await GetByInquiryId(FakeInquiryId);
    //
    //
    //     await ExecuteCommandAsync(suggestProposalCommand);
    //
    //     var proposal = await GetRecentProposal(valuation.Id);
    //     proposal.Should().BeEquivalentTo(suggestProposalCommand, opt => opt.ExcludingMissingMembers());
    //     proposal.SuggestedBy.Should().Be(CurrentUserMock.CurrentUserId);
    // }
}
