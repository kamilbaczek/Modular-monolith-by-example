using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Moq;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Common
{
    public abstract class BaseValuationTest : BaseTest
    {
        protected readonly Mock<IProductExistingChecker> _productExistingCheckerMock;

        protected BaseValuationTest()
        {
            _productExistingCheckerMock = new Mock<IProductExistingChecker>();
            _productExistingCheckerMock.Setup(productExistingChecker =>
                productExistingChecker.ExistAsync(It.IsAny<List<Guid>>())).ReturnsAsync(true);
        }

        protected const string FakeRejectReason = "test";


        protected void SetupProductExistingChecker(bool areProductExists = true)
        {
            _productExistingCheckerMock
                .Setup(x => x.ExistAsync(It.IsAny<List<Guid>>()))
                .ReturnsAsync(areProductExists);
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
            var productsIds = new List<ProductId>
            {
                new ProductId(Guid.NewGuid()),
                new ProductId(Guid.NewGuid()),
            };
            var client = Client.Of(email, "firstname", "lastname");
            return await Valuation.RequestAsync(productsIds, client, _productExistingCheckerMock.Object);
        }

        protected async Task<Valuation> RequestFakeValuation()
        {
            var email = Email.Of("test@mail.com");

            return await RequestFakeValuation(email);
        }
    }
}
