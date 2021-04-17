using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using FluentAssertions;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions
{
    internal static class AssertValuationEvents
    {
        internal static void AssertIsCorrect(this ValuationRequestedEvent @event, List<ServiceId> productIds, Email email)
        {
            @event.Should().NotBeNull();
            @event.ClientEmail.Should().Be(email);
            @event.ProductsIds.Should().BeEquivalentTo(productIds);
        }

        internal static void AssertIsCorrect(this ProposalSuggestedEvent @event, Money money, EmployeeId employee)
        {
            @event.Should().NotBeNull();
            @event.Value.Should().Be(money);
            @event.ProposalId.Should().NotBeNull();
            @event.ProposedBy.Should().Be(employee);
        }

        internal static void AssertIsCorrect(this ProposalApprovedEvent @event, Email clientEmail, ProposalId proposalId)
        {
            @event.Should().NotBeNull();
            @event.ClientEmail.Should().Be(clientEmail);
            @event.ProposalId.Should().Be(proposalId);
        }

        internal static void AssertIsCorrect(this ProposalRejectedEvent @event,
            Email clientEmail,
            ProposalId proposalId,
            string rejectReason)
        {
            @event.Should().NotBeNull();
            @event.EmployeeEmail.Should().Be(clientEmail);
            @event.ProposalId.Should().Be(proposalId);
            @event.ReasonMessage.Should().Be(rejectReason);
        }

        internal static void AssertIsCorrect(this ValuationCompletedEvent @event,
            EmployeeId closedBy,
            ValuationId valuationId)
        {
            @event.Should().NotBeNull();
            @event.ClosedBy.Should().Be(closedBy);
            @event.ValuationId.Should().Be(valuationId);
        }
    }
}
