using System;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Features
{
    using static ValuationsTesting;

    public class RequestValuationTests : ValuationsTestBase
    {
        [Test]
        public async Task Given_RequestValuation_When_CommandIsValid_Then_RequestIsSavedInDatabase()
        {
            var inquiryMadeEvent = new InquiryMadeEvent(Guid.NewGuid());

            await ConsumeEvent(inquiryMadeEvent);

            var result = await ExecuteQueryAsync(new GetAllValuationsQuery());
            result.Valuations.Count().Should().Be(1);
            var valuationListItemDto = result.Valuations.First();
            valuationListItemDto.InquiryId.Should().Be(inquiryMadeEvent.InquiryId);
        }
    }
}
