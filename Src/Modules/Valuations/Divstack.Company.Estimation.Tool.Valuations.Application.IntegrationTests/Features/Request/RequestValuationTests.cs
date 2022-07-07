namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features.Request;

using Common;
using Inquiries.IntegrationsEvents.External;
using static IntegrationTests.Common.ValuationModuleTester;

public class RequestValuationTests
{
    [Test]
    public async Task Given_RequestValuation_Then_ValuationIsRequestedWithWaitForProposalState()
    {
        var inquiryMadeEvent = new InquiryMadeEvent(Guid.NewGuid());

        await RequestValuation(inquiryMadeEvent);

        var valuation = await GetByInquiryId(inquiryMadeEvent.InquiryId);
        valuation.Should().NotBeNull();
        valuation.Status.Should().BeWaitingForProposal();
    }
}
