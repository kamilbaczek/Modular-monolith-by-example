namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Proposals;

using Common.Fakes;
using TechTalk.SpecFlow;
using static IntegrationTests.Common.ValuationModule;
using static IntegrationTests.Common.ValuationModuleTester;

[Binding]
public class ProposalsTestsBindings
{
    [Then(@"Proposal is suggested for valuation with inquiryId '(.*)' with price '(.*)' '(.*)'")]
    public static async Task ThenProposalIsSuggestedForValuationWithInquiryIdWithPrice(Guid inquiryId, decimal value, string currency)
    {
        var valuation = await GetByInquiryId(inquiryId);
        var proposal = await GetRecentProposal(valuation.Id);
        proposal.Currency.Should().Be(currency);
        proposal.Value.Should().Be(value);
    }
    
    [Given(@"Employee suggest valuation for inquiry '(.*)' proposal with price '(.*)' '(.*)'")]
    public static async Task GivenEmployeeSuggestValuationForInquiryProposalWithPrice(Guid inquiryId, decimal value, string currency)
    {
        var valuation = await GetByInquiryId(inquiryId);
        var suggestProposalCommand =
            ValuationSuggestionFaker.Create(valuation.Id, value, currency);
        await ExecuteCommandAsync(suggestProposalCommand);
    }
    
    [Given(@"Client approve valuation price for inquiry '(.*)'")]
    public static async Task GivenClientApproveValuationPriceForInquiry(Guid inquiryId)
    {
        var valuation = await GetByInquiryId(inquiryId);
        var proposal = await GetRecentProposal(valuation.Id);
        var approveCommand = ValuationApproveFaker.Create(valuation.Id, proposal.ProposalId);
  
        await ExecuteCommandAsync(approveCommand);
    }
    
    [Then(@"Valuation price proposal is '(.*)' for inquiry '(.*)'")]
    public static async Task ThenValuationPriceProposalIsForInquiry(string state, Guid inquiryId)
    {
        var valuation = await GetByInquiryId(inquiryId);
        valuation.Status.Should().Be(state);
        var proposal = await GetRecentProposal(valuation.Id);
        proposal.Decision.Should().Be(state);
    }
}
