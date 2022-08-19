namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations;

using Assertions;
using Common;
using Domain.Valuations;
using Domain.Valuations.Events;
using NUnit.Framework;

public class RequestValuationTests : BaseValuationTest
{
    [Test]
    public void Given_Request_Then_ValuationIsCreated()
    {
        var inquiry = InquiryId.Create();

        var valuation = Valuation.Request(inquiry);

        var @event = GetPublishedEvent<ValuationRequestedDomainEvent>(valuation);
        @event.AssertIsCorrect();
    }
}
