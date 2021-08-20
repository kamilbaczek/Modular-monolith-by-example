using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Clients;
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
            var client = FakeClient.CreateClientWithCompany(email);
            var deadline = FakeDeadline.CreateDeadline();

            var valuation = await Valuation.RequestAsync(servicesIds, client, deadline, ServiceExistingCheckerMock.Object);

            var @event = GetPublishedEvent<ValuationRequestedDomainEvent>(valuation);
            @event.AssertIsCorrect(servicesIds, email);
        }

        private static object[] _datesTestCases =
        {
            new object[] { new DateTime(1998, 2, 3), 3, new DateTime(1998, 2, 6)},
            new object[] { new DateTime(2021, 6, 25), 2, new DateTime(2021, 6, 27)},
        };
        [Test, TestCaseSource(nameof(_datesTestCases))]
        public async Task Given_Request_Then_DeadlineIsFixed(DateTime nowDate, int daysToDeadlineFromNow, DateTime expectedDeadline)
        {
            SystemTime.SetDateTime(nowDate);
            SetupServiceExistingChecker();
            var servicesIds = new List<ServiceId>
            {
                new(Guid.NewGuid()),
            };
            var email = Email.Of("test@mail.com");
            var client = FakeClient.CreateClientWithCompany(email);
            var deadline = FakeDeadline.CreateDeadline(daysToDeadlineFromNow);

            var valuation = await Valuation.RequestAsync(servicesIds, client, deadline, ServiceExistingCheckerMock.Object);

            var @event = GetPublishedEvent<ValuationDeadlineFixedDomainEvent>(valuation);
            @event.DeadlineDate.Should().Be(expectedDeadline);
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
            var deadline = FakeDeadline.CreateDeadline();
            var email = Email.Of("test@mail.com");
            var clientCompany = ClientCompany.Of("10-15", "Test Company");
            var client = Client.Of(email, "firstname", "lastname", clientCompany);
            Func<Task> valuationRequestAsync = async () =>
            {
                await Valuation.RequestAsync(servicesIds, client, deadline, ServiceExistingCheckerMock.Object);
            };

            await valuationRequestAsync.Should().ThrowAsync<InvalidServicesException>();
        }
    }
}
