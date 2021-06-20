using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes
{
    internal static class FakeValuationsRequests
    {
        internal static RequestValuationCommand GenerateFakeRequestValuationCommand(List<Guid> servicesId) => new()
        {
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            Email = Faker.Internet.Email(),
            ServicesIds = servicesId
        };
    }
}
