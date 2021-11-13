namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;

using Domain.Valuations;
using Domain.Valuations.Events;
using Domain.Valuations.Proposals;
using Domain.Valuations.Proposals.Events;
using FluentAssertions;
using Shared.DDD.ValueObjects;

internal static class AssertValuationEvents
{
    internal static void AssertIsCorrect(this ValuationRequestedDomainEvent domainEvent)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.ValuationId.Value.Should().NotBeEmpty();
    }

    internal static void AssertIsCorrect(this ProposalSuggestedDomainEvent domainEvent, Money money,
        EmployeeId employee)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.Value.Should().Be(money);
        domainEvent.ProposalId.Should().NotBeNull();
        domainEvent.ProposedBy.Should().Be(employee);
    }

    internal static void AssertIsCorrect(this ProposalApprovedDomainEvent domainEvent,
        EmployeeId employeeId,
        ProposalId proposalId)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.SuggestedBy.Should().Be(employeeId);
        domainEvent.ProposalId.Should().Be(proposalId);
    }

    internal static void AssertIsCorrect(this ProposalRejectedDomainEvent domainEvent,
        ProposalId proposalId,
        ValuationId valuationId)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.ProposalId.Should().Be(proposalId);
        domainEvent.ValuationId.Should().Be(valuationId);
    }

    internal static void AssertIsCorrect(this ValuationCompletedDomainEvent domainEvent,
        EmployeeId closedBy,
        ValuationId valuationId)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.InquiryId.Should().Be(closedBy);
        domainEvent.ValuationId.Should().Be(valuationId);
    }
}
