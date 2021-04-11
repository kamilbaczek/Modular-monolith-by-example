using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals.Exceptions;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using FluentAssertions;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Tests.Valuations
{
    public class RequestValuationTests : BaseValuationTest
    {
        [Fact]
        public async Task Given_Request_When_ProductsExists_Then_ValuationIsCreated()
        {
            SetupProductExistingChecker();
            var productsIds = new List<ProductId>
            {
                new ProductId(Guid.NewGuid()),
                new ProductId(Guid.NewGuid()),
            };
            var email = Email.Of("test@mail.com");
            var client = Client.Of(email, "firstname", "lastname");

            var valuation = await Valuation.RequestAsync(productsIds, client, _productExistingCheckerMock.Object);

            var @event = GetPublishedEvent<ValuationRequestedEvent>(valuation);
            @event.AssertIsCorrect(productsIds, email);
        }

        [Fact]
        public async Task Given_Request_When_ProductsAreNotExists_Then_ValuationIsNotCreated()
        {
            SetupProductExistingChecker(false);
            var productsIds = new List<ProductId>
            {
                new ProductId(Guid.NewGuid()),
                new ProductId(Guid.NewGuid()),
            };
            var email = Email.Of("test@mail.com");
            var client = Client.Of(email, "firstname", "lastname");
            Func<Task> valuationRequestAsync = async () =>
            {
                await Valuation.RequestAsync(productsIds, client, _productExistingCheckerMock.Object);
            };

            await valuationRequestAsync.Should().ThrowAsync<InvalidProductsException>();
        }
    }
}
