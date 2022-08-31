namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Proposals;

using Common;
using Common.Builders;
using Domain.Valuations;
using Domain.Valuations.Exceptions;
using Domain.Valuations.Proposals.Events;
using Shared.DDD.BuildingBlocks.Tests;

public class CancelProposalTests : BaseValuationTest
{
    [Test]
    public void Given_CancelProposal_When_Then_ProposalIsCancelled()
    {
        var employeeId = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithEmployee(employeeId);
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();

        valuation.CancelProposal(proposalSuggestedDomainEvent.ProposalId);

        var @event = GetPublishedEvent<ProposalCancelledDomainEvent>(valuation);
        @event.ProposalId.Should().Be(proposalSuggestedDomainEvent.ProposalId);
    }

    [Test]
    public void Given_CancelProposal_When_ProposalIsAlreadyCancelled_Then_ThrowsProposalNotFoundException()
    {
        var employeeId = new EmployeeId(Guid.NewGuid());
        Valuation valuation = A.Valuation()
            .WithProposal()
            .WithEmployee(employeeId)
            .WithCancelledProposal();
        var proposalSuggestedDomainEvent = valuation.GetPublishedEvent<ProposalSuggestedDomainEvent>();

        var cancelledProposals = () => valuation.CancelProposal(proposalSuggestedDomainEvent.ProposalId);

        cancelledProposals.Should().Throw<ProposalNotFoundException>();
    }
}
