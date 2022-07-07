namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features;

using Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;
using Proposals.Suggest.Fakes;
using TechTalk.SpecFlow;
using static IntegrationTests.Common.ValuationModule;
using static IntegrationTests.Common.ValuationModuleTester;

[Binding]
public class ValuationsTestsBindings
{
    [Given(@"Request valuation for inquiry '(.*)'")]
    public async Task GivenRequestValuationForInquiry(Guid inquiryId)
    {
        var inquiryMadeEvent = new InquiryMadeEvent(inquiryId);
        await RequestValuation(inquiryMadeEvent);
    }

    [Given(@"Employee suggest valuation proposal with price '(.*)' '(.*)'")]
    public async Task GivenEmployeeSuggestValuationProposalWithPrice(string value, string currency, Guid inquiryId)
    {
        var valuation = await GetByInquiryId(inquiryId);
        var money = decimal.Parse(value);
        var suggestProposalCommand =
            ValuationSuggestionFaker.Create(valuation.Id, money, currency);
        await ExecuteCommandAsync(suggestProposalCommand);
    }


    [Then(@"Valuation with inquiry '(.*)' is displayed in the valuations list with '(.*)' state")]
    public async Task ThenValuationWithInquiryIsDisplayedInTheValuationsListWithState(Guid inquiryId, string state)
    {
        var valuation = await GetByInquiryId(inquiryId);
        valuation.Should().NotBeNull();
        valuation.Status.Should().Be(state);
    }

    [Then(@"Proposal is suggested for valuation with inquiryId '(.*)' with price '(.*)' '(.*)'")]
    public async Task ThenProposalIsSuggestedForValuationWithInquiryIdWithPrice(Guid inquiryId, decimal value, string currency)
    {
        var valuation = await GetByInquiryId(inquiryId);
        var proposal = await GetRecentProposal(valuation.Id);
        proposal.Currency.Should().Be(currency);
        proposal.Value.Should().Be(value);

    }
    [Given(@"Employee suggest valuation for inquiry '(.*)' proposal with price '(.*)' '(.*)'")]
    public async Task GivenEmployeeSuggestValuationForInquiryProposalWithPrice(Guid inquiryId, decimal value, string currency)
    {
        var valuation = await GetByInquiryId(inquiryId);
        var suggestProposalCommand =
            ValuationSuggestionFaker.Create(valuation.Id, value, currency);
        await ExecuteCommandAsync(suggestProposalCommand);
    }
}
