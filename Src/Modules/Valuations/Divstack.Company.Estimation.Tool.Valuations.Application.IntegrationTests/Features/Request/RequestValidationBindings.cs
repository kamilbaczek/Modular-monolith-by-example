namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Request;

using Common;
using Inquiries.IntegrationsEvents.External;
using TechTalk.SpecFlow;
using static IntegrationTests.Common.ValuationModuleTester;

[Binding]
public class RequestValidationBindings
{
    [Then(@"Valuation with inquiry '(.*)' is displayed in the valuations list with wait for proposal state")]
    public async Task ThenValuationWithInquiryIsDisplayedInTheValuationsListWithWaitForProposalState(string inquiryIdAsString)
    {
        var inquiryId = Guid.Parse(inquiryIdAsString);
        var valuation = await GetByInquiryId(inquiryId);
        valuation.Should().NotBeNull();
        valuation.Status.Should().BeWaitingForProposal();
    }

    [Given(@"Request valuation for inquiry '(.*)'")]
    public async Task GivenRequestValuationForInquiry(string p0)
    {
        var inquiryId = Guid.Parse(p0);
        var inquiryMadeEvent = new InquiryMadeEvent(inquiryId);
        await RequestValuation(inquiryMadeEvent);
    }
}
