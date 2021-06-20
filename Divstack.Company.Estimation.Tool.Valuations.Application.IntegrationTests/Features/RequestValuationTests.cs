using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common;
using Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes;
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
            var serviceId = await ValuationsSeeders.CreateService();
            var requestCommand = FakeValuationsRequests.GenerateFakeRequestValuationCommand(new List<Guid>{serviceId});

            await ExecuteCommandAsync(requestCommand);

           var result = await ExecuteQueryAsync(new GetAllValuationsQuery());
           result.Valuations.Count().Should().Be(1);
           var valuationListItemDto = result.Valuations.First();
           valuationListItemDto.Should().BeEquivalentTo(requestCommand,
               options => options.ExcludingMissingMembers());
        }
    }
}
