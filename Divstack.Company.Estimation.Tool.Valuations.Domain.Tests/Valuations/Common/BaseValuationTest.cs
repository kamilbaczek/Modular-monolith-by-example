using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Moq;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common
{
    public abstract class BaseValuationTest : BaseTest
    {
        protected readonly Mock<IServiceExistingChecker> _serviceExistingCheckerMock;

        protected BaseValuationTest()
        {
            _serviceExistingCheckerMock = new Mock<IServiceExistingChecker>();
            _serviceExistingCheckerMock.Setup(serviceExistingChecker =>
                serviceExistingChecker.ExistAsync(It.IsAny<List<Guid>>())).ReturnsAsync(true);
        }

        protected const string FakeRejectReason = "test";


        protected void SetupServiceExistingChecker(bool areServicesExists = true)
        {
            _serviceExistingCheckerMock
                .Setup(x => x.ExistAsync(It.IsAny<List<Guid>>()))
                .ReturnsAsync(areServicesExists);
        }
        protected static ProposalId SuggestFakeProposal(Valuation valuation)
        {
            var money = Money.Of(30, "USD");
            return SuggestFakeProposal(valuation, money);
        }

        protected static ProposalId SuggestFakeProposal(Valuation valuation, Money money)
        {
            var employee = new EmployeeId(Guid.NewGuid());
            valuation.SuggestProposal(money, "test", employee);
            var @event = GetPublishedEvent<ProposalSuggestedEvent>(valuation);

            return @event.ProposalId;
        }

        protected async Task<Valuation> RequestFakeValuation(Email email)
        {
            var productsIds = new List<ServiceId>
            {
                new ServiceId(Guid.NewGuid()),
                new ServiceId(Guid.NewGuid()),
            };
            var client = Client.Of(email, "firstname", "lastname");
            return await Valuation.RequestAsync(productsIds, client, _serviceExistingCheckerMock.Object);
        }

        protected async Task<Valuation> RequestFakeValuation()
        {
            var email = Email.Of("test@mail.com");

            return await RequestFakeValuation(email);
        }
    }
}
