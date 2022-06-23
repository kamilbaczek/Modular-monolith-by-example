namespace Divstack.Company.Estimation.Tool.Valuations.Application.IntegrationTests.Features;

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Inquiries.IntegrationsEvents.External;
using NUnit.Framework;
using Valuations.Queries.GetAll;
using static ValuationsTesting;

public class RequestValuationTests : ValuationsTestBase
{
    [Ignore("Wait for  new database mock mechanism")]
    public async Task Given_RequestValuation_When_CommandIsValid_Then_RequestIsSavedInDatabase()
    {
        var inquiryMadeEvent = new InquiryMadeEvent(Guid.NewGuid());
        await ConsumeEvent(inquiryMadeEvent);

        var result = await ExecuteQueryAsync(new GetAllValuationsQuery());

        result.Valuations.Count.Should().Be(1);
        var valuationListItemDto = result.Valuations.First();
        valuationListItemDto.InquiryId.Should().Be(inquiryMadeEvent.InquiryId);
    }
}
