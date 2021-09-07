using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Moq;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common
{
    public abstract class BaseValuationTest : BaseTest
    {
        protected const string FakeRejectReason = "test";

        protected static ProposalId SuggestFakeProposal(EmployeeId employee, Valuation valuation)
        {
            var money = Money.Of(30, "USD");
            return SuggestFakeProposal(employee, valuation, money);
        }

        protected static ProposalId SuggestFakeProposal(EmployeeId employee, Valuation valuation, Money money)
        {
            valuation.SuggestProposal(money, "test", employee);
            var @event = GetPublishedEvent<ProposalSuggestedDomainEvent>(valuation);

            return @event.ProposalId;
        }

        protected async Task<Valuation> RequestFakeValuation(Email email)
        {
            var productsIds = new List<ServiceId>
            {
                new(Guid.NewGuid()),
                new(Guid.NewGuid()),
            };
            var deadline = FakeDeadline.CreateDeadline();
            var client = FakeClient.CreateClientWithCompany(email);

            return await Valuation.Request(productsIds, client, deadline, ServiceExistingCheckerMock.Object);
        }

        protected async Task<Valuation> RequestFakeValuation()
        {
            var email = Email.Of("test@mail.com");

            return await RequestFakeValuation(email);
        }
    }
}
