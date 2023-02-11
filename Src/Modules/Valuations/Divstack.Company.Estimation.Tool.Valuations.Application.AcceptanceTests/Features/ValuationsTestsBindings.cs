namespace Divstack.Company.Estimation.Tool.Valuations.Application.AcceptanceTests.Features;

using Common.Fakes;
using Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;
using TechTalk.SpecFlow;
using static AcceptanceTests.Common.ValuationModule;
using static AcceptanceTests.Common.ValuationModuleTester;

[Binding]
public class ValuationsTestsBindings
{
    [Given(@"Request valuation for inquiry '(.*)'")]
    public static async Task GivenRequestValuationForInquiry(Guid inquiryId)
    {
        var inquiryMadeEvent = new InquiryMadeEvent(inquiryId);
        await RequestValuation(inquiryMadeEvent);
    }

    [Given(@"Employee suggest valuation proposal with price '(.*)' '(.*)'")]
    public static async Task GivenEmployeeSuggestValuationProposalWithPrice(string value, string currency, Guid inquiryId)
    {
        var valuation = await GetByInquiryId(inquiryId);
        var money = decimal.Parse(value);
        var suggestProposalCommand =
            ValuationSuggestionFaker.Create(valuation.Id, money, currency);
        await ExecuteCommandAsync(suggestProposalCommand);
    }


    [Then(@"Valuation with inquiry '(.*)' is displayed in the valuations list with '(.*)' state")]
    public static async Task ThenValuationWithInquiryIsDisplayedInTheValuationsListWithState(Guid inquiryId, string state)
    {
        var valuation = await GetByInquiryId(inquiryId);
        valuation.Should().NotBeNull();
        valuation.Status.Should().Be(state);
    }
}
