using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations
{
    public class RequestValuationTests : BaseValuationTest
    {
        [Test]
        public async Task Given_Request_When_ServicesExists_Then_ValuationIsCreated()
        {
            SetupServiceExistingChecker();
            var servicesIds = new List<ServiceId>
            {
                new(Guid.NewGuid()),
                new(Guid.NewGuid()),
            };
            var email = Email.Of("test@mail.com");
            var client = Client.Of(email, "firstname", "lastname");

            var valuation = await Valuation.RequestAsync(servicesIds, client, ServiceExistingCheckerMock.Object);

            var @event = GetPublishedEvent<ValuationRequestedEvent>(valuation);
            @event.AssertIsCorrect(servicesIds, email);
        }

        [Test]
        public async Task Given_Request_When_ServicesAreNotExists_Then_ValuationIsNotCreated()
        {
            SetupServiceExistingChecker(false);
            var servicesIds = new List<ServiceId>
            {
                new(Guid.NewGuid()),
                new(Guid.NewGuid()),
            };
            var email = Email.Of("test@mail.com");
            var client = Client.Of(email, "firstname", "lastname");
            Func<Task> valuationRequestAsync = async () =>
            {
                await Valuation.RequestAsync(servicesIds, client, ServiceExistingCheckerMock.Object);
            };

            await valuationRequestAsync.Should().ThrowAsync<InvalidServicesException>();
        }
    }
}
