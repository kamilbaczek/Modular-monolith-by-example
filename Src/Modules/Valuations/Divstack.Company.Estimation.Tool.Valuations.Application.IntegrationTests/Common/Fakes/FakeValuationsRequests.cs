using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;
using Faker;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Tests.Common.Fakes
{
    internal static class FakeValuationsRequests
    {
        internal static RequestValuationCommand GenerateFakeRequestValuationCommand(List<Guid> servicesId) => new()
        {
            FirstName = Name.First(),
            LastName = Name.Last(),
            Email = Internet.Email(),
            ServicesIds = servicesId
        };
    }
}