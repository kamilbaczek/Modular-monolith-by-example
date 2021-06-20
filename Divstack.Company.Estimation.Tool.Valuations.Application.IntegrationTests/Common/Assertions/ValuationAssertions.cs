using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using FluentAssertions;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests
{
    internal static class ValuationAssertions
    {
        internal static void AssertEqual(this ValuationListItemDto valuationListItemDto,
            string firstName,
            string lastName,
            List<Guid> servicesIds)
        {
            valuationListItemDto.FirstName.Should().Be(firstName);
            valuationListItemDto.LastName.Should().Be(lastName);
            valuationListItemDto.CompletedBy.Should().Be(null);
            valuationListItemDto.Should().BeEquivalentTo(servicesIds);
            Convert.ToDateTime(valuationListItemDto.RequestedDate).Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
