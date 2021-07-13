using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Moq;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common
{
    public abstract class BaseValuationTest : BaseTest
    {
        protected const string FakeRejectReason = "test";
        protected readonly Mock<IServiceExistingChecker> ServiceExistingCheckerMock;

        protected BaseValuationTest()
        {
            ServiceExistingCheckerMock = new Mock<IServiceExistingChecker>();
            ServiceExistingCheckerMock.Setup(serviceExistingChecker =>
                serviceExistingChecker.ExistAsync(It.IsAny<List<Guid>>())).ReturnsAsync(true);
        }


        protected void SetupServiceExistingChecker(bool areServicesExists = true)
        {
            ServiceExistingCheckerMock
                .Setup(x => x.ExistAsync(It.IsAny<List<Guid>>()))
                .ReturnsAsync(areServicesExists);
        }

        protected static ProposalId SuggestFakeProposal(EmployeeId employee, Valuation valuation)
        {
            var money = Money.Of(30, "USD");
            return SuggestFakeProposal(employee, valuation, money);
        }

        protected static ProposalId SuggestFakeProposal(EmployeeId employee, Valuation valuation, Money money)
        {
            valuation.SuggestProposal(money, "test", employee);
            var @event = GetPublishedEvent<ProposalSuggestedEvent>(valuation);

            return @event.ProposalId;
        }

        protected async Task<Valuation> RequestFakeValuation(Email email)
        {
            var productsIds = new List<ServiceId>
            {
                new(Guid.NewGuid()),
                new(Guid.NewGuid()),
            };
            var client = Client.Of(email, "firstname", "lastname");
            return await Valuation.RequestAsync(productsIds, client, ServiceExistingCheckerMock.Object);
        }

        protected async Task<Valuation> RequestFakeValuation()
        {
            var email = Email.Of("test@mail.com");

            return await RequestFakeValuation(email);
        }
    }
}